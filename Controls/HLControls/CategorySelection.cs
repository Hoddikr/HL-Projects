using System;

namespace HL.Controls.HLControls
{
    /// <summary>
    /// Represents the current selection in a category control. There can only be one selection, and a selection is considered
    /// "selected" if and only if it contains both a non-empty CategoryKey and CategoryItemKey
    /// </summary>
    internal class CategorySelection
    {
        /// <summary>
        /// The key of the category
        /// </summary>
        public string CategoryKey { get; set; }

        /// <summary>
        /// The text on the category item
        /// </summary>
        public string CategoryItemKey { get; set; }

        /// <summary>
        /// Gets wether a category item is selected
        /// </summary>
        public bool Selected
        {
            get
            {
                return !String.IsNullOrEmpty(CategoryKey) && !String.IsNullOrEmpty(CategoryItemKey);
            }
        }
    }
}
