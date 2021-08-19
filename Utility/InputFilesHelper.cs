using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2019.Utility
{
    public static class InputFilesHelper
    {
        public static string[] GetInputFileLines (string fileName)
        {
            var fullInputFilePath = Path.GetFullPath($"InputFiles/{fileName}");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            return inputStrings;

        }


        public static string GetInputFileText(string fileName)
        {
            var fullInputFilePath = Path.GetFullPath($"InputFiles/{fileName}");
            string inputText = File.ReadAllText(fullInputFilePath);

            return inputText;

        }
    }
}
