using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021 {
    class Program {
        static void Main(string[] args) {
            // Day01();
            // Day02.AdventDay02.Run();
            // Day03.AdventDay03.Run();
            // Day04.AdventDay04.Run();
            Day05.AdventDay05.Run();
        }

        private static void Day01() {
            string filePath = @"..\AdventOfCode2021\input\day1_input_depths.txt";
            if (!File.Exists(filePath)) { throw new FileNotFoundException($"Could not find inputfile {filePath}"); }
            var depths = ReadFileAsIntList(filePath);
            int increaseCount = Day01_CountMeasurements(depths);
            Console.WriteLine($"There are {increaseCount} measurements larger than the previous measurements.");

            int sumIncreaseCount = Day01_CountMeasurementsSumInWindow(depths);
            Console.WriteLine($"There are {sumIncreaseCount} sums larger than the previous sum");
        }
        private static List<int> ReadFileAsIntList(string filePath) {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<int> intLines = new List<int>();
            foreach (string line in lines) {
                int depth = int.Parse(line);
                intLines.Add(depth);
            }
            return intLines;
        }

        private static int Day01_CountMeasurements(List<int> depths) {
            int previousDepth = depths[0];
            int increaseCount = 0;
            foreach (int depth in depths) {
                if (depth > previousDepth) { increaseCount++; }
                previousDepth = depth;
                Console.WriteLine($"current depth: {depth}. increaseCount is {increaseCount}");
            }
            return increaseCount;
        }

        private static int Day01_CountMeasurementsSumInWindow(List<int> depths) {
            int previousSum = depths[0] + depths[1] + depths[2];
            int sumIncreaseCount = 0;
            for (int i = 0; i < depths.Count - 2; i++) {
                int currentSum = depths[i] + depths[i + 1] + depths[i + 2];
                // Console.WriteLine($"{depths[i]} + {depths[i + 1]} + {depths[i + 2]} = {currentSum};");
                if (currentSum > previousSum) { sumIncreaseCount++; }
                previousSum = currentSum;
            }
            return sumIncreaseCount;
        }
    }
}
