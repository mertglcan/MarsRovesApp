using MarsRovers.Domain.RoverCommand.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain.RoverCommand
{
    public static class RoverCommandFactory
    {
        public static IRoverCommand GetCommand(char commandLetter)
        {
            var commandType = (
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(IRoverCommand).IsAssignableFrom(t) && 
                !t.IsInterface &&
                t.IsClass && 
                t.Namespace == "MarsRovers.Domain.RoverCommand" && 
                t.Name==$"{commandLetter}Command" 
                select t
                ).FirstOrDefault();
            
            if (commandType == null)
                throw new Exception($"{commandLetter} is undefined command.");

            return (IRoverCommand)Activator.CreateInstance(commandType);
        }
    }
}
