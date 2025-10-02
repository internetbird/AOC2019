using AOC;
using AOC2019.Logic;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.PuzzleSolvers
{
    internal class Day7PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputText = InputFilesHelper.GetInputFileText("day7.txt");
            int[] intCode = inputText.Split(',').Select(int.Parse).ToArray();
            int[] currIntCode = intCode.Clone() as int[];


            int maxOutputSignal = int.MinValue;

            PermutationGenerator permutationGenerator = new PermutationGenerator();
            var permutations = permutationGenerator.GetAllPermutations(new int[] { 0, 1, 2, 3, 4 });

            foreach (var perm in permutations)
            {
                int inputSignal = 0;
                foreach (var phaseSetting in perm)
                {
                    var computer = new IntcodeComputer(true);
                    computer.LoadProgram(currIntCode);
                    computer.AddInput(phaseSetting);
                    computer.AddInput(inputSignal);
                    inputSignal = (int)computer.RunProgram();
                   
                }

                if (inputSignal > maxOutputSignal)
                {
                    maxOutputSignal = inputSignal;
                }
            }

            return maxOutputSignal.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string inputText = InputFilesHelper.GetInputFileText("day7.txt");
            int[] intCode = inputText.Split(',').Select(int.Parse).ToArray();
            

            int maxOutputSignal = int.MinValue;
            PermutationGenerator permutationGenerator = new PermutationGenerator();
            var permutations = permutationGenerator.GetAllPermutations(new int[] { 5, 6, 7, 8, 9 });

            foreach (var perm in permutations)
            {
                int inputSignal = 0;
                var computers = new List<IntcodeComputer>();
                for (int i = 0; i < 5; i++)
                {
                    var computer = new IntcodeComputer(true);
                    computer.LoadProgram(intCode.Clone() as int[]);
                    computer.AddInput(perm[i]);
                    computers.Add(computer);
                }
                bool allHalted = false;
                int currentComputerIndex = 0;
                while (!allHalted)
                {
                    var currentComputer = computers[currentComputerIndex];
                    currentComputer.AddInput(inputSignal);
                    var output = currentComputer.RunProgram();
                    if (output.HasValue)
                    {
                        inputSignal = (int)output;
                    }
                    allHalted = computers.All(c => c.IsHalted());
                    currentComputerIndex = (currentComputerIndex + 1) % 5;
                }
                if (inputSignal > maxOutputSignal)
                {
                    maxOutputSignal = inputSignal;
                }
            }



            return maxOutputSignal.ToString();

        }
    }
}
