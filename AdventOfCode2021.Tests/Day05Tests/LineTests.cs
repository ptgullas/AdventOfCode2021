using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day05;
using AdventOfCode2021.Shared;
using Xunit;


namespace AdventOfCode2021.Tests.Day05Tests {
    public class LineTests {

        [Fact]
        public void Constructor_InputLine_Passes() {
            string inputStr = "737,915 -> 737,235";
            int expectedFirstCoordinateX = 737;
            int expectedFirstCoordinateY = 915;
            int expectedSecondCoordinateX = 737;
            int expectedSecondCoordinateY = 235;

            
            Line line = new(inputStr);

            Assert.Equal(expectedFirstCoordinateX, line.Coordinates[0].X);
            Assert.Equal(expectedFirstCoordinateY, line.Coordinates[0].Y);
            Assert.Equal(expectedSecondCoordinateX, line.Coordinates[1].X);
            Assert.Equal(expectedSecondCoordinateY, line.Coordinates[1].Y);
        }
    }
}
