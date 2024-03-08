namespace Errors;

internal class UIntInputError : UserError
{
    private const string unsignedIntegerMessage = "An integer with a negative value was supplied when an unsigned integer was expected!";

    internal override string UEMessage()
    {
        return unsignedIntegerMessage;
    }
}