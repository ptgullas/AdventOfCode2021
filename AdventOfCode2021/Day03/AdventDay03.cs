using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03 {
    public static class AdventDay03 {
        public static void Run() {
            string filePath = @"..\AdventOfCode2021\input\day03_input.txt";
            var binaryList = ReadFileAsStringList(filePath);

            DiagnosticReader.BinaryList = binaryList;
            int powerConsumption = DiagnosticReader.Calculate();
            Console.WriteLine($"Power consumption is {powerConsumption}");

            int lifeSupportRating = DiagnosticReader.CalculateLifeSupportRating();
            Console.WriteLine($"Life Support rating is {lifeSupportRating}");
        }
        private static List<string> ReadFileAsStringList(string filePath) {
            if (!File.Exists(filePath)) { throw new FileNotFoundException($"Could not find inputfile {filePath}"); }
            List<string> lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }

    }
}
