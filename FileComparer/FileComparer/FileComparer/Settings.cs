using System.Collections.Generic;
using HL.FileComparer.Utilities;

namespace HL.FileComparer
{
    internal class Settings
    {
        internal static List<SearchPattern> SearchPatterns;

        public static void LoadSettings()
        {
            SearchPatterns = new List<SearchPattern>();
            SearchPatterns.Add(new SearchPattern(){Description = "Images", Pattern =  "*.jpg"});
            SearchPatterns.Add(new SearchPattern(){Description = "Videos", Pattern =  "*.avi;*.mp4;*.mkv"});
            SearchPatterns.Add(new SearchPattern(){Description = "Music", Pattern =  "*.mp3"});
        }
    }
}
