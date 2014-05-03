namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Represents a description and value of a search pattern
    /// </summary>
    public class SearchPattern
    {
        /// <summary>
        /// The description of the search pattern
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A search pattern, i.e *.jpg or a list of patterns seperated by a semicolon, i.e *.jpg; *.png
        /// </summary>
        public string Pattern { get; set; }
    }
}
