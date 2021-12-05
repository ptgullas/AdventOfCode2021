using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class Line {
        public Coordinate[] Coordinates { get; set; }

        public Line(Coordinate c1, Coordinate c2) {
            Coordinates = new Coordinate[2] { c1, c2 };
        }

        public Line(string inputString) {
            var hyphenPos = inputString.IndexOf('-');
            Coordinate c1 = new(inputString.Substring(0, hyphenPos - 1));
            Coordinate c2 = new(inputString.Substring(hyphenPos + 3));
            Coordinates = new Coordinate[2] { c1, c2 };
        }

        public bool IsHorizontalOrVertical() {
            return IsHorizontal() || IsVertical();
        }

        public bool IsHorizontal() {
            return Coordinates[0].X == Coordinates[1].X;
        }

        public bool IsVertical() {
            return Coordinates[0].Y == Coordinates[1].Y;
        }

    }
}
