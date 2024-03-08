internal class InvalidSongException : Exception
{
    internal readonly string message = "Invalid song.";

    public override string Message
    {
        get
        {
            return message;
        }
    }
}