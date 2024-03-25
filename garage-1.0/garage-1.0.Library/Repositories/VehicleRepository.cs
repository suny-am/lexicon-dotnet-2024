namespace Garage_1_0.Library.Repositories;

using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class VehicleRepository<T>(IGarage<IParkingSpot> garage) : IRepository<IVehicle> where T : IVehicle
{
    private IGarage<IParkingSpot> _garage = garage;
    private IEnumerable<IParkingSpot> _parkingSpots = garage.Spots;

    public IGarage<IParkingSpot> Garage
    {
        get => _garage;
        set
        {
            if (value is null)
            {
                throw new RepositoryDataSourceException(value!);
            }
        }
    }

    public IVehicle? Add(IVehicle vehicleToAdd)
    {
        IParkingSpot? spot;
        try
        {
            var exists = _parkingSpots.Any(s => s.Vehicle?.RegistrationNumber == vehicleToAdd.RegistrationNumber);
            if (exists) throw new VehicleExistsException(vehicleToAdd);
            spot = _parkingSpots.FirstOrDefault(s => s.Vehicle is null);
            if (spot is null) throw new RepositoryFullException(vehicleToAdd);
        }
        catch (VehicleExistsException)
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
        IParkingSpot? spot = _parkingSpots
                            .FirstOrDefault(s => s.Vehicle?.RegistrationNumber == vehicleRegistrationNumber)
                            ?? throw new VehicleNotFoundException(vehicleRegistrationNumber!);
        var deletedVehicle = spot.Vehicle;
        spot.Vehicle = null;
        return deletedVehicle;
    }

    public IVehicle Update(IVehicle vehicleToUpdate)
    {
        IParkingSpot? spot = _parkingSpots
                            .FirstOrDefault(s => s.Vehicle?.RegistrationNumber == vehicleToUpdate.RegistrationNumber)
                            ?? throw new VehicleNotFoundException(vehicleToUpdate.RegistrationNumber);
        return spot.Vehicle = vehicleToUpdate;
    }
}