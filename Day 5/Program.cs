using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Day_5
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
            int highestSeatId = 0;
            foreach (var line in input)
            {
                var numbers = ParseToRowColumn(line);
                var seatID = CalculateSeatId(numbers[0], numbers[1]);
                if (seatID > highestSeatId)
                    highestSeatId = seatID;
            }
            Console.WriteLine(highestSeatId);
        }

        private static void Part2(string[] input)
        {
            HashSet<int> seatIds = new HashSet<int>();
            foreach (var line in input)
            {
                var numbers = ParseToRowColumn(line);
                var seatId = CalculateSeatId(numbers[0], numbers[1]);
                seatIds.Add(seatId);
            }
            Console.WriteLine(FindSeatId(seatIds));
        }

        private static int FindSeatId(HashSet<int> seatIds)
        {
            int min = seatIds.Min();
            int max = seatIds.Max();
            var outcome = Enumerable.Range(min, max).Except(seatIds);
            return outcome.First();
        }
        
        private static int CalculateSeatId(int row, int column)
        {
            return row * 8 + column;
        }
        
        private static int[] ParseToRowColumn(string s)
        {
            string binaryRow = s.Substring(0, 7);
            string binaryColumn = s.Substring(7, 3);
            return new[] {ParseToNumber(binaryRow),ParseToNumber(binaryColumn)};
        }
        
        private static int ParseToNumber(string s)
        {
            s = s.Replace('F', '0');
            s = s.Replace('B', '1');
            s = s.Replace('L', '0');
            s = s.Replace('R', '1');
            return Convert.ToInt32(s, 2);
        }
    }
}