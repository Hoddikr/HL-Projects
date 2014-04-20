using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HoddiLara.FileCompareUtilities;
using System.Diagnostics;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\hordur\Documents\Leiðbeiningar aldarinnar DropBox.docx";
            
            string picPath = @"C:\Users\hordur\Pictures\Rússland\2011-08-30";
            string picPath2 = @"C:\Users\hordur\Pictures\Rússland\2011-08-30 - Copy";

            //Console.WriteLine("Hashing test");
            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //long hashTime = 0;
            //watch.Start();

            //byte[] hash = Cryptography.GetMD5Hash(picPath);

            //watch.Stop();
            //hashTime = watch.ElapsedMilliseconds;
            //Console.WriteLine("=======================");
            //Console.Write("Elapsed time: " + hashTime);
            //Console.WriteLine("=======================");
            //Console.WriteLine();

            //if (hash != null)
            //{
            //    Cryptography.PrintByteArray(hash);
            //}
            CompareUtils.HashProgressUpdate += new CompareUtils.HashProgressUpdateHandler(CompareUtils_HashProgressUpdate);
            
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //List<PossibleMatches> possibleMatches = CompareUtils.GetAllPossibleFileMatches("C:\\Users\\hordur\\Pictures\\Rússland\\2011-08-30", "*.jpg");            
            //CompareUtils.GetAllPossibleFileMatches("C:\\Users\\hordur\\Pictures\\Rússland", "*.jpg");
            List<PossibleMatches> possibleMatches = CompareUtils.CompareFolders(picPath, picPath2, "*.jpg");
            watch.Stop();            
            string report = "";

            foreach (PossibleMatches possibleMatch in possibleMatches)
            {
                foreach (FileHashPair pair in possibleMatch.Files)
                {
                    report += pair.FileName + " ";
                }
                report += "\r\n\r\n";
            }

            MessageBox.Show(report);

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds);

            Console.WriteLine(watch.GetType().Name);

            Console.Read();
        }

        static void CompareUtils_HashProgressUpdate(int filesHashed, int totalNumberOfFiles)
        {
            Console.WriteLine("Progress: {0} of {1} files.", filesHashed, totalNumberOfFiles);
        }
    }
}
