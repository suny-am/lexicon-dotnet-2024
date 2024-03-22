using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class RepositoryFullException(IVehicle vehicle) : RepositoryException(vehicle)
{
    private IVehicle _vehicle = vehicle;
    public override string Message => $"Could not add Vehicle {_vehicle.RegistrationNumber}; Garage is full";
}