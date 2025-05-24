using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AOC2019.Logic
{
    public class IntcodeComputer
    {
        private int[] _memory;
        private const int MemorySize = 1000;
        private int _PC;

        public void LoadProgram(int[] program, int? noun = null, int? verb = null)
        {

            _memory = new int[MemorySize];

            program.CopyTo(_memory, 0);

            if (noun != null)
            {
                _memory[1] = noun.Value;
            }

            if(verb != null)
            {
                _memory[2] = verb.Value;
            }
        }

        public void RunProgram()
        {
            _PC = 0;

            IntcodeComputerCommand command = null;

            while (command?.OpCode != IntcodeCompunterCommandOpCode.Halt && (_PC < _memory.Length - 1))
            {
                command = GetNextCommand();
                ExecuteCommand(command);
            }
        }

        private IntcodeComputerCommand GetNextCommand()
        {
           int opCodeValue = _memory[_PC];

           int opCode = opCodeValue % 100;

           var command = new IntcodeComputerCommand();
            command.OpCode = (IntcodeCompunterCommandOpCode)opCode;


            switch(command.OpCode)
            {
                case IntcodeCompunterCommandOpCode.Add:
                case IntcodeCompunterCommandOpCode.Multiply: 
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (IntcodeComputerCommandParameterMode)((opCodeValue/1000) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 3],  IntcodeComputerCommandParameterMode.Position)
                    };
                    break;
                case IntcodeCompunterCommandOpCode.Input: 
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], IntcodeComputerCommandParameterMode.Immediate)
                    };
                    break;
                case IntcodeCompunterCommandOpCode.Output: 
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], IntcodeComputerCommandParameterMode.Immediate)
                    };
                    break;
            }


            return command;


        }

        private void ExecuteCommand(IntcodeComputerCommand command)
        {
            int param1Value, param2Value;

            switch (command.OpCode)
            {
                case IntcodeCompunterCommandOpCode.Add:

                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = param1Value + param1Value;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Multiply:
                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = param1Value * param2Value;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Input:
                    Console.WriteLine("Input: ");
                    string input = Console.ReadLine();
                    param1Value = GetParamValue(command.Parameters[0]);
                    _memory[param1Value] = int.Parse(input);
                    _PC += 2;

                    break;
                case IntcodeCompunterCommandOpCode.Output:
                    param1Value = GetParamValue(command.Parameters[0]);
                    Console.WriteLine($"Output: {_memory[param1Value]}");
                    _PC += 2;
                    break;
            }

        }

        private int GetParamValue(IntcodeComputerCommandParameter parameter)
        {
            if (parameter.Mode == IntcodeComputerCommandParameterMode.Immediate)
            {
                return parameter.Value;
            }
            else
            {
                return _memory[parameter.Value];
            }
        }

     
        public int GetOutput()
        {
            return _memory[0];
        }
    }
}
