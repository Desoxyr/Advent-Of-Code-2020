using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_7
{
    public class BagCollection
    {
        private readonly List<Bag> _bags = new List<Bag>();

        public List<Bag> Parse(string[] input)
        {
            foreach (var line in input)
            {
                var instruction = RemoveUnnecessaryParts(line);
                var holderString = instruction.Split(" contain ");
                var contentString = holderString[1].Split(", ");
                var contents = CreateContents(contentString);
                AddBag(holderString[0], contents);
            }

            return _bags;
        }

        private void AddBag(string bagColor, Dictionary<Bag, int> contents)
        {
            Bag bag = _bags.FirstOrDefault(b => b.Color == bagColor);
            if (bag == null)
            {
                bag = new Bag(bagColor);
                _bags.Add(bag);
            }

            foreach (var content in contents)
            {
                bag.Contents[content.Key] = content.Value;
            }
        }

        private string RemoveUnnecessaryParts(string line)
        {
            var instruction = line.Replace(".", String.Empty);
            instruction = instruction.Replace(" bags", String.Empty);
            instruction = instruction.Replace(" bag", String.Empty);
            return instruction;
        }

        private Dictionary<Bag, int> CreateContents(string[] bags)
        {
            Dictionary<Bag, int> continents = new Dictionary<Bag, int>();
            foreach (var continent in bags)
            {
                
                
                if (!int.TryParse(continent.Split(" ")[0], out var amount)) break;
                
                var bagColor = continent.Substring(2);

                Bag bag = null;
                if (_bags.Any(b => b.Color == bagColor)) 
                    bag = _bags.First(b => b.Color == bagColor);
                if (bag == null)
                {
                    bag = new Bag(bagColor);
                    _bags.Add(bag);
                }

                continents[bag] = amount;
            }

            return continents;
        }
    }
}