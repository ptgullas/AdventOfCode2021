using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02 {
    public static class AdventDay02 {

        public static void Run() {
            string filePath = @"..\AdventOfCode2021\input\day02_input_course.txt";
            var subCommands = ReadFileAsCommandList(filePath);

            Submarine.ReadCommands(subCommands);
            int finalProduct = Submarine.CalculateProduct();
            Console.WriteLine($"Final product is {finalProduct}.");
        }

        private static List<SubCommand> ReadFileAsCommandList(string filePath) {
            if (!File.Exists(filePath)) { throw new FileNotFoundException($"Could not find inputfile {filePath}"); }
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<SubCommand> subCommands = new();
            foreach (string line in lines) {
                SubCommand subCommand = new(line);
                subCommands.Add(subCommand);
            }
            return subCommands;
        }

    }
}
