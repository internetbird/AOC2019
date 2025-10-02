using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.PuzzleSolvers
{
    public class Day8PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputText = InputFilesHelper.GetInputFileText("day8.txt");
            int width = 25;
            int height = 6;
            int layerSize = width * height;
            int layerCount = inputText.Length / layerSize;
            int[,] layers = new int[layerCount, layerSize];
            for (int layer = 0; layer < layerCount; layer++)
            {
                for (int i = 0; i < layerSize; i++)
                {
                    layers[layer, i] = int.Parse(inputText[layer * layerSize + i].ToString());
                }
            }
            int fewestZeroes = int.MaxValue;
            int result = 0;
            for (int layer = 0; layer < layerCount; layer++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                int twoCount = 0;
                for (int i = 0; i < layerSize; i++)
                {
                    if (layers[layer, i] == 0) zeroCount++;
                    else if (layers[layer, i] == 1) oneCount++;
                    else if (layers[layer, i] == 2) twoCount++;
                }
                if (zeroCount < fewestZeroes)
                {
                    fewestZeroes = zeroCount;
                    result = oneCount * twoCount;
                }
            }

            return result.ToString();

        }

        public string SolvePuzzlePart2()
        {
            string inputText = InputFilesHelper.GetInputFileText("day8.txt");

            int width = 25;
            int height = 6;
            int layerSize = width * height;
            int layerCount = inputText.Length / layerSize;

            int[,] layers = new int[layerCount, layerSize];
            for (int layer = 0; layer < layerCount; layer++)
            {
                for (int i = 0; i < layerSize; i++)
                {
                    layers[layer, i] = int.Parse(inputText[layer * layerSize + i].ToString());
                }
            }
            int[] finalImage = new int[layerSize];
            for (int i = 0; i < layerSize; i++)
            {
                finalImage[i] = 2; // Start with transparent
                for (int layer = 0; layer < layerCount; layer++)
                {
                    if (layers[layer, i] != 2) // If not transparent
                    {
                        finalImage[i] = layers[layer, i];
                        break;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    int pixel = finalImage[row * width + col];
                    sb.Append(pixel == 1 ? '█' : ' '); // Use a block character for white pixels
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());



            return string.Empty;

        }
    }
}
