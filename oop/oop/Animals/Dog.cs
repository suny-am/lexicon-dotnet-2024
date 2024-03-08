using System.Text;

internal class Dog : Animal
{
    internal bool? ThickFur { get; set; }

    internal Dog()
    {
        Name = "this dog";
    }

    internal Dog(bool? thickFur): this()
    {
        ThickFur = thickFur;
    }

    internal override void DoSound()
    {
        Console.WriteLine("Woof!~");
    }

    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Has thick fur: {ThickFur}");

        return stats.ToString();
    }

    internal string Fetch()
    {
        return $"Look at {Name} go!";
    }
}