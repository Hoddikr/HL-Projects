namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Represents a description and search pattern for a file type
    /// </summary>
    public class FileType
    {
        /// <summary>
        /// The description of the search pattern
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A search pattern, i.e *.jpg or a list of patterns seperated by a semicolon, i.e *.jpg; *.png
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// The maximum number of MB to process when comparing files of this type
        /// </summary>
        public int MaxNoOfMBToSearch { get; set; }
    }
}
