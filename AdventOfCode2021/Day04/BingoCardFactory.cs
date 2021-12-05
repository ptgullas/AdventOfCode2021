using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04 {
    public static class BingoCardFactory {
        public static List<BingoCard> CreateBingoCards(List<string> strings) {
            List<BingoCard> bingoCards = new();
            for (int i = 0; i < strings.Count; i += 6) {
                BingoCard bingoCard = new(strings.GetRange(i, 6));
                bingoCards.Add(bingoCard);
            }
            return bingoCards;
        }
    }
}
