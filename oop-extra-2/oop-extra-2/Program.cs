using SuperConsole;

IO io = IO.Instance;

io.ClearAll();

// Assignment 1.
io.Write("Assignment 1:", foreground: "magenta", newline: true);

io.Write("Enter child name:", foreground: "green", newline: true);
string name = Console.ReadLine();

io.Write("Enter child age:", foreground: "green", newline: true);
int age = int.Parse(Console.ReadLine());

try
{
    Child child = new Child(name, age);
    io.Write($"{child}", newline: true);
}
catch (ArgumentException ae)
{
    io.Write(ae.Message, foreground: "red", newline: true);
}

// Assignment 2.
try
{
    io.Write("Assignment 2:", foreground: "magenta", newline: true);

    io.Write("Enter Author first name:", foreground: "green", newline: true);
    string authorFirstName = Console.ReadLine();

    io.Write("Enter Author last name:", foreground: "green", newline: true);
    string authorLastName = Console.ReadLine();

    Author author = new(authorFirstName, authorLastName);

    io.Write("Enter Book title:", foreground: "green", newline: true);
    string title = Console.ReadLine();

    io.Write("Enter Book Price:", foreground: "green", newline: true);
    decimal price = decimal.Parse(Console.ReadLine());

    Book book = new Book(author, title, price);
    GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

    io.WriteEncoded($"[blue]{book}[blue]\n[yellow]{goldenEditionBook}[yellow]");
}
catch (ArgumentException ae)
{
    io.Write(ae.Message, foreground: "red", newline: true);
}

// Assignment 3.
io.Write("Assignment 3:", foreground: "magenta", newline: true);

io.Write("Provide student info (first name, last name, faculty number)", foreground: "green", newline: true);
string[] studentInput = Console.ReadLine().Split(" ");
io.ClearAll();

Console.ForegroundColor = ConsoleColor.Green;
io.Write("Provide worker info (first name, last name, salary per week, work hours per day)", foreground: "green", newline: true);
var workerInput = Console.ReadLine().Split(" ");

Student student = new(studentInput[0], studentInput[1], int.Parse(studentInput[2]));
Worker worker = new(workerInput[0], workerInput[1], decimal.Parse(workerInput[2]), decimal.Parse(workerInput[3]));

io.ClearAll();

io.Write($"Student:\n{student}", newline: true);
io.Write($"Worker:\n{worker}", newline: true);

// Assignment 4.
io.Write("Assignment 4:", foreground: "magenta", newline: true);


List<Song> songs = [];

int songCount = 2;

for (int i = 0; i < songCount; i++)
{
    try
    {
        io.Write("Please provide a song (format: 'Artist;SongName;MM:SS'):", foreground: "green", newline: true);
        string[] songData = Console.ReadLine().Split(";");

        string artist = songData[0];
        string songTitle = songData[1];
        string[] songDuration = songData[2].Split(":");
        int durationMinutes = int.Parse(songDuration[0]);
        int durationSeconds = int.Parse(songDuration[1]);

        Song song = new(artist, songTitle, durationMinutes, durationSeconds);
        io.Write("Song added", foreground: "green", newline: true);
        songs.Add(song);
    }
    catch (InvalidSongException exception)
    {
        io.Write(exception.Message, foreground: "red", newline: true);
    }
}

TimeSpan playlistLength = new(0, 0, 0);

songs.ForEach((song) =>
{
    io.WriteEncoded($"[green]Song length:[green] {song.SongDuration}\n");
    playlistLength += song.SongDuration;
});

io.WriteEncoded("[green]Playlist length:[green] " + playlistLength);