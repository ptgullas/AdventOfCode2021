using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04 {
    public class BingoCard {
        public List<List<BingoNumber>> Grid { get; set; }
        public bool AlreadyWon { get; private set; }

        public int WinningMultiplier { get; set; }

        public BingoCard(List<string> strList) {
            AlreadyWon = false;
            Grid = new();
            WinningMultiplier = 1;
            foreach (string str in strList) {
                if (str.Length > 0) {
                    List<BingoNumber> row = StringToBingoNumberRow(str);
                    Grid.Add(row);
                }
            }
        }

        private static List<BingoNumber> StringToBingoNumberRow(string str) {
            var strSplit = str.Split();
            List<BingoNumber> bingoNumbers = new();
            foreach (string strNum in strSplit) {
                if (int.TryParse(strNum, out int num)) {
                    BingoNumber bingoNumber = new(num);
                    bingoNumbers.Add(bingoNumber);
                }
            }
            return bingoNumbers;
        }

        public bool MarkNumber(int num) {
            foreach (List<BingoNumber> row in Grid) {
                var bingoNumber = row.FirstOrDefault(n => n.Number == num);
                if (bingoNumber is not null) { 
                    bingoNumber.Mark();
                    return true;
                }
            }
            return false;
        }

        public bool HasBingo() {
            if (RowHasBingo() || ColumnHasBingo()) {
                return true; 
            }
            return false;
        }

        public void SetAsWinner() {
            AlreadyWon = true;
        }

        private bool RowHasBingo() {
            foreach (List<BingoNumber> row in Grid) {
                if (ListHasBingo(row)) { return true; }
            }
            return false;
        }

        private bool ColumnHasBingo() {
            for (int colPos = 0; colPos < 5; colPos++) {
                List<BingoNumber> column = new();
                foreach (List<BingoNumber> row in Grid) {
                    column.Add(row[colPos]);
                }
                if (ListHasBingo(column)) { return true; }
            }
            return false;
        }

        private static bool ListHasBingo(List<BingoNumber> rowOrColumn) {
            var unmarked = rowOrColumn.FirstOrDefault(n => !n.IsMarked);
            if (unmarked is null) { return true; }
            else { return false; }
        }

        public int GetCardScore() {
            return GetSumOfUnmarked() * WinningMultiplier;
        }

        private int GetSumOfUnmarked() {
            int cardSum = 0;
            foreach (List<BingoNumber> row in Grid) {
                var unmarkedInRow = row.Where(n => !n.IsMarked);
                int rowSum = 0;
                foreach (BingoNumber unmarkedNumber in unmarkedInRow) {
                    rowSum += unmarkedNumber.Number;
                }
                cardSum += rowSum;
            }
            return cardSum;
        }
    }
}
