using System;
using System.Diagnostics;
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
        /// <param name="fileInfo">The information about the file to compute the hash for</param>
        /// <returns></returns>
        public static string GetMD5Hash(FileInfo fileInfo)
        {
            // Once a file reaches a size larger than 100MB you gain performance by only examining a part of the file.
            // A file this large is most likely a video file and it is safe to only look at the first few megabytes of the actual file.
            string result = fileInfo.Length > 100000000
                ? GetMD5HashFromPartialFile(fileInfo.FullName)
                : GetMD5HashFromWholeFile(fileInfo.FullName);

            return result;
        }

        /// <summary>
        /// Returns an MD5 has from beginning to the specified number of bytes given for the given file.
        /// </summary>
        /// <param name="filePath">The full path to the file to compute the hash for</param>
        /// <param name="peekSize">The maximum number of bytes that will be used from the file to calculate the hash.</param>
        /// <returns>The MD5 hash calculated from the first peekSize number of bytes. Returns an empty string if the hash could not be calculated</returns>
        private static string GetMD5HashFromPartialFile(string filePath, int peekSize = 10000000)
        {
            byte[] hashValue = null;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                FileStream stream = fileInfo.OpenRead();
                MemoryStream stream2 = new MemoryStream(peekSize);
                int readByte = 0;
                for (int i = 0; i < stream2.Capacity || !stream.CanRead; i++)
                {
                    readByte = stream.ReadByte();
                    if (readByte == -1)
                    {
                        break;
                    }

                    stream2.WriteByte((byte)readByte);
                }

                stream2.Position = 0;

                hashValue = MD5.ComputeHash(stream2);

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

                FileStream stream = fileInfo.OpenRead();

                stream.Position = 0;

                hashValue = MD5.ComputeHash(stream);

                stream.Close();

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
