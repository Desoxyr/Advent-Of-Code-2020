using System;
using System.IO;
using System.Linq;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");
            var groupInput = input.Split(new[] {Environment.NewLine + Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries);
            
            Part1(groupInput);
            Part2(groupInput);
        }

        private static void Part1(string[] groupInput)
        {
            var sum = 0;
            foreach (var group in groupInput)
            {
                var oneLine = group.Replace(Environment.NewLine, "");
                var amount = oneLine.GroupBy(x => x).Count();
                sum += amount;
            }
            Console.WriteLine(sum);
        }

        private static void Part2(string[] groupInput)
        {
            var sum = 0;
            foreach (var group in groupInput)
            {
                var lines = group.Split('\n').Length;
                var oneLine = group.Replace(Environment.NewLine, "");
                var amount = oneLine.GroupBy(c => c).Count(c => c.Count() == lines);
                sum += amount;
            }
            Console.WriteLine(sum);
        }
    }
}