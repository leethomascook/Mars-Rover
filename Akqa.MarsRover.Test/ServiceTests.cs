using System.Collections.Generic;
using Akqa.MarsRover.Business.Domain;
using Akqa.MarsRover.Business.Services;
using NUnit.Framework;

namespace Akqa.MarsRover.Test
{
    [TestFixture]
    public class ServiceTests
    {

        [Test]
        public void Test_NavigationService_Moves_Rover_Correctly_Forward_One_Square()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5,5);
            List<Command> commands = new List<Command>();
            commands.Add(Command.MoveForward);
            var startPosition = new Position {Direction = Direction.North, X = 0, Y = 0};
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 1 };
            var rover = new Rover(startPosition);

            Position position = service.ExploreTerrain(plateau, rover, commands);
            Assert.AreEqual(position, expectedPosition);
        }

        [Test]
        public void Test_NavigationService_Moves_Rover_Correctly_Forward_Multiple_Square()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();
            
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            
            var startPosition = new Position { Direction = Direction.North, X = 0, Y = 0 };
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 5 };
            var rover = new Rover(startPosition);

            Position position = service.ExploreTerrain(plateau, rover, commands);
            Assert.AreEqual(position, expectedPosition);
        }


        [Test]
        public void Test_NavigationService_Moves_Rover_Correctly_Forward_Multiple_Square_In_Multiple_Directions()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.North, X = 3, Y = 0 };
            var expectedPosition = new Position { Direction = Direction.North, X = 1, Y = 2 };
            var rover = new Rover(startPosition);

            Position position = service.ExploreTerrain(plateau, rover, commands);
            Assert.AreEqual(position, expectedPosition);
        }

        [Test]
        public void Test_NavigationService_Moves_Rover_Correctly_According_To_Supplied_Test_Data_One()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);

            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.North, X = 1, Y = 2 };
            var expectedPosition = new Position { Direction = Direction.North, X = 1, Y = 3 };
            var rover = new Rover(startPosition);

            Position position = service.ExploreTerrain(plateau, rover, commands);
            Assert.AreEqual(position, expectedPosition);
        }


        [Test]
        public void Test_NavigationService_Moves_Rover_Correctly_According_To_Supplied_Test_Data_Two()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.East, X = 3, Y = 3 };
            var expectedPosition = new Position { Direction = Direction.East, X = 5, Y = 1 };
            var rover = new Rover(startPosition);

            Position position = service.ExploreTerrain(plateau, rover, commands);
            Assert.AreEqual(position, expectedPosition);
        }
    }
}
