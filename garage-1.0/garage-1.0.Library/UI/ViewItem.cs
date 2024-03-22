namespace Garage_1_0.Library.UI;

public abstract class ViewItem(string title) : IViewItem
{
    private string _title = title;

    public string Title => _title;
}