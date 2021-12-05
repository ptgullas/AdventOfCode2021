using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day04;
using AdventOfCode2021.Shared;
using Xunit;


namespace AdventOfCode2021.Tests.Day04Tests {
    public class BingoGameTests {
        [Fact]
        public static List<string> GetSampleData() {
            string filePath = @"..\..\..\..\AdventOfCode2021\input\day04_input_test.txt";
            return AdventUtils.ReadFileAsStringList(filePath);
        }

        [Fact]
        public void Constructor_Passes() {
            // Arrange
            var sampleData = GetSampleData();

            int expectedFirstNumberDrawn = 7;
            int expectedLastNumberDrawn = 1;
            int expectedNumberOfCards = 3;

            BingoGame bingoGame = new(sampleData);
            int resultFirstNumberDrawn = bingoGame.NumbersDrawn.FirstOrDefault();
            int resultLastNumberDrawn = bingoGame.NumbersDrawn.LastOrDefault();

            int resultNumberOfCards = bingoGame.BingoCards.Count;

            Assert.Equal(expectedFirstNumberDrawn, resultFirstNumberDrawn);
            Assert.Equal(expectedLastNumberDrawn, resultLastNumberDrawn);
            Assert.Equal(expectedNumberOfCards, resultNumberOfCards);
        }

        [Fact]
        public void Play_Passes() {
            // Arrange
            var sampleData = GetSampleData();
            int expectedScoreOfFirstWinningCard = 4512;
            int expectedScoreOfLastWinningCard = 1924;

            BingoGame bingoGame = new(sampleData);
            bingoGame.Play();

            var winningCards = bingoGame.WinningCards;
            var firstWinner = winningCards.FirstOrDefault();
            var lastWinner = winningCards.LastOrDefault();
            Assert.Equal(expectedScoreOfFirstWinningCard, firstWinner.GetCardScore());
            Assert.Equal(expectedScoreOfLastWinningCard, lastWinner.GetCardScore());
        }
    }
}
