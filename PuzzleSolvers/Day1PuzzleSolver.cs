using AOC;
using AOC2019.Calculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.PuzzleSolvers
{
    public class Day1PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int fuelRequirmentsSum = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day1.txt");

            for (int i = 0; i < inputLines.Length; i++)
            {
                int mass = int.Parse(inputLines[i]);
                fuelRequirmentsSum += SpacecraftFuelCalculator.CalculateFuelForMass(mass);
            }

            return fuelRequirmentsSum.ToString();
        }

        public string SolvePuzzlePart2()
        {
            int fuelRequirmentsSum = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day1.txt");

            for (int i = 0; i < inputLines.Length; i++)
            {
                int mass = int.Parse(inputLines[i]);
                fuelRequirmentsSum += SpacecraftFuelCalculator.CalculateFuelForMassWithFuel(mass);
            }

            return fuelRequirmentsSum.ToString();
        }
    }
}
