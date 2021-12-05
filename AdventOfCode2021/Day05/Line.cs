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
            if (IsHorizontal()) { return GetPointsCoveredHorizontal(); }
            else if (IsVertical()) { return GetPointsCoveredVertical(); }
            else { return GetPointsCoveredDiagonal(); }
        }

        private List<Point> GetPointsCoveredHorizontal() {
            List<Point> pointsCovered = new();
            int largerX = Math.Max(Points[0].X, Points[1].X);
            int smallerX = Math.Min(Points[0].X, Points[1].X);
            int y = Points[0].Y;
            for (int i = smallerX; i <= largerX; i++) {
                Point p = new(i, y);
                pointsCovered.Add(p);
            }
            return pointsCovered;
        }

        private List<Point> GetPointsCoveredVertical() {
            List<Point> pointsCovered = new();
            int largerY = Math.Max(Points[0].Y, Points[1].Y);
            int smallerY = Math.Min(Points[0].Y, Points[1].Y);
            int x = Points[0].X;
            for (int i = smallerY; i <= largerY; i++) {
                Point p = new(x, i);
                pointsCovered.Add(p);
            }
            return pointsCovered;
        }

        private List<Point> GetPointsCoveredDiagonal() {
            List<Point> pointsCovered = new();

            // Pick a point to start on: we can start w/either the smaller X or Y
            // I'm choosing Y: move from Point1 (w/smaller Y) to Point2 (w/larger Y).
            (var pointSmallerY, var pointLargerY) = GetPointsInYOrder();

            int smallerY = pointSmallerY.Y;
            int largerY = pointLargerY.Y;

            // x is either incremented or decremented depending on the relative x 
            // values of Point1 and Point2
            int x1 = pointSmallerY.X;
            int x2 = pointLargerY.X;
            int x = x1;

            for (int y = smallerY; y <= largerY; y++) {
                Point p = new(x, y);
                pointsCovered.Add(p);
                if (x2 > x1) { x++; }
                else { x--; }
            }
            return pointsCovered;
        }

        private (Point, Point) GetPointsInYOrder() {
            if (Points[0].Y < Points[1].Y) { return (Points[0], Points[1]); }
            else { return (Points[1], Points[0]);  }
        }
    }
}
