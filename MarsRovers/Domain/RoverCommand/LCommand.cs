using MarsRovers.Domain.Definitions;
using MarsRovers.Domain.RoverCommand.Abstract;
using System;

namespace MarsRovers.Domain.RoverCommand
{
    public class LCommand : IRoverCommand
    {
        public void CommandRover(Rover rover)
        {
            int nextFacingRotation = (((int)rover.CurrentPosition.Facing + 270) % 360);
            rover.CurrentPosition.Facing = (Facing)nextFacingRotation;
        }
    }
}
