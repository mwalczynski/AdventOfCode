using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Readers
{
    class TestReader : IInputReader
    {
        public string GetInput(int day)
        {
            return "aaa";
        }

        public string GetInput(int day, int task)
        {
            throw new NotImplementedException();
        }
    }
}
