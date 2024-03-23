using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Models;

public interface IParkingSpot
{
    public IVehicle? Vehicle { get; set; }
}