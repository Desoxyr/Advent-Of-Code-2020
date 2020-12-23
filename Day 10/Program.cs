using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            var numbers = input.Select(int.Parse).ToList();
            numbers.Sort();
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            Part1(numbers);
            Part2(numbers);

            /*int[] cables = numbers.ToArray(); //array of numbers
            int device = cables.Max() + 3; //highest number + 3
            Dictionary<int, long> combinations = new Dictionary<int, long> { { 0, 1 } };  //first digit = 1 combination
            for (int endPoint = 1; endPoint <= device; endPoint++) // 
            {
                // Number of ways of getting to n is 0 if n doesn't exist else number of ways of getting to (n-3) + (n-2) + (n-1)
                if (cables.Contains(endPoint) || endPoint == device)
                {
                    long num = 0;
                    if (combinations.Keys.Contains(endPoint - 3)) num += combinations[endPoint - 3];
                    if (combinations.Keys.Contains(endPoint - 2)) num += combinations[endPoint - 2];
                    if (combinations.Keys.Contains(endPoint - 1)) num += combinations[endPoint - 1];
                    combinations.Add(endPoint, num);
                }
            }*/


            /*foreach (var value in combinations.Values)
            {
                Console.WriteLine(value);
            }*/

        }

        private static void Part1(List<int> numbers)
        {
            var oneJolts = 0;
            var threeJolts = 1;
            int tracker = 0;
            
            foreach (var number in numbers)
            {
                var difference = number - tracker;
                
                if (difference > 3)
                {
                   throw new Exception("Difference too large");
                }
                if (difference == 3)
                    threeJolts++;
                if (difference == 1)
                    oneJolts++;

                tracker = number;
            }
            
            Console.WriteLine(oneJolts * threeJolts);
        }

        private static void Part2(List<int> numbers)
        {
            Dictionary<int, BigInteger> routes = new Dictionary<int, BigInteger> {{0, 1}};

            for (int i = 1; i < numbers.Count; i++)
            {
                var number = numbers[i];
                //check for number -1, number -2, number -3 and add routes together
                BigInteger amountOfRoutes = 0;
                if (routes.Keys.Contains(number - 3))
                {
                    amountOfRoutes += routes[number - 3];
                }
                if (routes.Keys.Contains(number - 2))
                {
                    amountOfRoutes += routes[number - 2];
                }
                if (routes.Keys.Contains(number - 1))
                {
                    amountOfRoutes += routes[number - 1];
                }
                routes.Add(number,amountOfRoutes);
            }
            
            Console.WriteLine(routes.Last());
        }

        private static int GetLinkCount(List<int> numbers, int index)
        {
            var links = 0;
            for (int link = 1; link <= 3; link++)
            {
                if (index - link < 0) break;
                if (numbers[index] - numbers[index - link] > 3) break;
                links++;
            }
            return links;
        }

        private static BigInteger GetRoutes(BigInteger[] routes, int index, int links)
        {
            BigInteger amountOfRoutes = 0;
            for (int i = 1; i <= links; i++)
            {
                amountOfRoutes += routes[index - i];
            }

            return amountOfRoutes;
        }
    }
}