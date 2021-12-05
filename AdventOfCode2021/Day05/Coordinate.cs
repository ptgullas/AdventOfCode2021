using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class Coordinate {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y) {
            X = x;
            Y = y;
        }

        public Coordinate(string x, string y): this(int.Parse(x), int.Parse(y)) {
        }

        public Coordinate(string unsplitStringPair) {
            var splitPair = unsplitStringPair.Split(',');
            X = int.Parse(splitPair[0]);
            Y = int.Parse(splitPair[1]);
        }
    }
}
