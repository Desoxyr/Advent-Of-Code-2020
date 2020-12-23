using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            long[] numbers = Array.ConvertAll(input, long.Parse);

            Part1(numbers);
            Part2(numbers,138879426);
        }

        private static void Part1(long[] input)
        {
            for (int i = 25; i < input.Length; i++)
            {
                long sum = input[i];
                List<long> preamble = input.Skip(i - 25).Take(25).ToList();
                if (!FindIfSummable(preamble, sum))
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }

        private static void Part2(long[] input, int sum)
        {
            List<long> preamble = input.ToList();
            var answer = FindSequenceSum(preamble, sum);
            Console.WriteLine(answer);
        }

        private static long FindSequenceSum(List<long> numbers, int sum)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                List<long> sequence = new List<long>();
                var index = i;
                while (sequence.Sum() <= sum)
                {
                    sequence.Add(numbers[index]);
                    if (sequence.Sum() == sum)
                    {
                        return sequence.Min() + sequence.Max();
                    }
                    index++;
                }
            }
            
            return 0;
        }
        
        private static bool FindIfSummable(List<long> preamble, long sum)
        {
            while (preamble.Count > 1)
            {
                var digit = preamble[0];
                if (preamble.Contains(sum - digit) && sum - digit != sum) //Found two numbers equal to sum that aren't the same
                {
                    return true;
                }
                preamble.RemoveAt(0);
            }
            return false;
        }
    }
}