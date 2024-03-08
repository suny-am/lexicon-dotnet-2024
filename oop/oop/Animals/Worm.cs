using System.Text;

internal class Worm : Animal
{
    internal bool? IsCute { get; set; }

    internal Worm() { }

    internal Worm(bool? isCute)
    {
        IsCute = isCute;
    }

    internal override void DoSound()
    {
        Console.WriteLine("I make sounds?");
    }

    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Is cute: {IsCute} ");

        return stats.ToString();
    }
}