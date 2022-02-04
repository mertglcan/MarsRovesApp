using MarsRovers.Domain;
using MarsRovers.Domain.Definitions;
using System;

namespace MarsRovers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);

            Console.WriteLine("Enter the right upper coordinates of planet with space (ex: 5 5)");
            string tmpPlanetCoordinates = Console.ReadLine();

            var planetCoordinates= tmpPlanetCoordinates.Split(' ');
            Planet planet = new Planet(Convert.ToInt32(planetCoordinates[0]),Convert.ToInt32(planetCoordinates[1]));

            Console.WriteLine("Enter the 1.Rover position with space (ex: 1 2 N)");

            string tmpPosition = Console.ReadLine().ToUpper();
            var roverPosition = tmpPosition.Split(' ');

            Position position = new Position(Convert.ToInt32(roverPosition[0]), Convert.ToInt32(roverPosition[1]), Enum.Parse<Facing>(roverPosition[2]));

            Rover rover = new Rover(planet, position);

            Console.WriteLine("Enter the 1.Rover directive line command(ex: LMLMLMLMM)");

            string roverDirectiveCommand = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the 2.Rover position with space (ex: 3 3 E)");

            string tmp2Position = Console.ReadLine().ToUpper();
            var rover2Position = tmp2Position.Split(' ');

            Position position2 = new Position(Convert.ToInt32(rover2Position[0]), Convert.ToInt32(rover2Position[1]), Enum.Parse<Facing>(rover2Position[2]));

            Rover rover2 = new Rover(planet, position2);

            Console.WriteLine("Enter the 2.Rover directive line command(ex: MMRMMRMRRM)");

            string rover2DirectiveCommand = Console.ReadLine().ToUpper();

            rover.GetDirectivesWithLineCommand(roverDirectiveCommand);

            Console.WriteLine(rover.CurrentPosition.ToString());
            
            rover2.GetDirectivesWithLineCommand(rover2DirectiveCommand);
            Console.WriteLine(rover2.CurrentPosition.ToString());

            Console.ReadLine();
        }

        private static void ErrorHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
