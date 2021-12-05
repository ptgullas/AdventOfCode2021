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

        public override string ToString() {
            return $"{Coordinates[0].X}, {Coordinates[0].Y} -> {Coordinates[1].X}, {Coordinates[1].Y}";
        }

        public bool IsHorizontalOrVertical() {
            return IsHorizontal() || IsVertical();
        }

        public bool IsHorizontal() {
            return Coordinates[0].Y == Coordinates[1].Y;
        }

        public bool IsVertical() {
            return Coordinates[0].X == Coordinates[1].X;
        }

        public List<Coordinate> GetPointsCovered() {
            List<Coordinate> pointsCovered = new();
            if (IsHorizontal()) {
                int largerX = Math.Max(Coordinates[0].X, Coordinates[1].X);
                int smallerX = Math.Min(Coordinates[0].X, Coordinates[1].X);
                int Y = Coordinates[0].Y;
                for (int i = smallerX; i <= largerX; i++) {
                    Coordinate c = new(i, Y);
                    pointsCovered.Add(c);
                }
            }
            else if (IsVertical()) {
                int largerY = Math.Max(Coordinates[0].Y, Coordinates[1].Y);
                int smallerY = Math.Min(Coordinates[0].Y, Coordinates[1].Y);

                int X = Coordinates[0].X;
                for (int i = smallerY; i <= largerY; i++) {
                    Coordinate c = new(X, i);
                    pointsCovered.Add(c);
                }
            }
            else {
                // is Diagonal
                // we can pick X or Y, I'm picking Y
                int largerY = Math.Max(Coordinates[0].Y, Coordinates[1].Y);
                int smallerY = Math.Min(Coordinates[0].Y, Coordinates[1].Y);

                int x = Math.Min(Coordinates[0].X, Coordinates[1].X);
                for (int y = smallerY; y <= largerY; y++) {
                    Coordinate c = new(x, y);
                    pointsCovered.Add(c);
                    x++;
                }

            }
            return pointsCovered;
        }

    }
}
