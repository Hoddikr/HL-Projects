using System;
using System.Security.Cryptography;
using System.IO;

namespace HoddiLara.FileCompareUtilities
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
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return GetByteArrayStringRepresentation(hashValue);            
        }

        public static string GetByteArrayStringRepresentation(byte[] array)
        {
            string byteString = "";

            int i;
            for (i = 0; i < array.Length; i++)
            {
                byteString += String.Format("{0:X2}", array[i]);

                if ((i % 4) == 3)
                {
                    //Console.Write(" ");
                    //byteString += " ";
                }
            }

            return byteString;
        }
    }
}
