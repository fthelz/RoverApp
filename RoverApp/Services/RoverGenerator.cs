using RoverApp.Interfaces;
using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApp.Services
{
    public class RoverGenerator : IRoverGenerator
    {
        public IRover GenerateRover(InputModel data)
        {
            var model = new RoverModel(data);
            model.SetPosition();
            return model;
        }
    }
}

