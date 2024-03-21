namespace Garage_1_0.Library.UI;

public class ViewActionItem(string title, Action action) : ViewItem(title)
{
    private Action? _action = action;

    public Action? Action => _action;
}