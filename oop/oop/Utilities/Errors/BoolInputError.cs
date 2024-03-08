namespace Errors;

internal class BoolInputError : UserError
{
    private const string boolErrorMessage = "A non-boolean value was supplied when a boolean was expected!";

    internal override string UEMessage()
    {
        return boolErrorMessage;
    }
}