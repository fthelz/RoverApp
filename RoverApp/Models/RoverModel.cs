using RoverApp.Actions;
using RoverApp.Helpers;
using RoverApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoverApp.Models
{
    internal class RoverModel : IRover
    {
        public InputModel RoverData { get; set; }

        public LocationModel Location { get; set; } = new LocationModel();

        public List<string> ValidationErrors { get; set; } = new List<string>();

        public RoverModel(InputModel data)
        {
            RoverData = data;
        }

        public void SetPosition()
        {
            var positions = RoverData.CurrentLocation.Split(' ');
            var boundaries = RoverData.Boundary.Split(' ');
            if (positions.Length == 3 && boundaries.Length == 2)
            {
                Regex regexPositon = new Regex(@"^[WESN]*$");
                bool isValidLocation = regexPositon.Match(positions[2]).Success;

                int locationX, locationY, boundaryX, boundaryY = 0;
                if (isValidLocation)
                {
                    if (int.TryParse(positions[0], out locationX))
                    {
                        Location.X = locationX;
                    }
                    else
                    {
                        ValidationErrors.Add("Check Initial X");
                        return;
                    }
                    if (int.TryParse(positions[1], out locationY))
                    {
                        Location.Y = locationY;
                    }
                    else
                    {
                        ValidationErrors.Add("Check Initial Y");
                        return;
                    }
                    if (int.TryParse(boundaries[0], out boundaryX))
                    {

                        Location.MaxX = boundaryX;
                    }
                    else
                    {
                        ValidationErrors.Add("Check Boundary X");
                        return;
                    }
                    if (int.TryParse(boundaries[1], out boundaryY))
                    {

                        Location.MaxY = boundaryY;
                    }
                    else
                    {
                        ValidationErrors.Add("Check Boundary Y");
                        return;
                    }
                    Location.Direction = this.SetDirection(positions[2]);
                }
                else
                {
                    ValidationErrors.Add("Input validation failed.");
                    return;
                }

            }
            else
            {
                ValidationErrors.Add("Input validation failed.");
                return;
            }

            if (!Location.Validate())
            {
                ValidationErrors.Add("Boundary validation failed.");
            }
        }

        public IRover ExecuteDirectives()
        {
            RoverData.Directives?.ToList().ForEach(p =>
            {
                switch (p)
                {
                    case 'L':
                        new TurnLeft().SetRover(this).Execute();
                        break;
                    case 'R':
                        new TurnRight().SetRover(this).Execute();
                        break;
                    case 'M':
                        new Move().SetRover(this).Execute();
                        break;
                }
            });

            return this;
        }
    }
}
