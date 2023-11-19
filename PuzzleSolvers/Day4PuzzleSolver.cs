using AOC;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.PuzzleSolvers
{
    public class Day4PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfValidPasswords = 0;

            for (int i = 172930; i <= 683082; i++)
            {
                if (IsValidPassword(i))
                {
                    numOfValidPasswords++;
                }
            }

            return numOfValidPasswords.ToString();
        }

        private bool IsValidPassword(int password)
        {
            return password.ToString().HasStraightNLetters(2) && IsNonDecreasingDigits(password);
            
        }

        private bool IsNonDecreasingDigits(int password)
        {
            int[] digits = password.ToString().ToCharArray().Select(digit => int.Parse(digit.ToString())).ToArray();
            return  ListCrow.IsNonDecreasingSeries(digits);
        }

        public string SolvePuzzlePart2()
        {
            int numOfValidPasswords = 0;

            for (int i = 172930; i <= 683082; i++)
            {
                if (IsNonDecreasingDigits(i) && RegexRobin.HasExactlyTwoMatchingConsecutiveCharacters(i.ToString()))
                {
                    numOfValidPasswords++;
                }
            }

            return numOfValidPasswords.ToString();
        }

    }
}
