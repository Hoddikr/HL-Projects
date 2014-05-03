namespace HL.FileComparer.Utilities
{
    /// <summary>
    /// Stores the current progress of the CompareFolders function. This class is sent to the ReportProgress function of a 
    /// BackgroundWorker
    /// </summary>
    public class ProgressInfo
    {
        /// <summary>
        /// The current number of files that have been processed
        /// </summary>
        public int FilesProcessed { get; set; }

        /// <summary>
        /// The total number of files that will be processed
        /// </summary>
        public int TotalNumberOfFiles { get; set; }
    }
}
