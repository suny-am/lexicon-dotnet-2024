namespace Errors;

internal class TextInputError : UserError
{
    private const string textInputMessage = "You tried to use a text input in a numeric only field. This fired an error!";

    internal override string UEMessage()
    {
        return textInputMessage;
    }
}