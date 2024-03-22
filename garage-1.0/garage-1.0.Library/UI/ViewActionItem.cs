namespace Garage_1_0.Library.UI;

public class ViewActionItem(string title, Action action) : ViewItem(title), IViewActionItem
{
    public Action? Action { get; } = action;
}