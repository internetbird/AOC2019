using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.Logic
{
    public class IntcodeComputerCommandParameter
    {
        public int Value { get; set; }
        public IntcodeComputerCommandParameterMode Mode { get; set; }
        public IntcodeComputerCommandParameter(int value, IntcodeComputerCommandParameterMode mode)
        {
            Value = value;
            Mode = mode;
        }
        public override string ToString()
        {
            return $"Value: {Value}, Mode: {Mode}";
        }

    }
}
