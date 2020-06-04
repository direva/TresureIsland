using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace TreasureIsland
{
    public class FileParser
    {
        string filePath;

        public FileParser(string path)
        {
            this.filePath = path;
        }

        private int FindMaxElement(List<int> elements)
        {
            int max = elements[0];
            foreach (var element in elements)
            {
                max = max < element ? element : max;
            }
            return max;
        }

        public string[] PrepareFile()
        {
            string[] allLines = File.ReadAllLines(filePath);

            for (int i = 0; i < allLines.Length; i++)
            {
                allLines[i] = allLines[i].Replace(" ", "").ToLower();
            }

            return allLines;
        }
    }
}
