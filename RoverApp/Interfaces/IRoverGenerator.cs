using RoverApp.Models;

namespace RoverApp.Interfaces
{
    public interface IRoverGenerator
    {
        IRover GenerateRover(InputModel data);
    }
}
