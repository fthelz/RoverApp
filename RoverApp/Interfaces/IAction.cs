using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Interfaces
{
    public interface IAction
    {
        IRover Rover { get; set; }

        void Execute();
    }
}
