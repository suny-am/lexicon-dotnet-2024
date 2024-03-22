using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Exceptions.RepositoryExceptions;

namespace Garage_1_0.Library.Repositories;

public class VehicleRepository<T>(Garage<ParkingSpot> garage) : IRepository<IVehicle>
{
    private Garage<ParkingSpot> _garage = garage;
    private IEnumerable<ParkingSpot> _parkingSpots = null!;

    public Garage<ParkingSpot> Garage
    {
        get => _garage;
        set
        {
            if (typeof(Garage<ParkingSpot>) != value.GetType())
            {
                throw new RepositoryInvalidDataSourceException(value);
            }
        }
    }

    public IVehicle? Add(IVehicle vehicleToAdd)
    {
        ParkingSpot spot;
        try
        {
            spot = _parkingSpots.Where(s => s.Vehicle is null)
                                .First();
        }
        catch (Exception)
        {
            throw new RepositoryFullException(vehicleToAdd);
        }

        return spot.Vehicle = vehicleToAdd;
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

    public IEnumerable<IVehicle?> Find(Func<IVehicle?, bool> query)
    {
        return _parkingSpots.Select(s => s.Vehicle)
                            .Where(query);
    }

    public IVehicle? Remove(string vehicleRegistrationNumber)
    {
        ParkingSpot? spot = _parkingSpots
                            .FirstOrDefault(s => s.Vehicle?.RegistrationNumber == vehicleRegistrationNumber)
                            ?? throw new Exception("TBD Exception here!");
        return spot.Vehicle = null;
    }

    // TBD Used when saving to file!
    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public IVehicle Update(IVehicle vehicleToUpdate)
    {
        ParkingSpot? spot = _parkingSpots
                            .FirstOrDefault(s => s.Vehicle?.RegistrationNumber == vehicleToUpdate.RegistrationNumber)
                            ?? throw new Exception("TBD Exception here!");
        return spot.Vehicle = vehicleToUpdate;
    }
}