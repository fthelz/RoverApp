using RoverApp.Enums;
using RoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Helpers
{
    internal static class RoverHelper
    {
        public static IAction SetRover(this IAction action, IRover rover)
        {
            action.Rover = rover;
            return action;
        }

        public static DirectionEnum SetDirection(this IRover rover, string directionStr)
        {
            return directionStr == "N" ? DirectionEnum.North
                 : directionStr == "E" ? DirectionEnum.East
                 : directionStr == "W" ? DirectionEnum.West : DirectionEnum.South;
        }

        public static string GetDirectionDescription(DirectionEnum directionEnum)
        {
            return directionEnum == DirectionEnum.North ? "N"
                 : directionEnum == DirectionEnum.East ? "E"
                 : directionEnum == DirectionEnum.West ? "W" : "S";
        }
    }
}
