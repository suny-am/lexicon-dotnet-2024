internal class InvalidArtistNameException : InvalidSongException
{
    internal new readonly string message = "Artist name should be between 3 and 20 symbols.";

    public override string Message
    {
        get
        {
            return message;
        }
    }

}