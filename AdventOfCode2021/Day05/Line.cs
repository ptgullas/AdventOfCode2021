using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class Line {
        public Point[] Points { get; set; }

        public Line(Point p1, Point p2) {
            Points = new Point[2] { p1, p2 };
        }

        public Line(string inputString) {
            var hyphenPos = inputString.IndexOf('-');
            Point p1 = new(inputString.Substring(0, hyphenPos - 1));
            Point p2 = new(inputString[(hyphenPos + 3)..]);
            Points = new Point[2] { p1, p2 };
        }

        public override string ToString() {
            return $"{Points[0].X}, {Points[0].Y} -> {Points[1].X}, {Points[1].Y}";
        }

        public bool IsHorizontalOrVertical() {
            return IsHorizontal() || IsVertical();
        }

        public bool IsHorizontal() {
            return Points[0].Y == Points[1].Y;
        }

        public bool IsVertical() {
            return Points[0].X == Points[1].X;
        }

        public List<Point> GetPointsCovered() {
            List<Point> pointsCovered = new();
            if (IsHorizontal()) {
                int largerX = Math.Max(Points[0].X, Points[1].X);
                int smallerX = Math.Min(Points[0].X, Points[1].X);
                int Y = Points[0].Y;
                for (int i = smallerX; i <= largerX; i++) {
                    Point p = new(i, Y);
                    pointsCovered.Add(p);
                }
            }
            else if (IsVertical()) {
                int largerY = Math.Max(Points[0].Y, Points[1].Y);
                int smallerY = Math.Min(Points[0].Y, Points[1].Y);

                int X = Points[0].X;
                for (int i = smallerY; i <= largerY; i++) {
                    Point p = new(X, i);
                    pointsCovered.Add(p);
                }
            }
            else {
                // is Diagonal
                // we can pick X or Y, I'm picking Y

                (var pointSmallerY, var pointLargerY) = GetPointsInYOrder();

                int x1 = pointSmallerY.X;
                int x2 = pointLargerY.X;

                int smallerY = pointSmallerY.Y;
                int largerY = pointLargerY.Y;

                int x = x1;
                for (int y = smallerY; y <= largerY; y++) {
                    Point p = new(x, y);
                    pointsCovered.Add(p);
                    if (x2 > x1) { x++; }
                    else { x--; }
                }

            }
            return pointsCovered;
        }

        private (Point, Point) GetPointsInYOrder() {
            if (Points[0].Y < Points[1].Y) { return (Points[0], Points[1]); }
            else { return (Points[1], Points[0]);  }
        }
    }
}
