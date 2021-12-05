using AdventOfCode2021.Day03;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2021.Tests {
    public class DiagnosticReaderTests {
        public List<string> SampleData = new() {"00100","11110", "10110", "10111", "10101","01111","00111","11100","10000","11001","00010","01010"};
        [Fact]
        public void Calculate_ValidData_Passes() {
            // Arrange
            DiagnosticReader.BinaryList = SampleData;
            int expected = 198;
            // Act
            var result = DiagnosticReader.Calculate();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindRating_ValidData_Passes() {
            // Arrange
            DiagnosticReader.BinaryList = SampleData;
            int expected = 230;
            // Act
            var result = DiagnosticReader.CalculateLifeSupportRating();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindOxygenGeneratorRating_ValidData_Passes() {
            // Arrange
            DiagnosticReader.BinaryList = SampleData;
            int expected = 23;
            // Act
            var result = DiagnosticReader.FindRating(Rating.OxygenGenerator);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindCO2ScrubberRating_ValidData_Passes() {
            // Arrange
            DiagnosticReader.BinaryList = SampleData;
            int expected = 10;
            // Act
            var result = DiagnosticReader.FindRating(Rating.CO2Scrubber);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
