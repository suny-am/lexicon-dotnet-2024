using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class RepositoryVehicleExistsException : Exception
{
    private IVehicle _vehicle;

    public RepositoryVehicleExistsException(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public override string Message => $"{_vehicle.RegistrationNumber} already registered in garage!";
}