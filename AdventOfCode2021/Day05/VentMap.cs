using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public class VentMap {
        public List<Coordinate> Vents { get; set; }
        public List<Coordinate> DangerousVents { get; set; }
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
                if (l.IsHorizontalOrVertical()) {
                    var points = l.GetPointsCovered();
                    Console.WriteLine($"line {l} has {points.Count} points");
                    AddVents(points);
                }
            }
        }
        /*
        public void AddVent(Coordinate coordinate) {
            var existingVent = Vents.FirstOrDefault(v => v.Coordinate == coordinate);
            if (existingVent is not null) { 
                existingVent.Increment();
                // Console.WriteLine($"Incremented existing vent at {existingVent.Coordinate.X}, {existingVent.Coordinate.Y}");
            }
            else { 
                Vents.Add(new Vent(coordinate));
                // Console.WriteLine($"Added new vent at {coordinate.X}, {coordinate.Y}");
            }
            // Console.WriteLine($"Vent count is at {Vents.Count}");
        }
        */

        public void AddVent(Coordinate coordinate) {
            if (DangerousVents.Contains(coordinate)) { }
            else if (Vents.Contains(coordinate)) { DangerousVents.Add(coordinate); }
            else { Vents.Add(coordinate); }
        }
        public void AddVents(List<Coordinate> coordinates) {
            foreach (Coordinate c in coordinates) {
                AddVent(c);
            }
        }

        public int FindDangerousPointCount() {
            return DangerousVents.Count;
            // return Vents.Where(v => v.Frequency > 1).Count();
        }
    }
}
