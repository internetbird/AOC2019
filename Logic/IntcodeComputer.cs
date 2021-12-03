using System;
using System.Collections.Generic;
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

            while (opCode != 99 && (_PC < _memory.Length - 3))
            {
                ExecuteCommand(_memory[_PC], _memory[_PC + 1], _memory[_PC + 2], _memory[_PC + 3]);
                _PC = _PC + 4;
            }
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
            }
        }

     
        public int GetOutput()
        {
            return _memory[0];
        }
    }
}
