namespace HL.Controls.HLControls.EventArguments
{
    public class SelectionChangedEventArgs
    {
        /// <summary>
        /// The key of the category that the clicked item belongs to
        /// </summary>
        public string CategoryKey { get; set; }

        /// <summary>
        /// The description of the category that the clicked item belongs to
        /// </summary>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// The description of the clicked item
        /// </summary>
        public string CategoryItemDescriptoin { get; set; }
    }
}
