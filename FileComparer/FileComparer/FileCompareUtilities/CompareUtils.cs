using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Provides various functions for comparing files:
    ///     * Comparing two files
    ///     * Returning a list of all possible comparable files in a folder
    ///     * Returning a list of all possible comparable files in two different folders
    /// </summary>
    public class CompareUtils
    {
        private static BackgroundWorker progressWorker;

        /// <summary>
        /// Occurs each time a file has been hashed
        /// </summary>
        /// <param name="filesHashed">The number of files that have been hashed</param>
        /// <param name="totalNumberOfFiles">The total number of files</param>
        public delegate void HashProgressUpdateHandler(int filesHashed, int totalNumberOfFiles);

        /// <summary>
        /// Occurs each time a file has been hashed
        /// </summary>
        public static event HashProgressUpdateHandler HashProgressUpdate;

        /// <summary>
        /// Returns a list of all files in a single or multiple folders and all subfolders
        /// </summary>
        /// <param name="pathToFolder">Path to the folder to search. To search multiple folders, separate each path with a semicolon(;) character</param>
        /// <param name="patternToSearchFor">The pattern to search for</param>
        /// <returns>A dictionary where the key is the file hash and the value is the list of files that are identical</returns>
        public static Dictionary<string, List<FileHashPair>> GetAllPossibleFileMatches(string pathToFolder, string patternToSearchFor)
        {

            string[] paths = pathToFolder.Split(new[] {';'}, StringSplitOptions.None);

            List<FileInfo> files = new List<FileInfo>();

            foreach (string path in paths)
            {
                files.AddRange(TraverseTreeByPattern(path, patternToSearchFor));    
            }
            

            return GetMatchesFromFiles(files);
        }                

        /// <summary>
        /// Returns a list of all files in a single or multiple folders and all subfolders.This function should be used
        /// when a background worker is used to run the function. While the files are being processed the workers
        /// ReportProgress function will be called so that a UI element can be updated with the current progress.
        /// </summary>
        /// <param name="pathToFolder">Path to the folder to search. To search multiple folders, separate each path with a semicolon(;) character</param>
        /// <param name="patternToSearchFor">The pattern to search for</param>
        /// <param name="worker">The BackgroundWorker that is running this function</param>
        /// <returns>A dictionary where the key is the file hash and the value is the list of files that are identical</returns>
        public static Dictionary<string, List<FileHashPair>> GetAllPossibleFileMatches(string pathToFolder, string patternToSearchFor, BackgroundWorker worker)
        {
            progressWorker = worker;

            return GetAllPossibleFileMatches(pathToFolder, patternToSearchFor);
        }


        /// <summary>
        /// Returns all possible matches from a given list of files
        /// </summary>
        /// <param name="files">A list containing the information for each file</param>
        /// <returns>A dictionary where the key is the file hash and the value is the list of files that are identical></returns>
        private static Dictionary<string, List<FileHashPair>> GetMatchesFromFiles(List<FileInfo> files)
        {
            Dictionary<string, List<FileHashPair>> possibleMatches = new Dictionary<string, List<FileHashPair>>();
            List<FileHashPair> fileHashPairs = new List<FileHashPair>();
            ProgressInfo info = new ProgressInfo();

            // We can eliminate a lot of possibilities by comparing file size.
            // Each file that does not have a matching file with the same size cannot possibly have 
            // the same file hash as another file and can be safely discarded.
            if (files.Count > 2)
            {
                files = new List<FileInfo>(files.OrderBy(p => p.Length));

                List<int> indexesToRemove = new List<int>();

                for (int i = 0; i < files.Count; i++)
                {
                    if (i == 0 && files[i].Length != files[i + 1].Length)
                    {
                        indexesToRemove.Add(i);
                    }
                    else if (i == files.Count - 1 && files[i].Length != files[i - 1].Length)
                    {
                        indexesToRemove.Add(i);
                    }
                    else if ((i != 0 && i != files.Count - 1) &&
                             files[i].Length != files[i - 1].Length && files[i].Length != files[i + 1].Length)
                    {
                        indexesToRemove.Add(i);
                    }
                }

                int indicesRemoved = 0;
                foreach (var index in indexesToRemove)
                {
                    files.RemoveAt(index - indicesRemoved);
                    indicesRemoved++;
                }
            }

            // Calculate the hash value for each file
            foreach (FileInfo file in files)
            {
                FileHashPair fileHashPair = new FileHashPair(file.FullName, Cryptography.GetMD5Hash(file), file.Length);

                fileHashPairs.Add(fileHashPair);

                if (HashProgressUpdate != null)
                {
                    HashProgressUpdate(fileHashPairs.Count, files.Count);                    
                }

                if (progressWorker != null && progressWorker.IsBusy && progressWorker.WorkerReportsProgress)
                {
                    info.FilesProcessed = fileHashPairs.Count;
                    info.TotalNumberOfFiles = files.Count;
                    progressWorker.ReportProgress((int)((fileHashPairs.Count / (double)files.Count) * 100), info);
                }

                if (progressWorker != null && progressWorker.WorkerSupportsCancellation && progressWorker.CancellationPending)
                {                    
                    possibleMatches.Clear();                    
                    return possibleMatches;
                }
            }

            foreach (FileHashPair fileHashPair in fileHashPairs)
            {
                if (possibleMatches.ContainsKey(fileHashPair.FileHash))
                {
                    (possibleMatches[fileHashPair.FileHash]).Add(fileHashPair);
                }
                else
                {
                    possibleMatches.Add(fileHashPair.FileHash, new List<FileHashPair>());
                    possibleMatches[fileHashPair.FileHash].Add(fileHashPair);
                }
            }


            var orphanKeys = new List<string>();

            foreach (var possibleMatch in possibleMatches.Keys)
            {
                if (possibleMatches[possibleMatch].Count == 1)
                {
                    orphanKeys.Add(possibleMatch);
                }
            }

            foreach (var orphanKey in orphanKeys)
            {
                possibleMatches.Remove(orphanKey);
            }

            return possibleMatches;

        }

        // Got this code from somewhere...
        /// <summary>
        /// Retrieves a list of all files in a given folder that match the given pattern
        /// </summary>
        /// <param name="root">The folder to start the search</param>
        /// <param name="patternToSearchFor">A string pattern to match the files to, i.e "*.mp3"</param>
        private static List<FileInfo> TraverseTreeByPattern(string root, string patternToSearchFor)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);
            List<FileInfo> filesFound = new List<FileInfo>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                if (progressWorker != null && progressWorker.CancellationPending)
                {
                    return new List<FileInfo>();
                }

                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);                                      
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files;
                
                try
                {
                    // GetFiles does not support multiple patterns, therefore we need to combine the results for each 
                    // pattern we are looking for

                    string[] patterns = patternToSearchFor.Split(';');
                    List<string[]> allFiles = new List<string[]>();

                    foreach (var pattern in patterns)
                    {
                        allFiles.Add(Directory.GetFiles(currentDir, pattern));
                    }

                    int totalSize = allFiles.Sum(array => array.Length);

                    files = new string[totalSize];
                    int currentPosition = 0;

                    foreach (var fileCollection in allFiles)
                    {
                        foreach (var file in fileCollection)
                        {
                            files[currentPosition] = file;
                            currentPosition++;
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        FileInfo fi = new System.IO.FileInfo(file);

                        if (fi.Length > 0)
                        {
                            filesFound.Add(new FileInfo(fi.FullName));
                        }

                        //Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                }
            }

            return filesFound;
        }        
    }
}
