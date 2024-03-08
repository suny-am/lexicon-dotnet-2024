internal class InvalidSongMinutesException : InvalidSongLengthException
{
    internal new readonly string message = "Song minutes should be between 0 and 14.";

    public override string Message
    {
        get
        {
            return message;
        }
    }
}