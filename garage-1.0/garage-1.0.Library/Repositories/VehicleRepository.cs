using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Exceptions.RepositoryExceptions;

namespace Garage_1_0.Library.Repositories;

public class VehicleRepository<T>(Garage<ParkingSpot> garage) : IRepository<IVehicle>
{
    private Garage<ParkingSpot> _garage = garage;
    private IEnumerable<ParkingSpot> _parkingSpots = garage.Spots;

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
        ParkingSpot? spot;
        try
        {
            var exists = _parkingSpots.Any(s => s.Vehicle?.RegistrationNumber == vehicleToAdd.RegistrationNumber);
            if (exists) throw new RepositoryVehicleExistsException(vehicleToAdd);
            spot = _parkingSpots.FirstOrDefault(s => s.Vehicle is null);
            if (spot is null) throw new RepositoryFullException(vehicleToAdd);
        }
        catch (RepositoryVehicleExistsException)
        {
            throw;
        }
        catch (RepositoryFullException)
        {
            throw;
        }

        return spot!.Vehicle = vehicleToAdd;
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

    public IVehicle? Remove(string? vehicleRegistrationNumber)
    {
        ParkingSpot? spot = _parkingSpots
                            .FirstOrDefault(s => s.Vehicle?.RegistrationNumber == vehicleRegistrationNumber)
                            ?? throw new Exception("TBD Exception here!");
        return spot.Vehicle = null;
    }

    // TBD Used when saving to file! Maybe not here?
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