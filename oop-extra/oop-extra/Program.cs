Console.Clear();

// Assignment 1
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Assigntment 1:");
Console.ResetColor();

int personCount = 5;
List<Person> persons = [];

for (int i = 0; i < personCount; i++)
{
    Console.Write("Enter new person: (first name, last name, age)\n");
    var cmdArgs = Console.ReadLine().Split();
    Person person = new(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
    persons.Add(person);
}

Console.Clear();

persons.OrderBy(p => p.FirstName)
.ThenBy(p => p.Age)
.ToList()
.ForEach(p => Console.WriteLine(p.ToString()));


// Assignment 2-3
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\nAssigntment 2:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Enter how many persons you wish to create:");
Console.ResetColor();
int personCount2 = int.Parse(Console.ReadLine());
Console.Clear();
List<Person> persons2 = [];
for (int i = 0; i < personCount2; i++)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Enter new person: (first name, last name, age, salary)\n");
    Console.ResetColor();
    var cmdArgs = Console.ReadLine().Split();
    Person person = new(cmdArgs[0],
    cmdArgs[1],
   int.Parse(cmdArgs[2]),
   decimal.Parse(cmdArgs[3]));
    persons2.Add(person);
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Enter bonus increase percentage:");
decimal bonus = decimal.Parse(Console.ReadLine());
Console.ResetColor();
Console.Clear();

persons2.ForEach(p => p.IncreaseSalary(bonus));
persons2.ForEach(p => Console.WriteLine(p.ToString()));
