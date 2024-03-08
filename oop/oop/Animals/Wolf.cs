using System.Text;

internal class Wolf : Animal
{
    internal string? EyeColor { get; set; }

    internal Wolf() { }

    internal Wolf(string? eyeColor)
    {
        EyeColor = eyeColor;
    }

    internal override void DoSound()
    {
        Console.WriteLine("Grrr!~");
    }
    
    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Eye color: {EyeColor}");

        return stats.ToString();
    }
}