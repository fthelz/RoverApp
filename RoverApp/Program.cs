using RoverApp.Helpers;
using RoverApp.Interfaces;
using RoverApp.Models;
using RoverApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoverApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine();
            var currentLocation1 = Console.ReadLine();
            var movement1 = Console.ReadLine();
            var currentLocation2 = Console.ReadLine();
            var movement2 = Console.ReadLine();
            
            var inputData = new InputModel()
            {
                Boundary = maxPoints,
                CurrentLocation = currentLocation1,
                Directives = movement1
            };

            var inputData2 = new InputModel()
            {
                Boundary = maxPoints,
                CurrentLocation = currentLocation2,
                Directives = movement2
            };

            IRoverGenerator service = new RoverGenerator();

            IRover firstRover = service.GenerateRover(inputData).ExecuteDirectives();
            IRover secondRover = service.GenerateRover(inputData2).ExecuteDirectives();

            if (firstRover.ValidationErrors.Any())
            {
                firstRover.ValidationErrors.ForEach(p => Console.WriteLine(p));
            }
            else
            {
                Console.WriteLine($"{firstRover.Location.X} {firstRover.Location.Y} {RoverHelper.GetDirectionDescription(firstRover.Location.Direction)}");
            }

            if (secondRover.ValidationErrors.Any())
            {
                secondRover.ValidationErrors.ForEach(p => Console.WriteLine(p));
            }
            else
            {
                Console.WriteLine($"{secondRover.Location.X} {secondRover.Location.Y} {RoverHelper.GetDirectionDescription(secondRover.Location.Direction)}");
            }

        }
    }
}
