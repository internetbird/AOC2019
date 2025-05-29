using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.PuzzleSolvers
{
    public class Day6PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            Dictionary<string, string> dictionary = GetOrbitsDictionary();
            int totalOrbits = 0;
            foreach (var key in dictionary.Keys)
            {
                string current = key;
                while (current != "COM")
                {
                    totalOrbits++;
                    current = dictionary[current];
                }
            }


            return totalOrbits.ToString();
        }

        private static Dictionary<string, string> GetOrbitsDictionary()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day6.txt");


            var dictionary = new Dictionary<string, string>();
            foreach (var line in inputLines)
            {
                var parts = line.Split(')');
                if (parts.Length == 2)
                {
                    dictionary[parts[1]] = parts[0];
                }
            }

            return dictionary;
        }

        public string SolvePuzzlePart2()
        {
            var dictionary = GetOrbitsDictionary();

            var youPath = new List<string>();
            var sanPath = new List<string>();
            string current = "YOU";
            while (current != "COM")
            {
                youPath.Add(current);
                current = dictionary[current];
            }
            current = "SAN";
            while (current != "COM")
            {
                sanPath.Add(current);
                current = dictionary[current];
            }
            youPath.Reverse();
            sanPath.Reverse();
            int commonIndex = 0;
            while (commonIndex < youPath.Count && commonIndex < sanPath.Count && youPath[commonIndex] == sanPath[commonIndex])
            {
                commonIndex++;
            }
            // The number of transfers is the total length of both paths minus twice the common length minus 2 (because we don't count the common nodes themselves).
            int transfers = (youPath.Count - commonIndex) + (sanPath.Count - commonIndex) - 2;
            return transfers.ToString();
        }
    }
}
