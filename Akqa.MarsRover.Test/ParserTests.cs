using System.Linq;
using Akqa.MarsRover.Business.Domain;
using Akqa.MarsRover.Business.Parsers;
using NUnit.Framework;

namespace Akqa.MarsRover.Test
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase("N", Direction.North)]
        [TestCase("E", Direction.East)]
        [TestCase("W", Direction.West)]
        [TestCase("S", Direction.South)]
        [Test]
        public void Test_DirectionalParser_Parses_Correctly(string input, Direction output)
        {
            Assert.AreEqual(DirectionParser.Parse(input), output);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Move_Forward()
        {
            var results = CommandParser.Parse("m");
            Assert.AreEqual(results.First(), Command.MoveForward);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Turn_Left()
        {
            var results = CommandParser.Parse("l");
            Assert.AreEqual(results.First(), Command.TurnLeft);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Turns_Right()
        {
            var results = CommandParser.Parse("r");
            Assert.AreEqual(results.First(), Command.TurnRight);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Multiple_Commands()
        {
            var results = CommandParser.Parse("rlMlr");
            Assert.AreEqual(results[0], Command.TurnRight);
            Assert.AreEqual(results[1], Command.TurnLeft);
            Assert.AreEqual(results[2], Command.MoveForward);
            Assert.AreEqual(results[3], Command.TurnLeft);
            Assert.AreEqual(results[4], Command.TurnRight);
        }
    }
}
