namespace Garage_1_0.Library.Models;

using System.Collections;

public class Garage<T> : IEnumerable, IEnumerable<T>, IGarage<T> where T : IParkingSpot
{
    private ParkingSpot[] _spots;
    private string _name;
    private int _vehicleCapacity = default!;

    public Garage(string garageName, int vehicleCapacity)
    {
        _name = garageName;
        _vehicleCapacity = vehicleCapacity;
        _spots = new ParkingSpot[vehicleCapacity];
        for (int i = 0; i < vehicleCapacity; i++)
        {
            _spots[i] = new ParkingSpot();
        }
    }

    public string Name
    {
        get => _name;
    }

    public int VehicleCapacity
    {
        get
        {
            return _vehicleCapacity;
        }
        set
        {
            _vehicleCapacity = value;
        }
    }

    public ParkingSpot[] Spots
    {
        get
        {
            return _spots;
        }
        set
        {
            _spots = value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }

    public ParkingSpotEnum GetEnumerator()
    {
        return new ParkingSpotEnum(_spots);
    }

}

public class ParkingSpotEnum : IEnumerator
{
    public IEnumerable<ParkingSpot> _parkingSpots;
    private int position = -1;


    public ParkingSpotEnum(IEnumerable<ParkingSpot> spots)
    {
        _parkingSpots = spots;
    }


    public bool MoveNext()
    {
        position++;
        return position < _parkingSpots.Count();
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public ParkingSpot Current
    {
        get
        {
            try
            {
                return _parkingSpots.ElementAt(position);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

}