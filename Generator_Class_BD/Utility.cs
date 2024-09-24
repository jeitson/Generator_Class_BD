using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Generator_Class_BD
{
    static class Utility
    {
        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void SaveFile(string path, string fileName, StringBuilder contentFile)
        {
            CreateFolder(path);
            StreamWriter writer = File.CreateText(fileName);
            writer.WriteLine(contentFile.ToString());
            writer.Close();
        }
    }
}
