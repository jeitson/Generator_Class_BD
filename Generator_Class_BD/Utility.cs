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
            Console.WriteLine("iniciado 1");
            Console.WriteLine("iniciado 2");
            Console.WriteLine("iniciado 3");
            Console.WriteLine("iniciado 4");
            Console.WriteLine("iniciado 5");

            Console.WriteLine("iniciado 6");
            Console.WriteLine("iniciado 7");
            Console.WriteLine("iniciado 8");
        }
    }
}
