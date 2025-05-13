using AOC;
using AOC2019.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.PuzzleSolvers
{
    public class Day5PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {

            string inputText = InputFilesHelper.GetInputFileText("day5.txt");

            int[] intCode = inputText.Split(',').Select(int.Parse).ToArray();


            var computer = new IntcodeComputer();
            computer.LoadProgram(intCode, 1,1);

            return string.Empty ;
        }
        public string SolvePuzzlePart2()
        {
            return "Not implemented";
        }
    }
   
}
