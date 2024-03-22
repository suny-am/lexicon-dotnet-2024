namespace Garage_1_0.Library.Exceptions;

public class GarageNotFoundException(string garageName) : Exception
{
    private string _message = $"Garage {garageName} not found.";

    public override string Message => _message;
}