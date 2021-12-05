using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public record Point {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() {

        }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public Point(string x, string y): this(int.Parse(x), int.Parse(y)) {
        }

        public Point(string unsplitStringPair) {
            var splitPair = unsplitStringPair.Split(',');
            X = int.Parse(splitPair[0]);
            Y = int.Parse(splitPair[1]);
        }
    }
}
