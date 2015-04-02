using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HL.Utilities.UI
{
    /*
     * Contains various Win32 interop functions.
     * 
     * Getting an icon from a file:
     * http://support.microsoft.com/kb/319350     
     */


    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    public class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        /// <summary>
        /// Gets the small Icon currently in use by the operating system for the given file
        /// </summary>
        /// <param name="filePath">The full path to the file</param>
        /// <returns></returns>
        public static Icon GetFileSmallIcon(string filePath)
        {
            return GetFileIcon(filePath, true);
        }

        /// <summary>
        /// Gets the large Icon currently in use by the operating system for the given file
        /// </summary>
        /// <param name="filePath">The full path to the file</param>
        /// <returns></returns>
        public static Icon GetFileLargeIcon(string filePath)
        {
            return GetFileIcon(filePath, false);
        }

        /// <summary>
        /// Gets the file icon currently in use by the operating system for the given file
        /// </summary>
        /// <param name="filepath">The full path to the file</param>
        /// <param name="smallIcon">If true the small icon is returned, otherwise the large icon is returned</param>
        /// <returns></returns>
        private static Icon GetFileIcon(string filepath, bool smallIcon)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            if (smallIcon)
            {
                SHGetFileInfo(filepath, 0, ref shinfo, (uint) Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            }
            else
            {
                SHGetFileInfo(filepath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            }

            return Icon.FromHandle(shinfo.hIcon);
        }
    }
}
