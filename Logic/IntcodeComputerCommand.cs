using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019.Logic
{
    public class IntcodeComputerCommand
    {
        public IntcodeComputerCommand() { }

        public IntcodeCompunterCommandOpCode OpCode { get; set; }

        public List<IntcodeComputerCommandParameter> Parameters { get; set; } 
        public IntcodeComputerCommand(IntcodeCompunterCommandOpCode opCode, List<IntcodeComputerCommandParameter> parameters)
        {
            OpCode = opCode;
            Parameters = parameters;
        }
    }
}
