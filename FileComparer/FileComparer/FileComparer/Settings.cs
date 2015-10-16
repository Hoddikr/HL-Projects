using System;
using System.Collections.Generic;
using System.IO;
using HL.FileComparer.Utilities;
using Newtonsoft.Json;

namespace HL.FileComparer
{
    internal class Settings
    {
        internal static List<SearchPattern> SearchPatterns;

        private static string ApplicationDataPath => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\HL\\File Comparer";

        public static void LoadSettings()
        {

            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
            }

            string path = ApplicationDataPath + "\\settings";

            if (!File.Exists(path))
            {
                SearchPatterns = new List<SearchPattern>();
                SearchPatterns.Add(new SearchPattern() { Description = "Images", Pattern = "*.jpg;*.bmp;*.png" });
                SearchPatterns.Add(new SearchPattern() { Description = "Videos", Pattern = "*.avi;*.mp4;*.mkv" });
                SearchPatterns.Add(new SearchPattern() { Description = "Music", Pattern = "*.mp3" });

                SaveSettings();
            }
            else
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        string serailizedSettings = sr.ReadLine();
                        sr.Close();

                        SearchPatterns = JsonConvert.DeserializeObject<List<SearchPattern>>(serailizedSettings);
                    }
                }
            }
        }

        public static void SaveSettings()
        {
            string path = ApplicationDataPath + "\\settings";

            string jsonSettings = JsonConvert.SerializeObject(SearchPatterns);

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(jsonSettings);
                    sw.Close();
                }
            }
        }
    }
}
