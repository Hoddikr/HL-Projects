using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoddiLara.FileCompareUtilities
{
    /// <summary>
    /// A simple structure that contains a list of files that are possibly the same
    /// </summary>
    public class PossibleMatches
    {
        public PossibleMatches()
        {
            Files = new List<FileHashPair>();
        }

        /// <summary>
        /// A list of all possible files that have the same hash value
        /// </summary>
        public List<FileHashPair> Files { get; set; }
    }
}
