using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class VentMap {
        public Dictionary<(int,int), Coordinate> Vents { get; set; }
        public Dictionary<(int, int), Coordinate> DangerousVents { get; set; }
        public List<Line> Lines { get; set; }

        public VentMap() {
            Vents = new();
            DangerousVents = new();
        }

        public VentMap(List<Line> lines) {
            Vents = new();
            DangerousVents = new();
            Lines = lines;
            foreach (Line l in lines) {
                var points = l.GetPointsCovered();
                Console.WriteLine($"line {l} has {points.Count} points");
                AddVents(points);
            }
        }

        public void AddVent(Coordinate coordinate) {
            if (DangerousVents.TryGetValue((coordinate.X, coordinate.Y), out Coordinate _)) { }
            else if (Vents.TryGetValue((coordinate.X, coordinate.Y), out Coordinate _)) { DangerousVents.Add((coordinate.X, coordinate.Y), coordinate); }
            else { Vents.Add((coordinate.X, coordinate.Y), coordinate); }
        }

        public void AddVents(List<Coordinate> coordinates) {
            foreach (Coordinate c in coordinates) {
                AddVent(c);
            }
        }

        public int FindDangerousPointCount() {
            return DangerousVents.Count;
        }
    }
}
