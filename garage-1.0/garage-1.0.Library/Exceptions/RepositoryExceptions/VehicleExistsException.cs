namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

using Garage_1_0.Library.Models.Vehicles;

public class VehicleExistsException : Exception
{
    private IVehicle _vehicle;

    public VehicleExistsException(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public override string Message => $"{_vehicle.RegistrationNumber} already registered in garage!";
}