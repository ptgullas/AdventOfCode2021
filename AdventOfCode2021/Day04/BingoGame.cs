using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04 {
    public class BingoGame {
        public List<int> NumbersDrawn { get; set; }
        public List<BingoCard> BingoCards { get; set; }
        public List<BingoCard> WinningCards { get; set; }

        public BingoGame(List<string> lines) {
            WinningCards = new();

            string numbersDrawnStr = lines[0];
            NumbersDrawn = ConvertStringToNumbersDrawn(numbersDrawnStr);

            lines.RemoveRange(0, 1);
            BingoCards = BingoCardFactory.CreateBingoCards(lines);
        }

        private static List<int> ConvertStringToNumbersDrawn(string numbersDrawnStr) {
            List<string> strSplitList = numbersDrawnStr.Split(',').ToList();

            List<int> numList = new();
            foreach (string strNum in strSplitList) {
                numList.Add(int.Parse(strNum));
            }
            return numList;
        }

        public void Play() {
            foreach (int num in NumbersDrawn) {
                foreach (BingoCard card in BingoCards) {
                    if (!card.AlreadyWon) {
                        card.MarkNumber(num);
                        if (card.HasBingo()) {
                            card.WinningMultiplier = num;
                            // Console.WriteLine($"We have a winner with Number {num}!");
                            // Console.WriteLine($"Winning card score is {card.GetCardScore()}!");
                            card.SetAsWinner();
                            WinningCards.Add(card);
                        }
                    }
                }
            }
        }
    }
}
