using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Contains various static cryptographic functions
    /// </summary>
    public class Cryptography
    {

        /// <summary>
        /// Returns an MD5 hash for a given file
        /// </summary>
        /// <param name="fileInfo">The information about the file to compute the hash for</param>
        /// <returns></returns>
        public static string GetMD5Hash(FileInfo fileInfo)
        {
            
            // Once a file reaches a size larger than 100MB you gain performance by only examining a part of the file.
            // A file this large is most likely a video file and it is safe to only look at the first few megabytes of the actual file.
            string result = fileInfo.Length > 10240000
            //string result = fileInfo.Length > 4096000
                ? GetMD5HashFromPartialFile(fileInfo)
                : GetMD5HashFromWholeFile(fileInfo.FullName);

            
        
            return result;
        }

        /// <summary>
        /// Returns an MD5 hash string from  the beginning of the given file to the specified number of bytes given for the given file.
        /// </summary>
        /// <param name="fileInfo">The FileInfo for the file to compute the hash from</param>
        /// <param name="peekSize">The maximum number of bytes that will be used from the file to calculate the hash. The default is 10 MB (10.000 X 1024 bytes) </param>
        /// <returns>The MD5 hash calculated from the first peekSize number of bytes. Returns an empty string if the hash could not be calculated</returns>
        public static string GetMD5HashFromPartialFile(FileInfo fileInfo, int peekSize = 10240000)
        {
            byte[] hashValue = null;

            try
            {
                //FileInfo fileInfo = new FileInfo(filePath);

                if (peekSize > fileInfo.Length)
                {
                    peekSize = (int)fileInfo.Length;
                }

                FileStream stream = fileInfo.OpenRead();
                MemoryStream stream2 = new MemoryStream(peekSize);
                int readByte = 0;

                byte[] buffer = new byte[4096];

                for (int i = 0; i < peekSize || !stream.CanRead; i += 4096)
                {
                    readByte = stream.Read(buffer, 0, buffer.Length);
                    if (readByte <= 0)
                    {
                        break;
                    }

                    stream2.Write(buffer, 0, buffer.Length);
                }

                stream2.Position = 0;
                
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    hashValue = md5.ComputeHash(stream2);
                }

                stream.Close();
                stream2.Close();

                return BitConverter.ToString(hashValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        /// <summary>
        /// Returns an MD5 hash for the entire given file
        /// </summary>
        /// <param name="filePath">The full path to the file to compute the hash for</param>
        /// <returns></returns>
        private static string GetMD5HashFromWholeFile(string filePath)
        {
            byte[] hashValue = null;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                using (FileStream stream = fileInfo.OpenRead())
                {

                    stream.Position = 0;

                    using (MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider())
                    {
                        hashValue = md5Crypto.ComputeHash(stream);
                    }

                    stream.Close();
                }

                return BitConverter.ToString(hashValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }     
        }
    }
}
