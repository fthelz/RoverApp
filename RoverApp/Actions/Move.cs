using RoverApp.Enums;
using RoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Actions
{
    public class Move : IAction
    {
        public IRover Rover { get; set; }

        public void Execute()
        {
            if (!Rover.ValidationErrors.Any())
            {
                switch (Rover.Location.Direction)
                {
                    case DirectionEnum.North:
                        Rover.Location.Y += 1;
                        break;
                    case DirectionEnum.East:
                        Rover.Location.X += 1;
                        break;
                    case DirectionEnum.West:
                        Rover.Location.X -= 1;
                        break;
                    case DirectionEnum.South:
                        Rover.Location.Y -= 1;
                        break;
                }

                if (!Rover.Location.Validate())
                {
                    throw new Exception("Location is out of boundary. Check your directives.");
                }
            }
            
        }
    }
}
