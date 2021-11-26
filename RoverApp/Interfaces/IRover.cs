using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Interfaces
{
    public interface IRover
    {
        LocationModel Location { get; set; }

        IRover ExecuteDirectives();

        List<string> ValidationErrors { get; set; }
    }
}
