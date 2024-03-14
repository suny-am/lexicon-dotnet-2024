using SuperConsole;

IO io = IO.Instance;
io.ClearAll();

// Assignment 1

io.Write("Assigntment 1:", foreground: "green", newline: true);

int personCount = 5;
List<Person> persons = [];

for (int i = 0; i < personCount; i++)
{
    io.Write("Enter new person: (first name, last name, age)\n", foreground: "green", newline: true);
    var cmdArgs = Console.ReadLine().Split();
    Person person = new(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
    persons.Add(person);
}

io.ClearAll();

persons.OrderBy(p => p.FirstName)
.ThenBy(p => p.Age)
.ToList()
.ForEach(p => io.Write(p.ToString(), foreground: "magenta", newline: true));

// Assignment 2-3

io.Write("\n\nAssigntment 2:", foreground: "green");

io.Write("Enter how many persons you wish to create:", foreground: "cyan", newline: true);

int personCount2 = int.Parse(Console.ReadLine());
io.ClearAll();
List<Person> persons2 = [];
for (int i = 0; i < personCount2; i++)
{
    io.Write("Enter new person: (first name, last name, age, salary)\n", foreground: "cyan");
    var cmdArgs = Console.ReadLine().Split();
    Person person = new(cmdArgs[0],
    cmdArgs[1],
   int.Parse(cmdArgs[2]),
   decimal.Parse(cmdArgs[3]));
    persons2.Add(person);
}

io.Write("Enter bonus increase percentage:", foreground: "cyan", newline: true);
decimal bonus = decimal.Parse(Console.ReadLine());
io.ClearAll();

persons2.ForEach(p => p.IncreaseSalary(bonus));
persons2.ForEach(p => io.Write(p.ToString(), foreground: "magenta", newline: true));
