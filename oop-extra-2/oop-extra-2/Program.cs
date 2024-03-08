Console.Clear();

// Assignment 1.
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Assignment 1:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Enter child name:");
Console.ResetColor();

string name = Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Enter child age:");
Console.ResetColor();

int age = int.Parse(Console.ReadLine());

try
{
    Child child = new Child(name, age);
    Console.WriteLine(child);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}

// Assignment 2.
try
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Assignment 2:");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Enter Author first name:");
    Console.ResetColor();
    string authorFirstName = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Enter Author last name:");
    Console.ResetColor();
    string authorLastName = Console.ReadLine();

    Author author = new(authorFirstName, authorLastName);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Enter book title:");
    Console.ResetColor();
    string title = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Enter book price:");
    decimal price = decimal.Parse(Console.ReadLine());
    Console.ResetColor();

    Book book = new Book(author, title, price);
    GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
    Console.WriteLine(book + Environment.NewLine);
    Console.WriteLine(goldenEditionBook);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}


// Assignment 3.
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Assignment 3:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Provide student info (first name, last name, faculty number)");
Console.ResetColor();
string[] studentInput = Console.ReadLine().Split(" ");
Console.Clear();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Provide worker info (first name, last name, salary per week, work hours per day)");
Console.ResetColor();
var workerInput = Console.ReadLine().Split(" ");

Student student = new(studentInput[0], studentInput[1], int.Parse(studentInput[2]));
Worker worker = new(workerInput[0], workerInput[1], decimal.Parse(workerInput[2]), decimal.Parse(workerInput[3]));

Console.WriteLine(student);
Console.WriteLine(worker);

// Assignment 4.
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Assignment 4:");
Console.ResetColor();

List<Song> songs = [];

int songCount = 2;

for (int i = 0; i < songCount; i++)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please provide a song (format: 'Artist;SongName;MM:SS'):");
        Console.ResetColor();
        string[] songData = Console.ReadLine().Split(";");

        string artist = songData[0];
        string songTitle = songData[1];
        string[] songDuration = songData[2].Split(":");
        int durationMinutes = int.Parse(songDuration[0]);
        int durationSeconds = int.Parse(songDuration[1]);

        Song song = new(artist, songTitle, durationMinutes, durationSeconds);
        Console.WriteLine("Song added");
        songs.Add(song);
    }
    catch (InvalidSongException exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(exception.Message);
        Console.ResetColor();
    }
}

TimeSpan playlistLength = new(0, 0, 0);

songs.ForEach((song) =>
{
    Console.WriteLine(song.SongDuration);
    playlistLength += song.SongDuration;
});

Console.WriteLine("Playlist length: " + playlistLength);