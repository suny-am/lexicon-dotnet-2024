namespace Errors;

internal class NumericInputError : UserError
{
    private const string numericInputMessage = "You tried to use a numeric input in a text only field. This fired an error!";

    internal override string UEMessage()
    {
        return numericInputMessage;
    }
}