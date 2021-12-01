using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Logic
{
    public class IntcodeComputer
    {
        private int[] _memory;
        private int _PC;

        public void LoadProgram(int[] program)
        {
            _memory = program;
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

        private void ExecuteCommand(int opCode, int operand1, int operand2, int operand3)
        {
            int value1 = _memory[operand1];
            int value2 = _memory[operand2];

            switch(opCode)
            {
                case 1:// Add
                    _memory[operand3] = value1 + value2;
                    break;
                case 2: //Multiply
                    _memory[operand3] = value1 * value2;
                    break;
            }
        }

        public int GetMemoryPosition(int position)
        {
            return _memory[position];
        }
    }
}
