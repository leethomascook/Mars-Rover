using System.Collections.Generic;
using Akqa.MarsRover.Business.Domain;

namespace Akqa.MarsRover.Business.Parsers
{
    public static class CommandParser
    {
        public static List<Command> Parse(string movements)
        {
            var commands = new List<Command>();
            foreach(char c in movements.ToUpper())
            {
                switch(c)
                {
                    case 'L':
                        commands.Add(Command.TurnLeft);
                        break;
                    case 'R':
                        commands.Add(Command.TurnRight);
                        break;
                    case 'M':
                        commands.Add(Command.MoveForward);
                        break;
                }
            }

            return commands;
        }
    }
}
