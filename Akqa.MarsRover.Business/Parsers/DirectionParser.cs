using System;
using Akqa.MarsRover.Business.Domain;

namespace Akqa.MarsRover.Business.Parsers
{
    public static class DirectionParser
    {
        public static Direction Parse(string direction)
        {
            switch (direction)
            {
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                case "E":
                    return Direction.East;
            }
            
            throw new InvalidOperationException();
        }
    }
}
