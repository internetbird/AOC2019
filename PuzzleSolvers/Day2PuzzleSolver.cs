using AOC2019.Logic;
using AOC2019.Utility;
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

            //Initial change
            intCode[1] = 12;
            intCode[2] = 2;

            var computer = new IntcodeComputer();

            computer.LoadProgram(intCode);
            computer.RunProgram();

            int answer = computer.GetMemoryPosition(0);

            return answer.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
