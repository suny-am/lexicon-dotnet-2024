namespace Garage_1_0.Library.Exceptions;

public class GarageNotSelectedException() : Exception
{
    private string _message = "No garage selected!";

    public override string Message => _message;
}