using RoverApp.Enums;
using RoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Actions
{
    public class TurnLeft : IAction
    {
        public IRover Rover { get; set; }

        public void Execute()
        {
            Rover.Location.Direction = Rover.Location.Direction == DirectionEnum.East ? DirectionEnum.North
                : Rover.Location.Direction == DirectionEnum.West ? DirectionEnum.South
                : Rover.Location.Direction == DirectionEnum.North ? DirectionEnum.West : DirectionEnum.East;
        }
    }
}
