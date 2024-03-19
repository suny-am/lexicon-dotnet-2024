using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Repositories;

public class GarageRepository<T>(Garage<ParkingSpot> garage) : IRepository<Vehicle>
{
    private readonly Garage<ParkingSpot> _garage = garage;
    private IEnumerable<ParkingSpot> _parkingSpots = garage.Spots;

    public Vehicle Add(Vehicle vehicle)
    {
        ParkingSpot spot = _parkingSpots
                                  .Where(s => s.Vehicle is null)
                                  .First();

        return spot.Vehicle = vehicle;
    }

    public IEnumerable<Vehicle?>? All()
    {
        return _parkingSpots
                      .Select(s => s.Vehicle)
                      .Where(v => v is not null);
    }

    public bool Any()
    {
        return _parkingSpots.Select(s => s.Vehicle).Any();
    }

    public IEnumerable<Vehicle?> Find(Func<Vehicle?, bool> predicate)
    {
        return _parkingSpots.Select(s => s.Vehicle)
                            .Where(predicate);
    }

    public Vehicle? Remove(Vehicle vehicle)
    {
        ParkingSpot? spot = _parkingSpots.FirstOrDefault(s => s.Vehicle?.Id == vehicle.Id);
        if (spot is null)
        {
            throw new Exception("TBD Exception here!");
        }
        return spot.Vehicle = null;
    }

    // TBD Used when saving to file!
    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Vehicle Update(Vehicle vehicle)
    {
        ParkingSpot? spot = _parkingSpots.FirstOrDefault(s => s.Vehicle?.Id == vehicle.Id);
        if (spot is null)
        {
            throw new Exception("TBD Exception here!");
        }
        return spot.Vehicle = vehicle;
    }
}