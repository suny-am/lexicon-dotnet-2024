namespace Garage_1_0.Library.Exceptions;

public class GarageExistsException(string? target = null) : Exception
{
    private string _message = $"Garage {target} already exists";

    public override string Message => _message;
}