using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03 {
    public enum Rating { OxygenGenerator, CO2Scrubber };
    public static class DiagnosticReader {

        public static List<string> BinaryList { get; set; }

        static DiagnosticReader() {
            BinaryList = new();
        }

        public static int Calculate() {
            int stringLength = BinaryList[0].Length;
            char[] gamma = new char[stringLength];
            char[] epsilon = new char[stringLength];

            for (int i = 0; i < stringLength; i++) {

                (int zeroCount, int oneCount) = CountBitsInPosition(i, BinaryList);

                if (zeroCount > oneCount) { 
                    gamma[i] = '0';
                    epsilon[i] = '1';
                } 
                else { 
                    gamma[i] = '1';
                    epsilon[i] = '0';
                }
            }
            string gammaString = new(gamma);
            string epsilonString = new(epsilon);
            Console.WriteLine($"Gamma is {gammaString}. Epsilon is {epsilonString}");
            int gammaDecimal = Convert.ToInt32(gammaString, 2);
            int epsilonDecimal = Convert.ToInt32(epsilonString, 2);
            return gammaDecimal * epsilonDecimal;
        }

        private static (int, int) CountBitsInPosition(int position, List<string> binaryList) {
            int zeroCount = 0;
            int oneCount = 0;
            foreach (string binary in binaryList) {
                if (binary[position] == '0') { zeroCount++; }
                else { oneCount++; }
            }
            return (zeroCount, oneCount);
        }

        public static int CalculateLifeSupportRating() {
            int oxygenGeneratorRating = (int) FindRating(Rating.OxygenGenerator);
            int co2ScrubbingRating = (int) FindRating(Rating.CO2Scrubber);
            return oxygenGeneratorRating * co2ScrubbingRating;
        }

        public static int? FindRating(Rating rating) {
            int stringLength = BinaryList[0].Length;
            List<string> filteredBinaryList = new(BinaryList);
            for (int i = 0; i < stringLength && filteredBinaryList.Count > 1; i++) {
                (int zeroCount, int oneCount) = CountBitsInPosition(i, filteredBinaryList);
                char filterChar = DetermineFilterChar(zeroCount, oneCount, rating);
                filteredBinaryList = FilterList(filterChar, i, filteredBinaryList);
            }
            if (filteredBinaryList.Count == 1) { 
                Console.WriteLine($"Rating for {rating}: {filteredBinaryList[0]};"); 
                return Convert.ToInt32(filteredBinaryList[0], 2); 
            }
            else { return null;  }
        }

        private static List<string> FilterList(char filterChar, int pos, List<string> workingList) {
            List<string> newList = new();
            foreach (string binary in workingList) {
                if (binary[pos] == filterChar) { newList.Add(binary); }
            }
            return newList;
        }

        private static char DetermineFilterChar(int zeroCount, int oneCount, Rating rating) {
            if (rating is Rating.OxygenGenerator) {
                if (zeroCount > oneCount) { return '0'; }
                else { return '1'; }
            }
            else {
                if (zeroCount > oneCount) { return '1'; }
                else { return '0'; }
            }

        }
    }
}
