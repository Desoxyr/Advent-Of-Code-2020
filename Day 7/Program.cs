using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_7
{
    static class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");

            BagCollection bagCollection = new BagCollection();
            var bags = bagCollection.Parse(input);
            Part1(bags);
            Part2(bags);
        }

        private static void Part1(List<Bag> bagCollection)
        {
            var eligibleBags = new List<Bag>();
            Bag shinyGoldBag = bagCollection.First(b => b.Color == "shiny gold");
            var eligibleContentBags = new List<Bag> {shinyGoldBag};

            while (eligibleContentBags.Any())
            {
                List<Bag> newBags = new List<Bag>();

                foreach (var eligibleBag in eligibleContentBags)
                {
                    newBags = newBags.Concat(bagCollection.Where(b => b.Contents.ContainsKey(eligibleBag))).ToList();
                    eligibleBags = eligibleBags.Concat(newBags).ToList();
                }

                eligibleContentBags = newBags;
            }

            eligibleBags = eligibleBags.Distinct().ToList();
            Console.WriteLine(eligibleBags.Count);
        }

        private static void Part2(List<Bag> bagCollection)
        {
            Dictionary<Bag, int> eligibleBags = new Dictionary<Bag, int>();
            Bag shinyGoldBag = bagCollection.First(b => b.Color == "shiny gold");
            Dictionary<Bag, int> eligibleContentBags = new Dictionary<Bag, int> {{shinyGoldBag, 1}};

            while (eligibleContentBags.Any())
            {
                Dictionary<Bag, int> newBags = new Dictionary<Bag, int>();

                foreach (var bag in eligibleContentBags)
                {
                    foreach (var contentBag in bag.Key.Contents)
                    {
                        var amount = bag.Value * contentBag.Value;

                        newBags[contentBag.Key] = newBags.ContainsKey(contentBag.Key)
                            ? amount + newBags[contentBag.Key]
                            : amount;
                        
                        eligibleBags[contentBag.Key] = eligibleBags.ContainsKey(contentBag.Key)
                            ? amount + eligibleBags[contentBag.Key]
                            : amount;
                    }
                }

                eligibleContentBags = newBags;
            }

            Console.WriteLine(eligibleBags.Sum(x => x.Value));
        }
    }
}