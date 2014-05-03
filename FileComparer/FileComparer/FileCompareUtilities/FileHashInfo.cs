using System;

namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Contains a path to a file and the hash value of that file
    /// </summary>
    public class FileHashPair : IComparable
    {
        private string fileName;
        private string fileHash;

        public FileHashPair(string fileName, string fileHash)
        {
            this.fileName = fileName;
            this.fileHash = fileHash;
        }

        /// <summary>
        /// The full path to a file
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        /// <summary>
        /// The hash value of the file pointed to by FileName
        /// </summary>
        public string FileHash
        {
            get
            {
                return fileHash;
            }
        }

        public int CompareTo(object fileHashPair)
        {
            return String.CompareOrdinal(FileHash, ((FileHashPair)fileHashPair).FileHash);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            FileHashPair pairToCompare = obj as FileHashPair;

            // If obj is not a FileHashPair object we return false
            if ((Object)pairToCompare == null)
            {
                return false;
            }

            return (pairToCompare.FileHash == FileHash);
        }

        public bool Equals(FileHashPair fileHashPair)
        {
            if ((object)fileHashPair == null)
            {
                return false;
            }

            return FileHash != null && (FileHash == fileHashPair.FileHash);
        }

        public static bool operator ==(FileHashPair a, FileHashPair b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.FileHash == b.FileHash;
        }

        public static bool operator !=(FileHashPair a, FileHashPair b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
