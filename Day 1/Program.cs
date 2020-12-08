using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            var numbers = input.Select(Int32.Parse).ToList();


            var part1 = Part1(numbers);
            Console.WriteLine($"Numbers: {part1[0]} {part1[1]}");
            Console.WriteLine($"Answer: {part1[0] * part1[1]}");

            var part2 = Part2(numbers);
            Console.WriteLine($"Numbers: {part2[0]} {part2[1]} {part2[2]}");
            Console.WriteLine($"Answer: {part2[0] * part2[1] * part2[2]}");
        }


        private static int[] Part1(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (2020 - numbers[i] == numbers[j])
                    {
                        return new[] {numbers[i], numbers[j]};
                    }
                }
            }
            return new int[2];
        }

        private static int[] Part2(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        if (2020 - numbers[i] - numbers[j] == numbers[k])
                        {
                            return new[] {numbers[i], numbers[j], numbers[k]};
                        }
                    }
                }
            }

            return new int[3];
        }
    }
}