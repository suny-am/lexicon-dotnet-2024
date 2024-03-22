using Garage_1_0.Library.Models.Vehicles;

namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class RepositoryException : Exception
{
    private IVehicle _vehicle;

    public RepositoryException(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public override string Message => $"Error occured during Repository operation when processing vehicle {_vehicle.RegistrationNumber}";
}