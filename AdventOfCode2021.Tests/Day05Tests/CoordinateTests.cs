using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day05;
using AdventOfCode2021.Shared;
using Xunit;

namespace AdventOfCode2021.Tests.Day05Tests {
    public class CoordinateTests {

        [Fact]
        public void Constructor_UnsplitString_Passes() {
            string coordinatesUnsplit = "476,38";
            int expectedX = 476;
            int expectedY = 38;

            Coordinate coordinate = new(coordinatesUnsplit);

            Assert.Equal(expectedX, coordinate.X);
            Assert.Equal(expectedY, coordinate.Y);
        }
    }
}
