using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Models;

public class ParkingSpot() : IParkingSpot
{
    private IVehicle? _vehicle;

    public IVehicle? Vehicle
    {
        get
        {
            return _vehicle;
        }
        set
        {
            _vehicle = value;
        }
    }
}