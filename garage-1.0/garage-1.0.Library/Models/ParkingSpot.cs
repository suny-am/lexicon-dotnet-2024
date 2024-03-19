using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Models;

public class ParkingSpot()
{
    private Vehicle? _vehicle;

    public Vehicle? Vehicle
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