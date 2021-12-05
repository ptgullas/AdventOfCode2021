using AdventOfCode2021.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04 {
    public static class AdventDay04 {
        public static void Run() {
            string filePath = @"..\AdventOfCode2021\input\day04_input.txt";

            var lines = AdventUtils.ReadFileAsStringList(filePath);

            BingoGame bingoGame = new(lines);
            bingoGame.Play();

            var firstWinner = bingoGame.WinningCards.FirstOrDefault();
            var lastWinner = bingoGame.WinningCards.LastOrDefault();

            Console.WriteLine($"First winner had a score of {firstWinner.GetCardScore()} when {firstWinner.WinningMultiplier} was called.");
            Console.WriteLine($"Last winner had a score of {lastWinner.GetCardScore()} when {lastWinner.WinningMultiplier} was called.");

        }



    }
}
