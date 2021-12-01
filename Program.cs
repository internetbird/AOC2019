using AOC2019.PuzzleSolvers;
using System;

namespace AOC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day2PuzzleSolver();

            var solution = solver.SolvePuzzlePart1();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
