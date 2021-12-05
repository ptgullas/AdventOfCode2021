using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day04;
using AdventOfCode2021.Shared;
using Xunit;

namespace AdventOfCode2021.Tests.Day04Tests {
    public class BingoCardTests {
        public static List<string> GetSampleData() {
            string filePath = @"..\..\..\..\AdventOfCode2021\input\day04_input_test.txt";
            return AdventUtils.ReadFileAsStringList(filePath);
        }

        [Fact]
        public void Constructor_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            int expectedGridSize = 5;
            int expectedFirstBingoNumber = 22;
            int expectedLastBingoNumber = 19;

            BingoCard bingoCard = new(sampleCard);
            var resultGridSize = bingoCard.Grid.Count;
            var resultFirstNumber = bingoCard.Grid[0][0].Number;
            var resultLastNumber = bingoCard.Grid[4][4].Number;

            Assert.Equal(expectedGridSize, resultGridSize);
            Assert.Equal(expectedFirstBingoNumber, resultFirstNumber);
            Assert.Equal(expectedLastBingoNumber, resultLastNumber);
        }

        [Fact]
        public void MarkNumber_CardContainsNumber_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = true;
            int numToCheck = 14;

            BingoCard bingoCard = new(sampleCard);
            var result = bingoCard.MarkNumber(numToCheck);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MarkNumber_CardDoesNotContainNumber_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = false;
            int numToCheck = 69;

            BingoCard bingoCard = new(sampleCard);
            var result = bingoCard.MarkNumber(numToCheck);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasBingo_CardRowContainsBingo_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = true;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.MarkNumber(21);
            bingoCard.MarkNumber(9);
            bingoCard.MarkNumber(14);
            bingoCard.MarkNumber(16);
            bingoCard.MarkNumber(7);

            var result = bingoCard.HasBingo();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasBingo_CardRowDoesNotContainBingo_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = false;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.MarkNumber(21);
            bingoCard.MarkNumber(9);
            bingoCard.MarkNumber(14);
            bingoCard.MarkNumber(16);
            bingoCard.MarkNumber(8);

            var result = bingoCard.HasBingo();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasBingo_ColumnDoesNotContainBingo_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = false;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.MarkNumber(11);
            bingoCard.MarkNumber(4);
            bingoCard.MarkNumber(16);
            bingoCard.MarkNumber(18);
            bingoCard.MarkNumber(8);

            var result = bingoCard.HasBingo();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasBingo_ColumnContainsBingo_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(2, 5);
            bool expected = true;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.MarkNumber(11);
            bingoCard.MarkNumber(4);
            bingoCard.MarkNumber(16);
            bingoCard.MarkNumber(18);
            bingoCard.MarkNumber(15);

            var result = bingoCard.HasBingo();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCardScore_NoNumbersMarked_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(14, 5);
            int expected = 325;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.WinningMultiplier = 1;
            var result = bingoCard.GetCardScore();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCardScore_NumbersMarked_Passes() {
            var data = GetSampleData();
            List<string> sampleCard = data.GetRange(14, 5);
            int expected = 4512;

            BingoCard bingoCard = new(sampleCard);
            bingoCard.MarkNumber(14);
            bingoCard.MarkNumber(21);
            bingoCard.MarkNumber(17);
            bingoCard.MarkNumber(24);
            bingoCard.MarkNumber(4);

            bingoCard.MarkNumber(9);
            bingoCard.MarkNumber(23);
            bingoCard.MarkNumber(11);
            bingoCard.MarkNumber(5);
            bingoCard.MarkNumber(2);
            bingoCard.MarkNumber(0);
            bingoCard.MarkNumber(7);

            bingoCard.WinningMultiplier = 24;

            var result = bingoCard.GetCardScore();

            Assert.Equal(expected, result);
        }

    }
}
