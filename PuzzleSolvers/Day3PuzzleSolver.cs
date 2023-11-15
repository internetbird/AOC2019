using AOC;
using BirdLib.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AOC2019.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            List<Point> intersectingPoints = GetIntersectingPoints();

            int closestDistance = intersectingPoints.Select(point => Math.Abs(point.X) + Math.Abs(point.Y)).Min();
            return closestDistance.ToString();
        }

        private List<Point> GetIntersectingPoints()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            HashSet<string> wire1Points = GetWirePoints(inputLines[0]);
            HashSet<string> wire2Points = GetWirePoints(inputLines[1]);

            List<string> intersectingPointsStrings = wire1Points.Intersect(wire2Points).ToList();

            List<Point> intersectingPoints = intersectingPointsStrings.Select(str => str.ParsePoint()).ToList();
            return intersectingPoints;
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
            List<Point> intersectingPoints = GetIntersectingPoints();

            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            string[] wire1Instructions = inputLines[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
            string[] wire2Instructions = inputLines[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

            List<int> stepSums = GetWireStepsSums(intersectingPoints, wire1Instructions, wire2Instructions);


            return stepSums.Min().ToString();
        }

        private List<int> GetWireStepsSums(List<Point> intersectingPoints, string[] wire1Instructions, string[] wire2Instructions)
        {
           var sums = new List<int>();

            foreach (Point point in intersectingPoints)
            {
                int wire1Steps = GetWireStepsToPoint(point, wire1Instructions);
                int wire2Steps = GetWireStepsToPoint(point, wire2Instructions);

                sums.Add(wire1Steps + wire2Steps);
            }

            return sums;
        }

        private int GetWireStepsToPoint(Point point, string[] instructions)
        {
            int currX = 0;
            int currY = 0;
            int stepsCount = 0;

            foreach (string instruction in instructions)
            {
                char direction = instruction[0];
                int distance = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case 'U':
                        for (int i = 0; i < distance; i++)
                        {
                            currY--;
                            stepsCount++;

                            if (currX == point.X &&  currY == point.Y)
                            {
                                return stepsCount;
                            }
                          
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < distance; i++)
                        {
                            currY++;
                            stepsCount++;

                            if (currX == point.X && currY == point.Y)
                            {
                                return stepsCount;
                            }
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < distance; i++)
                        {
                            currX++;
                            stepsCount++;

                            if (currX == point.X && currY == point.Y)
                            {
                                return stepsCount;
                            }
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < distance; i++)
                        {
                            currX--;
                            stepsCount++;

                            if (currX == point.X && currY == point.Y)
                            {
                                return stepsCount;
                            }
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid direction : {direction}");
                }
            }


            throw new Exception("Could not reach point");
        }
    }
}
