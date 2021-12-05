using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02 {
    public enum Direction { Forward, Up, Down }
    public class SubCommand {
        public Direction Direction { get; set; }
        public int Distance { get; set; }

        public SubCommand(string command) {
            List<string> commandSplit = command.Split(' ').ToList();
            if (commandSplit[0].ToLower() == "forward") { Direction = Direction.Forward; }
            else if (commandSplit[0].ToLower() == "up") { Direction = Direction.Up; }
            else { Direction = Direction.Down; }

            Distance = int.Parse(commandSplit[1]);
        }
    }
}
