using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02 {
    public static class Submarine {
        public static int HorizontalPosition { get; set; }
        public static int Depth { get; set; }
        public static int Aim { get; set; }

        static Submarine() {
            HorizontalPosition = 0;
            Depth = 0;
            Aim = 0;
        }

        public static void ReadCommands(List<SubCommand> subCommands) {
            foreach (SubCommand subCommand in subCommands) {
                ReadCommand(subCommand);
            }
        }

        public static int CalculateProduct() {
            return HorizontalPosition * Depth;
        }

        private static void ReadCommand(SubCommand subCommand) {
            if (subCommand.Direction is Direction.Forward) { 
                HorizontalPosition += subCommand.Distance;
                Depth += Aim * subCommand.Distance;
            }
            else if (subCommand.Direction is Direction.Down) { Aim += subCommand.Distance; }
            else if (subCommand.Direction is Direction.Up) { Aim -= subCommand.Distance; }
        }

    }
}
