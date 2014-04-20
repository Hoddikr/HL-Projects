using System.Collections.Generic;
using HoddiLara.FileCompareUtilities;

namespace FileComparer
{
    internal class Settings
    {
        internal static List<SearchPattern> SearchPatterns;

        public static void LoadSettings()
        {
            SearchPatterns = new List<SearchPattern>();
            SearchPatterns.Add(new SearchPattern(){Description = "Images", Pattern =  "*.jpg"});
            SearchPatterns.Add(new SearchPattern(){Description = "Videos", Pattern =  "*.avi"});
            SearchPatterns.Add(new SearchPattern(){Description = "Music", Pattern =  "*.mp3"});
        }
    }
}
