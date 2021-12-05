using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class VentMap {
        public Dictionary<(int,int), Point> Vents { get; set; }
        public Dictionary<(int,int), Point> DangerousVents { get; set; }

        public VentMap() {
            Vents = new();
            DangerousVents = new();
        }

        public void AddVentsFromLines(List<Line> lines) {
            foreach (Line l in lines) {
                var points = l.GetPointsCovered();
                Console.WriteLine($"line {l} has {points.Count} points");
                AddVents(points);
            }
        }



        public void AddVent(Point coordinate) {
            // if it's already in DangerousVents, do nothing
            if (DangerousVents.TryGetValue((coordinate.X, coordinate.Y), out Point _)) { }
            // else if it's already in Vents, add to DangerousVents
            else if (Vents.TryGetValue((coordinate.X, coordinate.Y), out Point _)) { DangerousVents.Add((coordinate.X, coordinate.Y), coordinate); }
            // else add to Vents
            else { Vents.Add((coordinate.X, coordinate.Y), coordinate); }
        }

        public void AddVents(List<Point> coordinates) {
            foreach (Point c in coordinates) {
                AddVent(c);
            }
        }

        public int FindDangerousPointCount() {
            return DangerousVents.Count;
        }
    }
}
