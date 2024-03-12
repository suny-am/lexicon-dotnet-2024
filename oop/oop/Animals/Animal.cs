/*
3.3.14. 

Q: 
If all animals need the new attribute, where would you put it?

A:
Similarly to the previous question, an attribute required by all animals
should be located within the parent Anmimal class.

*/

using System.Text;

abstract internal class Animal
{

    internal string? Name { get; set; }
    internal int Age { get; set; }
    internal int Weight { get; set; }

    abstract internal void DoSound();

    internal Animal()
    {

        Name = this.GetType().Name;

    }

    internal virtual string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"Weight: {Weight}\n");

        return stats.ToString();
    }
}