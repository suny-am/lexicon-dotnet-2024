namespace Garage_1_0.Library.UI;

public abstract class ViewItem : IViewItem
{
    private string _title;

    public ViewItem(string title)
    {
        _title = title;

    }
    public string Title => _title;
}