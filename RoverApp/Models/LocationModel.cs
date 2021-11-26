using RoverApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Models
{
    public class LocationModel
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public DirectionEnum Direction { get; set; }

        public bool Validate() => (X >= 0) && (Y >= 0) && (X <= MaxX) && (Y <= MaxY);
    }
}
