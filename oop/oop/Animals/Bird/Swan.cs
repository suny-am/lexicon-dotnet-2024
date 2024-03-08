using System.Text;

internal class Swan : Bird
{

    internal bool? IsBlack { get; set; }

    internal Swan() { }

    internal Swan(bool? isBlack)
    {
        IsBlack = isBlack;
    }

       internal override string Stats()
    {
        StringBuilder stats = new();

        stats.Append($"Name: {Name}\n");
        stats.Append($"Age: {Age}\n");
        stats.Append($"Weight: {Weight}\n");
        stats.Append($"Is black: {IsBlack}");

        return stats.ToString();
    }

}