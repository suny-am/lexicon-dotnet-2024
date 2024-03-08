internal class InvalidSongLengthException : InvalidSongException
{
    internal new readonly string message = "Invalid song length.";

    public override string Message
    {
        get
        {
            return message;
        }
    }
}