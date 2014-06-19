using System;
using System.IO;
using System.Security.Cryptography;

namespace HL.FileComparer.Utilities
{
    public class Cryptography
    {
        private static MD5CryptoServiceProvider md5;

        /// <summary>
        /// The MD5 class used for hashing
        /// </summary>
        private static MD5CryptoServiceProvider MD5
        {
            get { return md5 ?? (md5 = new MD5CryptoServiceProvider()); }
        }

        /// <summary>
        /// Returns an MD5 hash for a given file
        /// </summary>
        /// <param name="filePath">The full path to the file to compute the hash for</param>
        /// <returns></returns>
        public static string GetMD5Hash(string filePath)
        {
            byte[] hashValue = null;

            try
            {                                
                FileInfo fileInfo = new FileInfo(filePath);

                FileStream stream = fileInfo.OpenRead();                
                stream.Position = 0;        
        
                hashValue = MD5.ComputeHash(stream);

                stream.Close();

                return BitConverter.ToString(hashValue);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

            
        }
    }
}
