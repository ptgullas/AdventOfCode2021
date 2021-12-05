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

        public void AddVent(Point point) {
            // if it's already in DangerousVents, do nothing
            if (DangerousVents.TryGetValue((point.X, point.Y), out Point _)) { }
            // else if it's already in Vents, add to DangerousVents
            else if (Vents.TryGetValue((point.X, point.Y), out Point _)) { DangerousVents.Add((point.X, point.Y), point); }
            // else add to Vents
            else { Vents.Add((point.X, point.Y), point); }
        }

        public void AddVents(List<Point> points) {
            foreach (Point p in points) {
                AddVent(p);
            }
        }

        public int FindDangerousPointCount() {
            return DangerousVents.Count;
        }

        public int FindTotalPointCount() {
            return Vents.Count;
        }
    }
}
