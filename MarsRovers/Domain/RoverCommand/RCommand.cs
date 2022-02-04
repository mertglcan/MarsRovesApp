using MarsRovers.Domain.Definitions;
using MarsRovers.Domain.RoverCommand.Abstract;

namespace MarsRovers.Domain.RoverCommand
{
    public class RCommand : IRoverCommand
    {
        public void CommandRover(Rover rover)
        {
            int nextFacingRotation = (((int)rover.CurrentPosition.Facing + 90) % 360);
            rover.CurrentPosition.Facing = (Facing)nextFacingRotation;
        }
    }
}
