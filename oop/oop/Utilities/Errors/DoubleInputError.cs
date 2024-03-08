namespace Errors;

internal class DoubleInputError : UserError
{
    private const string doubleErrorMessage = "A non-floating-point numeric type was supplied when a double was expected!";

    internal override string UEMessage()
    {
        return doubleErrorMessage;
    }
}