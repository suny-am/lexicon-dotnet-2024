using System.Text;

internal class Flamingo : Bird
{

    internal bool? HeadTucked { get; set; }

    internal Flamingo() { }

    internal Flamingo(bool? headTucked)
    {
        HeadTucked = headTucked;
    }

    internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"weight: {Weight}\n");
        stats.Append($"Head is tucked: {HeadTucked}");

        return stats.ToString();
    }

}