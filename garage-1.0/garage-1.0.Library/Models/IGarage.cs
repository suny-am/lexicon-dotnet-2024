namespace Garage_1_0.Library.Models;

public interface IGarage<T> where T : IParkingSpot
{
    public string Name { get; }
    public int VehicleCapacity { get; }
    public IParkingSpot[] Spots { get; }
}