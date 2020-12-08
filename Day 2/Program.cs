using System;
using System.IO;
using System.Linq;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            Console.WriteLine($"Part 1 {Part1(input)}");
            Console.WriteLine($"Part 2 {Part2(input)}");
        }

        private static int Part1(string[] input)
        {
            int validPasswords = 0;

            foreach (var line in input)
            {
                var parsed = Parse(line);

                var minimum = int.Parse(parsed[0]);
                var maximum = int.Parse(parsed[1]);
                char letter = Convert.ToChar(parsed[2]);
                string password = parsed[3];

                var count = password.Count(x => x == letter);
                if (count >= minimum && count <= maximum)
                    validPasswords++;

            }
            return validPasswords;
        }

        private static int Part2(string[] input)
        {
            int validPasswords = 0;

            foreach (var line in input)
            {
                var parsed = Parse(line);
                var pos1 = int.Parse(parsed[0]);
                var pos2 = int.Parse(parsed[1]);
                char letter = Convert.ToChar(parsed[2]);
                string password = parsed[3];
                
                if (password.Length >= pos1)
                {
                    if (password[pos1 - 1] == letter ^ password[pos2 - 1] == letter)
                    {
                        validPasswords++;
                    }
                }
            }
            return validPasswords;
        }

        private static string[] Parse(string input)
        {
            var parts = input.Split(' ','-',':');
            var minimum = parts[0];
            var maximum = parts[1];
            var letter = parts[2];
            var password = parts[4];
            return new[]{minimum,maximum,letter,password};
        }
    }
}