using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day04;
using AdventOfCode2021.Shared;
using Xunit;


namespace AdventOfCode2021.Tests.Day04Tests {
    public class BingoCardFactoryTests {
        public static List<string> GetSampleData() {
            string filePath = @"..\..\..\..\AdventOfCode2021\input\day04_input_test.txt";
            return AdventUtils.ReadFileAsStringList(filePath);
        }


        [Fact]
        public void CreateBingoCards_Passes() {
            // Arrange
            var sampleData = GetSampleData();
            sampleData.RemoveRange(0, 1);
            int expectedCount = 3;
            int expectedFirstCardFirstNumber = 22;
            int expectedFirstCardLastNumber = 19;
            int expectedLastCardFirstNumber = 14;
            int expectedLastCardLastNumber = 7;

            // Act
            var bingoCards = BingoCardFactory.CreateBingoCards(sampleData);
            var firstCard = bingoCards.First();
            var lastCard = bingoCards.Last();

            // Assert
            Assert.Equal(expectedCount, bingoCards.Count);
            Assert.Equal(expectedFirstCardFirstNumber, firstCard.Grid[0][0].Number);
            Assert.Equal(expectedFirstCardLastNumber, firstCard.Grid[4][4].Number);
            Assert.Equal(expectedLastCardFirstNumber, lastCard.Grid[0][0].Number);
            Assert.Equal(expectedLastCardLastNumber, lastCard.Grid[4][4].Number);
        }
    }
}
