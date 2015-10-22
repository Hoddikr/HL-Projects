using System;
using System.Collections.Generic;
using System.IO;
using HL.FileComparer.Utilities;
using Newtonsoft.Json;

namespace HL.FileComparer
{
    internal class Settings
    {
        internal static List<FileType> FileTypes;

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
                FileTypes = new List<FileType>();
                FileTypes.Add(new FileType() { Description = "Images", Pattern = "*.jpg;*.bmp;*.png", MaxNoOfMBToSearch = 10});
                FileTypes.Add(new FileType() { Description = "Videos", Pattern = "*.avi;*.mp4;*.mkv", MaxNoOfMBToSearch = 10 });
                FileTypes.Add(new FileType() { Description = "Music", Pattern = "*.mp3", MaxNoOfMBToSearch = 10 });

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

                        FileTypes = JsonConvert.DeserializeObject<List<FileType>>(serailizedSettings);
                    }
                }
            }
        }

        public static void SaveSettings()
        {
            string path = ApplicationDataPath + "\\settings";

            string jsonSettings = JsonConvert.SerializeObject(FileTypes);

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
