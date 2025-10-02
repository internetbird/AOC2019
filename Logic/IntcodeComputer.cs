using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace AOC2019.Logic
{
    public class IntcodeComputer
    {
        private int[] _memory;
        private const int MemorySize = 1000;
        private int _PC;
        private Queue<int> _inputQueue = new Queue<int>();
        private bool _isSilentMode;


        public IntcodeComputer(bool isSilentMode = false)
        {
            _isSilentMode = isSilentMode;
            _PC = 0;
        }

        public void AddInput(int input)
        {
            _inputQueue.Enqueue(input);
        }

        public void LoadProgram(int[] program, int? noun = null, int? verb = null)
        {

            _memory = new int[MemorySize];

            program.CopyTo(_memory, 0);

            if (noun != null)
            {
                _memory[1] = noun.Value;
            }

            if (verb != null)
            {
                _memory[2] = verb.Value;
            }
        }

        public int? RunProgram()
        {
          
            IntcodeComputerCommand command = null;

            while (command?.OpCode != IntcodeCompunterCommandOpCode.Halt && (_PC < _memory.Length - 1))
            {
                command = GetNextCommand();
                int? output = ExecuteCommand(command);

                if (output != null && _isSilentMode)
                {
                    return output;
                }
            }

            return null;
        }

        private IntcodeComputerCommand GetNextCommand()
        {
            int opCodeValue = _memory[_PC];

            int opCode = opCodeValue % 100;

            var command = new IntcodeComputerCommand();
            command.OpCode = (IntcodeCompunterCommandOpCode)opCode;


            switch (command.OpCode)
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
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10))
                    };
                    break;
                case IntcodeCompunterCommandOpCode.JumpIfTrue:
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (IntcodeComputerCommandParameterMode)((opCodeValue/1000) % 10))
                    };
                    break;
                case IntcodeCompunterCommandOpCode.JumpIfFalse:
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (IntcodeComputerCommandParameterMode)((opCodeValue/1000) % 10))
                    };
                    break;
                case IntcodeCompunterCommandOpCode.LessThan:
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (IntcodeComputerCommandParameterMode)((opCodeValue/1000) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 3], (IntcodeComputerCommandParameterMode)((opCodeValue/10000) % 10))
                    };
                    break;

                case IntcodeCompunterCommandOpCode.Equals:
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (IntcodeComputerCommandParameterMode)((opCodeValue/100) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (IntcodeComputerCommandParameterMode)((opCodeValue/1000) % 10)),
                        new IntcodeComputerCommandParameter(_memory[_PC + 3], (IntcodeComputerCommandParameterMode)((opCodeValue/10000) % 10))
                    };
                    break;
            }


            return command;


        }

        private int? ExecuteCommand(IntcodeComputerCommand command)
        {
            int param1Value, param2Value;

            switch (command.OpCode)
            {
                case IntcodeCompunterCommandOpCode.Add:

                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = param1Value + param2Value;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Multiply:
                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = param1Value * param2Value;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Input:

                    string input;
                    if (!_isSilentMode)
                    {
                        Console.WriteLine("Input: ");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        if (_inputQueue.Count == 0)
                        {
                            throw new InvalidOperationException("No input available in silent mode.");
                        }
                        input = _inputQueue.Dequeue().ToString();
                    }

                    param1Value = GetParamValue(command.Parameters[0]);
                    _memory[param1Value] = int.Parse(input);
                    _PC += 2;

                    break;
                case IntcodeCompunterCommandOpCode.Output:
                    param1Value = GetParamValue(command.Parameters[0]);

                    if (!_isSilentMode)
                    {
                        Console.WriteLine($"Output: {param1Value}");
                        _PC += 2;
                    }
                    else
                    {
                        _PC += 2;
                        return param1Value;
                    }

                    break;
                case IntcodeCompunterCommandOpCode.JumpIfTrue:
                    param1Value = GetParamValue(command.Parameters[0]);
                    if (param1Value != 0)
                    {
                        _PC = GetParamValue(command.Parameters[1]);
                    }
                    else
                    {
                        _PC += 3;
                    }
                    break;
                case IntcodeCompunterCommandOpCode.JumpIfFalse:
                    param1Value = GetParamValue(command.Parameters[0]);
                    if (param1Value == 0)
                    {
                        _PC = GetParamValue(command.Parameters[1]);
                    }
                    else
                    {
                        _PC += 3;
                    }
                    break;
                case IntcodeCompunterCommandOpCode.LessThan:
                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = (param1Value < param2Value) ? 1 : 0;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Equals:
                    param1Value = GetParamValue(command.Parameters[0]);
                    param2Value = GetParamValue(command.Parameters[1]);
                    _memory[command.Parameters[2].Value] = (param1Value == param2Value) ? 1 : 0;
                    _PC += 4;
                    break;
                case IntcodeCompunterCommandOpCode.Halt:
                    Console.WriteLine("Program halted.");
                    break;
                default:
                    throw new InvalidOperationException($"Unknown command: {command.OpCode}");
            }

            return null;

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

        public bool IsHalted()
        {
            return _memory[_PC] == (int)IntcodeCompunterCommandOpCode.Halt;
        }
    }
}
