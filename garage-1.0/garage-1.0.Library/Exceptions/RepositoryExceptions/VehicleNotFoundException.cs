namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class VehicleNotFoundException : Exception
{
    private string _regNumber;

    public VehicleNotFoundException(string regNumber)
    {
        _regNumber = regNumber;
    }
    public override string Message => $"{_regNumber} not found in garage";
}