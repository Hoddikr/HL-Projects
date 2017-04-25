using HL.FileComparer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.FileComparer
{
    /// <summary>
    /// A class that's used to store the current state before it's saved to a file or loaded to restore a previously saved state
    /// </summary>
    public class State
    {
        /// <summary>
        /// Gets or sets the current list of possible matches
        /// </summary>
        public Dictionary<string, List<FileHashPair>> PossibleMatches { get; set; }

        /// <summary>
        /// Gets or sets a colon delimited list of folders
        /// </summary>
        public string SelectedFolders { get; set; }
    }
}
