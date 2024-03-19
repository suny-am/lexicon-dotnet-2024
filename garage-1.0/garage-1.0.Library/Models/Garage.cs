using System.Collections;

namespace Garage_1_0.Library.Models;

public class Garage<T> : IEnumerable, IEnumerable<T> where T : ParkingSpot
{
    private IEnumerable<ParkingSpot> _spots = [];
    private uint _vehicleCapacity;

    public Garage(uint vehicleCapacity)
    {
        _spots = new ParkingSpot[vehicleCapacity];
    }

    public uint VehicleCapacity
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

    public IEnumerable<ParkingSpot> Spots
    {
        get; set;
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