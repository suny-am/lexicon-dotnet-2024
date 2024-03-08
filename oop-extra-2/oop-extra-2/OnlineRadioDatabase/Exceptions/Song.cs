using System.Text;

internal class Song
{
    private string artist;
    private string songTitle;
    private TimeSpan songDuration;
    private int durationMinutes;
    private int durationSeconds;

    internal Song() { }

    internal Song(string artist, string songTitle, int durationMinutes, int durationSeconds)
    {
        (Artist, SongTitle, DurationMinutes, DurationSeconds) = (artist, songTitle, durationMinutes, durationSeconds);
    }


    internal string Artist
    {
        get
        {
            return artist;
        }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            else
            {
                artist = value;
            }
        }
    }
    internal string SongTitle
    {
        get
        {
            return songTitle;
        }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidSongNameException();
            }
            else
            {
                songTitle = value;
            }
        }
    }


    internal int DurationMinutes
    {
        get
        {
            return durationMinutes;
        }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            else
            {
                durationMinutes = value;
                SongDuration += new TimeSpan(0, value, 0);
            }
        }
    }

    internal TimeSpan SongDuration { get; set; }

    internal int DurationSeconds
    {
        get
        {
            return durationSeconds;
        }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            else
            {
                durationSeconds = value;
                SongDuration += new TimeSpan(0, 0, value);
            }
        }
    }

    public override string ToString()
    {
        StringBuilder songData = new();

        songData.Append($"Artist: {Artist}");
        songData.Append($"Title: {SongTitle}");
        songData.Append($"Duration: {DurationMinutes}:${durationSeconds}");

        return songData.ToString();
    }

}



