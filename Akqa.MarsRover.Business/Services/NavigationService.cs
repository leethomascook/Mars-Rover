using System.Collections.Generic;
using Akqa.MarsRover.Business.Domain;

namespace Akqa.MarsRover.Business.Services
{
    public class NavigationService : INavigationService
    {
        public Position ExploreTerrain(Plateau plateau, Rover rover, List<Command> commands)
        {

            /* Need to do some out of bounds validation here, hence I passed the plateau in, but it is not mentioned in the 'spec' */

            foreach (var command in commands)
            {
                switch(command)
                {
                    case Command.MoveForward:
                        rover.MoveFoward();
                        break;
                    case Command.TurnLeft:
                        rover.Rotate(Rotation.Left);
                        break;
                    case Command.TurnRight:
                        rover.Rotate(Rotation.Right);
                        break;
                }
            }

            return rover.GetCurrentPosition();
        }
    }
}
