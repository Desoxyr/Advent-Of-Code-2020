using System.Collections.Generic;

namespace Day_7
{
    public class Bag
    {
        public string Color { get; set; }
        public readonly Dictionary<Bag,int> Contents = new Dictionary<Bag, int>();

        public Bag(string color)
        {
            Color = color;
        }
    }
}