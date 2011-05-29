using System.Collections.Generic;
using Akqa.MarsRover.Business.Domain;

namespace Akqa.MarsRover.Business.Services
{
    public interface INavigationService
    {
        Position ExploreTerrain(Plateau plateau, Rover rover, List<Command> commands);
    }
}
