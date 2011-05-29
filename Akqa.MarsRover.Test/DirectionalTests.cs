using Akqa.MarsRover.Business.Domain;
using NUnit.Framework;

namespace Akqa.MarsRover.Test
{
    [TestFixture]
    public class DirectionalTests
    {
        [TestCase(Direction.West, Rotation.Left, Direction.South)]
        [TestCase(Direction.West, Rotation.Right, Direction.North)]
        [TestCase(Direction.East, Rotation.Left, Direction.North)]
        [TestCase(Direction.East, Rotation.Right, Direction.South)]
        [TestCase(Direction.South, Rotation.Left, Direction.East)]
        [TestCase(Direction.South, Rotation.Right, Direction.West)]
        [TestCase(Direction.North, Rotation.Left, Direction.West)]
        [TestCase(Direction.North, Rotation.Right, Direction.East)] 
        [Test]
        public void Test_Rover_Can_Rotate_90_Degrees(Direction startDirection, Rotation rotateDirection, Direction endDirection)
        {
            var startPosition = new Position { Direction = startDirection, X = 0, Y = 0 };
            var rover = new Rover(startPosition);

            rover.Rotate(rotateDirection);

            var newPosition = rover.GetCurrentPosition();
            var expectedPosition = new Position { Direction = endDirection, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }
    }
}
