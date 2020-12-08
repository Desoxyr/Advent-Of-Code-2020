using System;
using System.Collections.Generic;
using System.IO;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            Computer computer = new Computer(input);
            var accumulator = computer.FindLoop();
            Console.WriteLine(accumulator.Item1);
        }

        private static void Part2(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var copy = new string[input.Length];
                input.CopyTo(copy,0);
                
                if (copy[i].Contains("acc")) continue;
                if (copy[i].Contains("jmp"))
                    copy[i] = copy[i].Replace("jmp", "nop");
                else if (copy[i] == "nop")
                    copy[i] = copy[i].Replace("nop", "jmp");

                Computer computer = new Computer(copy);
                var (accumulator, successful) = computer.FindLoop();
                if (successful)
                    Console.WriteLine(accumulator);
            }
        }
    }
}