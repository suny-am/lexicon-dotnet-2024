using System.Text;

internal class Horse : Animal
{
    internal string? ManeColor { get; set; }

    internal Horse() { }

    internal Horse(string? maneColor)
    {
        ManeColor = maneColor;
    }

    internal override void DoSound()
    {
        Console.WriteLine("Neigh!~");
    }

    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Mane color: {ManeColor}");

        return stats.ToString();
    }
}