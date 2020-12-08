using System;
using System.Collections.Generic;

namespace Day_8
{
    public class Computer
    {
        public int Accumulator { get; private set; }
        public string[] Instructions { get; set; }
        public int Pointer { get; private set; }
        
        public Computer(string[] instructions)
        {
            Accumulator = 0;
            Pointer = 0;
            Instructions = instructions;
        }

        public Tuple<int,bool> FindLoop()
        {
            List<int> indexes = new List<int>();
            
            while (Pointer < Instructions.Length)
            {
                if (indexes.Contains(Pointer))
                    return new Tuple<int, bool>(Accumulator, false);
                indexes.Add(Pointer);
                
                var parsed = Parse(Instructions[Pointer]);
                var number = int.Parse(parsed[1]);
                switch (parsed[0])
                {
                    case "acc":
                        ExecuteAcc(number);
                        break;
                    case "jmp":
                        ExecuteJump(number);
                        break;
                    case "nop":
                        ExecuteNop();
                        break;
                }
            }
            return new Tuple<int, bool>(Accumulator, true);
        }

        private void ExecuteAcc(int number)
        {
            Accumulator += number;
            Pointer++;
        }

        private void ExecuteJump(int number)
        {
            Pointer += number;
        }
        
        private void ExecuteNop()
        {
            Pointer++;
        }

        private static string[] Parse(string instruction)
        {
            return instruction.Split(" ");
        }
    }
}