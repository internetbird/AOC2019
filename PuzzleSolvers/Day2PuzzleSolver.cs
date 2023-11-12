using AOC;
using AOC2019.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.PuzzleSolvers
{
    public class Day2PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputText = InputFilesHelper.GetInputFileText("day2.txt");

            int[] intCode = inputText.Split(',').Select(int.Parse).ToArray();

            var computer = new IntcodeComputer();

            computer.LoadProgram(intCode, 12, 2);
            computer.RunProgram();

            int answer = computer.GetOutput();

            return answer.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string inputText = InputFilesHelper.GetInputFileText("day2.txt");

            int[] intCode = inputText.Split(',').Select(int.Parse).ToArray();

            const int expectedOutput = 19690720;

            var computer = new IntcodeComputer();

            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    computer.LoadProgram(intCode, i, j);
                    computer.RunProgram();

                    int output = computer.GetOutput();
                    if (output == expectedOutput)
                    {
                        return ((100 * i) + j).ToString();
                    }
                }
            }

            return String.Empty;
        }
    }
}
