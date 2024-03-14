using Errors;
using SuperConsole;

IO io = IO.Instance;

io.ClearAll();

// 3.1.1-4.

/*
io.Write("\nAsssignment 3.1.1-4:\n", foreground: "cyan");

try
{
    Person person = new(1, "ab", "abc");
    Console.WriteLine(person.Age);
}
catch (ArgumentException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Error");
    throw;
}
 */

//  3.1.5.

io.Write("\nAsssignment 3.1.5:\n", foreground: "cyan");

PersonHandler pHandler = new();

for (int i = 1; i <= 3; i++)
{
    int age = new Random().Next(i, 50);
    Person person = pHandler.CreatePerson(age, "john", "doe");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Person {i}'s age:");
    Console.ResetColor();
    Console.WriteLine($"{person.Age}");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Person {i}'s given name:");
    Console.ResetColor();
    Console.WriteLine($"{person.FName}");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Person {i}'s surname:");
    Console.ResetColor();
    Console.WriteLine($"{person.LName}");
}

// 3.2.1-10.

io.Write("\nAsssignment 3.2.1-10:\n", foreground: "cyan");

List<UserError> userErrors = [];

for (int i = 0; i < 5; i++)
{
    switch (i)
    {
        case 0:
            {
                userErrors.Add(new NumericInputError());
                break;
            }
        case 1:
            {
                userErrors.Add(new TextInputError());
                break;
            }
        case 2:
            {
                userErrors.Add(new UIntInputError());
                break;
            }
        case 3:
            {
                userErrors.Add(new DoubleInputError());
                break;
            }
        case 4:
            {
                userErrors.Add(new BoolInputError());
                break;
            }
    }
}

foreach (UserError error in userErrors)
{
    io.Write(error.UEMessage(), foreground: "red", newline: true);
}

//  3.4.1-7.

io.Write("\nAsssignment 3.4.1-7:", foreground: "cyan");

List<Animal> animals = [];

animals.Add(new Dog(false));
animals.Add(new Bird("yellow"));
animals.Add(new Worm(true));
animals.Add(new Wolf("pale blue"));
animals.Add(new Horse("white"));
animals.Add(new Hedgehog(true));
animals.Add(new Wolfman());

animals.ForEach((animal) =>
{
    io.WriteEncoded($"[green]Species:[green] \n{animal.GetType().Name}\n[green]Sound:[green]\n");

    if (animal is IPerson wolfMan)
    {
        wolfMan.Talk();
    }
    else
    {
        animal.DoSound();
    }
});

/*

3.4.8-10.
Q: 
Why can't the Horse instance be added to List<Dog>?

A:
Because the list is created with a type notation of dog, 
meaning that only instances of the Dog class are accepted as input. 

Q:
What Type notation must the list have in order for any Animal instance
to be accepted as input?

A:
The list must have the notation of Animal (i.e. List<Animal>)

List<Dog> dogs = [];

dogs.Add(new Horse());
*/

// 3.4.11-14


io.Write("\nAsssignment 3.4.11-14:\n", foreground: "cyan");

animals.Add(new Pelican(true));
animals.Add(new Flamingo(false));
animals.Add(new Swan(true));

/*
Q: 
what happens here?

A: 
Since the abstract class Animal has a virtual method Stats(), other deriving
classes can override this method. thus, no matter which exact derivingclass,
Stats() will be available as long as it is implemented.

*/

animals.ForEach((animal) =>
{
    io.WriteEncoded($"{animal.GetType().Name} stats:[green]\n{animal.Stats()}[green]\n\n");
});

// 3.4.15-18

io.Write("\nAsssignment 3.4.15-18:", foreground: "cyan");

/*
Q:
Why can you not access the Fetch() method from an Animal class instance?

A:
because the method is only defined in the Dog class. A parent does not 
inherit deriving class methods.

To solve this we can type check and cast in one statement as below:
*/

animals.ForEach((animal) =>
{
    if (animal is Dog dog)
    {
        io.Write(dog.Fetch(), foreground: "magenta");
    }
});