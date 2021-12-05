using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Shared {
    public static class AdventUtils {

        public static List<string> ReadFileAsStringList(string filePath) {
            if (!File.Exists(filePath)) { throw new FileNotFoundException($"Could not find inputfile {filePath}"); }
            List<string> lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }

    }
}
