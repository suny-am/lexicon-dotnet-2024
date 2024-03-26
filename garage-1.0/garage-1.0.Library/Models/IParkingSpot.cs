namespace Garage_1_0.Library.Models;

using Garage_1_0.Library.Models.Vehicles;

public interface IParkingSpot
{
    public IVehicle? Vehicle { get; set; }
}