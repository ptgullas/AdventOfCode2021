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

        [Fact]
        public void GetPointsCovered_Horizontal_Passes() {
            string inputStr = "1,1 -> 1,3";
            int expectedPointCount = 3;
            Coordinate expectedPoint1 = new(1, 1);
            Coordinate expectedPoint2 = new(1, 2);
            Coordinate expectedPoint3 = new(1, 3);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Coordinate>(expectedPoint1, points);
            Assert.Contains<Coordinate>(expectedPoint2, points);
            Assert.Contains<Coordinate>(expectedPoint3, points);

        }

        [Fact]
        public void GetPointsCovered_Vertical_Passes() {
            string inputStr = "9,7 -> 7,7";
            int expectedPointCount = 3;
            Coordinate expectedPoint1 = new(9, 7);
            Coordinate expectedPoint2 = new(8, 7);
            Coordinate expectedPoint3 = new(7, 7);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Coordinate>(expectedPoint1, points);
            Assert.Contains<Coordinate>(expectedPoint2, points);
            Assert.Contains<Coordinate>(expectedPoint3, points);
        }

        [Fact]
        public void GetPointsCovered_Diagonal_Passes() {
            string inputStr = "6,4 -> 2,0";
            int expectedPointCount = 5;
            Coordinate expectedPoint1 = new(2, 0);
            Coordinate expectedPoint2 = new(3, 1);
            Coordinate expectedPoint3 = new(4, 2);
            Coordinate expectedPoint4 = new(5, 3);
            Coordinate expectedPoint5 = new(6, 4);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Coordinate>(expectedPoint1, points);
            Assert.Contains<Coordinate>(expectedPoint2, points);
            Assert.Contains<Coordinate>(expectedPoint3, points);
            Assert.Contains<Coordinate>(expectedPoint4, points);
            Assert.Contains<Coordinate>(expectedPoint5, points);
        }
    }
}
