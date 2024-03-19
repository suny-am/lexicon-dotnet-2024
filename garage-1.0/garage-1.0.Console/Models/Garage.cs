using System.Collections;
using Garage_1_0.Models.Vehicles;

namespace Garage_1_0.Models;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private IEnumerable<Vehicle> vehicles = [];
    private uint maxCapacity;

    public Garage(uint maxCapacity)
    {
        MaxCapacity = maxCapacity;
        Vehicles = [];
    }

    public Garage(uint maxCapacity, IEnumerable<Vehicle> vehicles)
    {
        MaxCapacity = maxCapacity;
        Vehicles = vehicles;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // TBD! Maybe not allow this?
    public Garage(IEnumerable<T> vehicles)
    {
        this.vehicles = vehicles;
    }

    public IEnumerable<Vehicle> Vehicles
    {
        get
        {
            return vehicles;
        }
        set
        {
            // TBD! Validate
            vehicles = value;
        }
    }

    public uint MaxCapacity
    {
        get
        {
            return maxCapacity;
        }
        set
        {
            maxCapacity = ValidateCapacity(value);
        }
    }

    private uint ValidateCapacity(object input)
    {
        if (input.GetType().Name is not "uint")
        {
            throw new ArgumentException("invalid input!");
        }
        return (uint)input;
    }
}


