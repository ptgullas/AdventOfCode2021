using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day05;
using AdventOfCode2021.Shared;
using Xunit;


namespace AdventOfCode2021.Tests.Day05Tests {
    public class VentMapTests {

        public static List<string> GetSampleData() {
            string filePath = @"..\..\..\..\AdventOfCode2021\input\day05_input_test.txt";
            return AdventUtils.ReadFileAsStringList(filePath);
        }

        [Fact]
        public static void FindDangerousPointCount_Passes() {
            var strings = GetSampleData();
            int expectedDangerousPointCount = 12; 
            List<Line> lines = new();
            foreach (string str in strings) {
                lines.Add(new Line(str));
            }

            VentMap ventMap = new(lines);

            var result = ventMap.FindDangerousPointCount();
            Assert.Equal(expectedDangerousPointCount, result);
        }

    }
}
