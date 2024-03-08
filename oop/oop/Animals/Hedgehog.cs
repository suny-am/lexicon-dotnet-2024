using System.Text;

internal class Hedgehog : Animal
{
    internal bool? IsFast { get; set; }

    internal Hedgehog() { }

    internal Hedgehog(bool? isFast)
    {
        IsFast = isFast;
    }

    internal override void DoSound()
    {
        Console.WriteLine("Gotta go fast!~");
    }

        internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Is fast: {IsFast}");

        return stats.ToString();
    }
}