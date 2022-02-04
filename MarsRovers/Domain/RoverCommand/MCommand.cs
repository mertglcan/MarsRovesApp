using MarsRovers.Domain.Definitions;
using MarsRovers.Domain.RoverCommand.Abstract;
using System;

namespace MarsRovers.Domain.RoverCommand
{
    public class MCommand : IRoverCommand
    {
        public void CommandRover(Rover rover)
        {
            int faceing = (int)rover.CurrentPosition.Facing;
            int x = rover.CurrentPosition.X;
            int y = rover.CurrentPosition.Y;
            int nextX, nextY;

            double facingRadian = faceing * Math.PI / 180.0;


            nextX = Convert.ToInt32(x + Math.Sin(Convert.ToDouble(facingRadian)));
            nextY = Convert.ToInt32(y + Math.Cos(Convert.ToDouble(facingRadian)));

            if (!rover.IsValidPositionForLanding(new Position(nextX, nextY, rover.CurrentPosition.Facing)))
            {
                throw new Exception("Invalid command for move on this planet.");
            }

            rover.CurrentPosition.X = nextX;
            rover.CurrentPosition.Y = nextY;
        }
    }
}
