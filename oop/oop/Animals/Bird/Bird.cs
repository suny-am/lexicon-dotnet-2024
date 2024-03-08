/*
3.3.13 

Q:
If during development we find that all birds need a new attribute, 
which class should we put it in?

A: 
Since Bird is the base for all deriving bird classes; new attributes should 
be located within it.
*/

using System.Text;

internal class Bird : Animal
{
    internal string? BeakColor { get; set; }

    internal Bird() { }

    internal Bird(string? beakColor)
    {
        BeakColor = beakColor;
    }

    internal override void DoSound()
    {
        Console.WriteLine("Chirp!~");
    }

    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Beak color: {BeakColor}");

        return stats.ToString();
    }
}