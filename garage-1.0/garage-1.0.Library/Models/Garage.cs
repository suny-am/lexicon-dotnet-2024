namespace Garage_1_0.Library.Models;

using System.Collections;

public class Garage<T> : IEnumerable, IEnumerable<T>, IGarage<T> where T : IParkingSpot
{
    private IParkingSpot[] _spots;
    private string _name;
    private int _vehicleCapacity = default!;

    public Garage(string garageName, int vehicleCapacity)
    {
        _name = garageName;
        _vehicleCapacity = vehicleCapacity;
        _spots = new IParkingSpot[vehicleCapacity];
        for (int i = 0; i < vehicleCapacity; i++)
        {
            _spots[i] = new ParkingSpot();
        }
    }

    public string Name => _name;

    public int VehicleCapacity
    {
        get => _vehicleCapacity;
        set => _vehicleCapacity = value;
    }

    public IParkingSpot[] Spots
    {
        get => _spots;
        set => _spots = value;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var spot in Spots)
        {
            yield return spot;
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }
}