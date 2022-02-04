using MarsRovers.Domain.Definitions;
using MarsRovers.Domain.RoverCommand;
using System;

namespace MarsRovers.Domain
{
    public class Rover
    {
        private readonly Planet landedPlanet;
        public Position CurrentPosition { get; private set; }

        public Rover(Planet planet, Position initialPosition)
        {
            landedPlanet = planet;

            if (!IsValidPositionForLanding(initialPosition))
            {
                throw new Exception("Rover can not land on this planet.");
            }

            CurrentPosition = new Position(initialPosition.X, initialPosition.Y, initialPosition.Facing);
        }

        public bool IsValidPositionForLanding(Position position)
        {
            if (position.X < 0 ||
                position.Y < 0 ||
                position.X > landedPlanet.X ||
                position.Y > landedPlanet.Y)
            {
                return false;
            }

            return true;
        }

        public void GetDirectivesWithLineCommand(string lineCommand)
        {
            foreach (char item in lineCommand.ToUpper())
            {
                RoverCommandFactory.GetCommand(item).CommandRover(this);
            }
        }

    }
}
