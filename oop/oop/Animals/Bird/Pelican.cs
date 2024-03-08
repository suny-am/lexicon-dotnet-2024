using System.Text;

internal class Pelican : Bird
{

    internal bool? MouthFilled { get; set; }

    internal Pelican() { }

    internal Pelican(bool? mouthFilled)
    {
        MouthFilled = mouthFilled;
    }

       internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Mouth is full: {MouthFilled}");

        return stats.ToString();
    }

}