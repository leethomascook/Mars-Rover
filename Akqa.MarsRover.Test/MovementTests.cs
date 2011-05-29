using Akqa.MarsRover.Business.Domain;
using NUnit.Framework;

namespace Akqa.MarsRover.Test
{
    [TestFixture]
    public class MovementTests
    {
        [Test]
        public void Test_Rover_Can_Move_Forward_One_Square_When_Facing_North()
        {
            var startPosition = new Position {Direction = Direction.North, X = 0, Y = 0};
            var rover = new Rover(startPosition);
            rover.MoveFoward();

            var newPosition = rover.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 1 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Rover_Can_Move_Forward_One_Square_When_Facing_South()
        {
            var startPosition = new Position { Direction = Direction.South, X = 0, Y = 1 };
            var rover = new Rover(startPosition);
            rover.MoveFoward();

            var newPosition = rover.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.South, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Rover_Can_Move_Forward_One_Square_When_Facing_East()
        {
            var startPosition = new Position { Direction = Direction.East, X = 0, Y = 0 };
            var rover = new Rover(startPosition);
            rover.MoveFoward();

            var newPosition = rover.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.East, X = 1, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Rover_Can_Move_Forward_One_Square_When_Facing_West()
        {
            var startPosition = new Position { Direction = Direction.West, X = 1, Y = 0 };
            var rover = new Rover(startPosition);
            rover.MoveFoward();

            var newPosition = rover.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.West, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        
    }
}
