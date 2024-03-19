using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Repositories;

public class GarageRepository<T>(Garage<ParkingSpot> garage) : IRepository<IVehicle>
{
    private readonly Garage<ParkingSpot> _garage = new Garage<ParkingSpot>(30);
    private IEnumerable<ParkingSpot> _parkingSpots = garage.Spots;

    public IVehicle Add(IVehicle vehicle)
    {
        ParkingSpot spot = _parkingSpots
                                  .Where(s => s.Vehicle is null)
                                  .First();

        return spot.Vehicle = vehicle;
    }

    public IEnumerable<IVehicle?> All()
    {
        return _parkingSpots
                      .Select(s => s.Vehicle)
                      .Where(v => v is not null);
    }

    public bool Any()
    {
        return _parkingSpots.Select(s => s.Vehicle).Any();
    }

    public IEnumerable<IVehicle?> Find(Func<IVehicle?, bool> predicate)
    {
        return _parkingSpots.Select(s => s.Vehicle)
                            .Where(predicate);
    }

    public IVehicle? Remove(IVehicle vehicle)
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

    public IVehicle Update(IVehicle vehicle)
    {
        ParkingSpot? spot = _parkingSpots.FirstOrDefault(s => s.Vehicle?.Id == vehicle.Id);
        if (spot is null)
        {
            throw new Exception("TBD Exception here!");
        }
        return spot.Vehicle = vehicle;
    }
}