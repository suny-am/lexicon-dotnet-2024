internal class InvalidSongSecondsException : InvalidSongLengthException
{
    internal new readonly string message = "Song seconds should be between 0 and 59.";

    public override string Message
    {
        get
        {
            return message;
        }
    }
}