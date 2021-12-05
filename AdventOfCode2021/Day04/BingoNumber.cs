using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04 {
    public class BingoNumber {
        public int Number { get; set; }
        public bool IsMarked { get; set; }

        public BingoNumber(int number) {
            Number = number;
            IsMarked = false;
        }

        public void Mark() {
            IsMarked = true;
        }
    }
}
