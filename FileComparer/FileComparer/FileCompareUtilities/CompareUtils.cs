using System;
using System.Collections.Generic;

namespace HoddiLara.FileCompareUtilities
{
    /// <summary>
    /// Provides various functions for comparing files:
    ///     * Comparing two files
    ///     * Returning a list of all possible comparable files in a folder
    ///     * Returning a list of all possible comparable files in two different folders
    /// </summary>
    public class CompareUtils
    {
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
        /// Returns a combined list of all possible file matches in two folders
        /// </summary>
        /// <param name="pathToFirstFolder">The full path to the first folder to search</param>
        /// <param name="pathToSecondFolder">The full path to the second folder to search</param>
        /// <param name="patternToSearchFor">The file extension to search for</param>
        /// <returns></returns>
        public static List<PossibleMatches> CompareFolders(string pathToFirstFolder, string pathToSecondFolder, string patternToSearchFor)
        {
            List<string> allFiles = TraverseTreeByPattern(pathToFirstFolder, patternToSearchFor);
            allFiles.AddRange(TraverseTreeByPattern(pathToSecondFolder, patternToSearchFor));

            return GetMatchesFromFiles(allFiles);
        }

        /// <summary>
        /// Returns a list of all files in a folder and subfolders
        /// </summary>
        /// <param name="pathToFolder">Path to the folder to search</param>
        /// <param name="patternToSearchFor">The pattern to search for</param>
        /// <returns></returns>
        public static List<PossibleMatches> GetAllPossibleFileMatches(string pathToFolder, string patternToSearchFor)
        {            
            List<string> files = TraverseTreeByPattern(pathToFolder, patternToSearchFor);

            return GetMatchesFromFiles(files);
        }

        /// <summary>
        /// Returns all possible matches from a given list of files
        /// </summary>
        /// <param name="files">A list containing the full path to files</param>
        /// <returns></returns>
        private static List<PossibleMatches> GetMatchesFromFiles(List<string> files)
        {
            List<PossibleMatches> possibleMatches = new List<PossibleMatches>();
            List<FileHashPair> fileHashPairs = new List<FileHashPair>();

            // Calculate the hash value for each file
            foreach (string file in files)
            {
                FileHashPair fileHashPair = new FileHashPair(file, Cryptography.GetMD5Hash(file));

                fileHashPairs.Add(fileHashPair);

                if (HashProgressUpdate != null)
                {
                    HashProgressUpdate(fileHashPairs.Count, files.Count);
                }
            }

            // Sort the list by alphanumeric order by hash value
            // This should give us a way to sift through the files that are potentialy identical
            fileHashPairs.Sort();

            if (fileHashPairs.Count > 1)
            {
                PossibleMatches tempPossibleMatches = new PossibleMatches();

                // Once the list is sorted, we can compare each value and find the matches
                for (int i = 0; i < fileHashPairs.Count; i++)
                {
                    // Check for the last value in the list
                    if (i == fileHashPairs.Count - 1)
                    {
                        // This is kept inside the outer if statement to prevent 
                        // an index out of range exception occurring in the other if conditions
                        if (fileHashPairs[i] == fileHashPairs[i - 1])
                        {
                            tempPossibleMatches.Files.Add(fileHashPairs[i]);
                            possibleMatches.Add(tempPossibleMatches);
                        }
                    }
                    else if (fileHashPairs[i] == fileHashPairs[i + 1])
                    {
                        tempPossibleMatches.Files.Add(fileHashPairs[i]);
                    }
                    else if (i > 0 && fileHashPairs[i] != fileHashPairs[i + 1] && fileHashPairs[i] == fileHashPairs[i - 1])
                    {
                        tempPossibleMatches.Files.Add(fileHashPairs[i]);
                        possibleMatches.Add(tempPossibleMatches);
                        tempPossibleMatches = new PossibleMatches();
                    }
                }
            }

            return possibleMatches;
        }

        // Got this code from somewhere...
        /// <summary>
        /// Retrieves a list of all files in a given folder that match the given pattern
        /// </summary>
        /// <param name="root">The folder to start the search</param>
        /// <param name="patternToSearchFor">A string pattern to match the files to, i.e "*.mp3"</param>
        private static List<string> TraverseTreeByPattern(string root, string patternToSearchFor)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);
            List<string> filesFound = new List<string>();

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
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
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files;
                
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir, patternToSearchFor);
                }
                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
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
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        filesFound.Add(fi.FullName);

                        //Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (System.IO.FileNotFoundException e)
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
