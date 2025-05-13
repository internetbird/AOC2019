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

        public void LoadProgram(int[] program, int noun, int verb)
        {

            _memory = new int[MemorySize];

            program.CopyTo(_memory, 0);

            _memory[1] = noun;
            _memory[2] = verb;  

        }

        public void RunProgram()
        {
            _PC = 0;
            int opCode = _memory[0];

            while (opCode != 99 && (_PC < _memory.Length - 1))
            {


                IntcodeComputerCommand command = GetNextCommand();

                ExecuteCommand(command);
                _PC = _PC + 4;
            }
        }

        private IntcodeComputerCommand GetNextCommand()
        {
           int opCodeValue = _memory[_PC];

           int opCode = opCodeValue % 100;

           var command = new IntcodeComputerCommand();
            command.OpCode = opCode;


            switch(opCode)
            {
                case 1: // Add
                case 2: // Multiply
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], (opCodeValue/100) % 10),
                        new IntcodeComputerCommandParameter(_memory[_PC + 2], (opCodeValue/1000) % 10),
                        new IntcodeComputerCommandParameter(_memory[_PC + 3], (opCodeValue/10000) % 10)
                    };
                    break;
                case 3: // Input
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], _memory[_PC + 1] % 1000)
                    };
                    break;
                case 4: // Output
                    command.Parameters = new List<IntcodeComputerCommandParameter>
                    {
                        new IntcodeComputerCommandParameter(_memory[_PC + 1], _memory[_PC + 1] % 1000)
                    };
                    break;
            }


            return command;


        }

        private void ExecuteCommand(IntcodeComputerCommand command)
        {
           
        }


        private void ExecuteCommand(int opCode, int param1, int param2, int param3)
        {
            int value1 = _memory[param1];
            int value2 = _memory[param2];

            switch(opCode)
            {
                case 1:// Add
                    _memory[param3] = value1 + value2;
                    break;
                case 2: //Multiply
                    _memory[param3] = value1 * value2;
                    break;
                case 3: // Input
                    Console.WriteLine("Input: ");
                    string input = Console.ReadLine();
                    _memory[param1] = int.Parse(input);
                    break;
                case 4: // Output
                    Console.WriteLine($"Output: {_memory[param1]}");
                    break;
            }
        }

     
        public int GetOutput()
        {
            return _memory[0];
        }
    }
}
