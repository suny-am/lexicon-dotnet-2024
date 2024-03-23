namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

using Garage_1_0.Library.Models.Vehicles;

public class RepositoryVehicleExistsException : Exception
{
    private IVehicle _vehicle;

    public RepositoryVehicleExistsException(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public override string Message => $"{_vehicle.RegistrationNumber} already registered in garage!";
}