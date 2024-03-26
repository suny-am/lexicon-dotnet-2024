namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

using Garage_1_0.Library.Models.Vehicles;

public class RepositoryException : Exception
{
    private IVehicle _vehicle;

    public RepositoryException(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }
    public override string Message => $"Error occured during Repository operation when processing vehicle {_vehicle.RegistrationNumber}";
}