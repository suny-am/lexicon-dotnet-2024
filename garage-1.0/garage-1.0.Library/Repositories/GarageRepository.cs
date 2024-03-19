using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Repositories;

public class GarageRepository<T>(Garage<ParkingSpot> garage) : IRepository<Vehicle>
{
    private Garage<ParkingSpot> _garage = garage;

    public Vehicle Add(Vehicle vehicle)
    {
        ParkingSpot spot = _garage.Spots.Last();
        return spot.Vehicle = vehicle;
    }

    public IEnumerable<Vehicle?> All()
    {
        return _garage.Spots.Select(s => s.Vehicle);
    }

    public bool Any()
    {
        return _garage.Spots.Select(s => s.Vehicle).Any();
    }

    public IEnumerable<Vehicle> Find(Func<Vehicle, bool> predicate)
    {
        var spots = _garage.Spots.Where<Vehicle>(predicate);

    }

    public Vehicle Remove(Vehicle entity)
    {
        throw new NotImplementedException();
    }

    // TBDUsed when saving to file!
    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Vehicle Update(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
}