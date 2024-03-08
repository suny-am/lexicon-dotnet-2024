internal class InvalidSongNameException : InvalidSongException
{
    internal new readonly string message = "Song name should be between 3 and 30 symbols.";

    public override string Message
    {
        get
        {
            return message;
        }
    }
}
