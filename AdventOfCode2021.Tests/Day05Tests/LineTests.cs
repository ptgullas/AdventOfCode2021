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
            int expectedFirstPointX = 737;
            int expectedFirstPointY = 915;
            int expectedSecondPointX = 737;
            int expectedSecondPointY = 235;

            
            Line line = new(inputStr);

            Assert.Equal(expectedFirstPointX, line.Points[0].X);
            Assert.Equal(expectedFirstPointY, line.Points[0].Y);
            Assert.Equal(expectedSecondPointX, line.Points[1].X);
            Assert.Equal(expectedSecondPointY, line.Points[1].Y);
        }

        [Fact]
        public void GetPointsCovered_Horizontal_Passes() {
            string inputStr = "1,1 -> 1,3";
            int expectedPointCount = 3;
            Point expectedPoint1 = new(1, 1);
            Point expectedPoint2 = new(1, 2);
            Point expectedPoint3 = new(1, 3);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Point>(expectedPoint1, points);
            Assert.Contains<Point>(expectedPoint2, points);
            Assert.Contains<Point>(expectedPoint3, points);

        }

        [Fact]
        public void GetPointsCovered_Vertical_Passes() {
            string inputStr = "9,7 -> 7,7";
            int expectedPointCount = 3;
            Point expectedPoint1 = new(9, 7);
            Point expectedPoint2 = new(8, 7);
            Point expectedPoint3 = new(7, 7);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Point>(expectedPoint1, points);
            Assert.Contains<Point>(expectedPoint2, points);
            Assert.Contains<Point>(expectedPoint3, points);
        }

        [Fact]
        public void GetPointsCovered_Diagonal_Passes() {
            string inputStr = "6,4 -> 2,0";
            int expectedPointCount = 5;
            Point expectedPoint1 = new(2, 0);
            Point expectedPoint2 = new(3, 1);
            Point expectedPoint3 = new(4, 2);
            Point expectedPoint4 = new(5, 3);
            Point expectedPoint5 = new(6, 4);


            Line line = new(inputStr);
            var points = line.GetPointsCovered();

            Assert.Equal(expectedPointCount, points.Count);
            Assert.Contains<Point>(expectedPoint1, points);
            Assert.Contains<Point>(expectedPoint2, points);
            Assert.Contains<Point>(expectedPoint3, points);
            Assert.Contains<Point>(expectedPoint4, points);
            Assert.Contains<Point>(expectedPoint5, points);
        }
    }
}
