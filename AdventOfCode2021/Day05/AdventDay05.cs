using AdventOfCode2021.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05 {
    public static class AdventDay05 {
        public static void Run() {
            string filePath = @"..\AdventOfCode2021\input\day05_input.txt";
            var inputStrings = AdventUtils.ReadFileAsStringList(filePath);
            List<Line> lines = new();
            foreach (string str in inputStrings) {
                lines.Add(new Line(str));
            }
            Console.WriteLine("Creating ventMap");
            VentMap ventMap = new();

            ventMap.AddVentsFromLines(lines);

            int dangerousCount = ventMap.FindDangerousPointCount();
            Console.WriteLine($"There are {dangerousCount} dangerous points!");

        }
    }
}
