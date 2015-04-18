using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Utilities
{
    /// <summary>
    /// Contains various utilitary functions for file handling
    /// </summary>
    public class File
    {
        /// <summary>
        /// Returns only the file name from the given path
        /// </summary>
        /// <param name="filePath">The fulll path to the file</param>
        /// <returns></returns>
        public static string GetFileShortName(string filePath)
        {
            int lastFolderSeparator = filePath.LastIndexOf('\\');
            return filePath.Substring(lastFolderSeparator + 1, filePath.Length - lastFolderSeparator - 1);            
        }
    }
}
