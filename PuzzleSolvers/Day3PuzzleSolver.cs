using AOC;
using BirdLib.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2019.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            HashSet<string> wire1Points = GetWirePoints(inputLines[0]);
            HashSet<string> wire2Points = GetWirePoints(inputLines[1]);
            
            List<string> intersectingPointsStrings = wire1Points.Intersect(wire2Points).ToList();

            List<Point> intersectingPoints = intersectingPointsStrings.Select(str => str.ParsePoint()).ToList();

            int closestDistance = intersectingPoints.Select(point => Math.Abs(point.X) + Math.Abs(point.Y)).Min();
            return closestDistance.ToString();
        }

        
        
        private HashSet<string> GetWirePoints(string instructionsString)
        {

            int currX = 0;
            int currY = 0;

            var points = new HashSet<string>();

            string[] instructions = instructionsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in instructions)
            {
                char direction = instruction[0];
                int distance = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case 'U':
                        for (int i = 0; i< distance; i++)
                        {
                            currY--;
                            points.Add((new Point(currX, currY)).ToString());
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < distance; i++)
                        {
                            currY++;
                            points.Add((new Point(currX, currY)).ToString());
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < distance; i++)
                        {
                            currX++;
                            points.Add((new Point(currX, currY)).ToString());
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < distance; i++)
                        {
                            currX--;
                            points.Add((new Point(currX, currY)).ToString());
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid direction : {direction}");
                }
            }
            return points;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
