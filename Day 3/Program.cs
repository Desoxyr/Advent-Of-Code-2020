using System;
using System.IO;
using System.Numerics;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            var grid = ParseToGrid(input);
            
            Console.WriteLine($"Part 1 {Part1(grid)}");
            Console.WriteLine($"Part 2 {Part2(grid)}");
        }


        private static int Part1(bool[,] grid)
        {
            return CountEncounteredTrees(grid,3,1);
        }

        private static long Part2(bool[,] grid)
        {
            long answer = CountEncounteredTrees(grid, 1, 1);
            answer *= CountEncounteredTrees(grid, 3, 1);
            answer *= CountEncounteredTrees(grid, 5, 1);
            answer *= CountEncounteredTrees(grid, 7, 1);
            answer *= CountEncounteredTrees(grid, 1, 2);
            
            return answer;
        }
        
        private static bool[,] ParseToGrid(string[] input)
        {
            bool[,] grid = new bool[input[0].Length,input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    grid[j, i] = character == '#';
                }
            }

            return grid;
        }

        private static int CountEncounteredTrees(bool[,] grid, int right, int down)
        {
            var amountOfTrees = 0;
            var x = 0;

            var height = grid.GetLength(1);
            var width = grid.GetLength(0);
            
            
            for (int y = 0; y < height;)
            {
                if (grid[x, y])
                    amountOfTrees++;
                y += down;
                x += right;
                if (x > width - 1) 
                {
                    x -= width;
                }
            }
            
            return amountOfTrees;
        }
    }
}