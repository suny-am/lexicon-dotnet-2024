namespace Garage_1_0.Library.UI;

public class ViewParamActionItem<T>(string title, Action<T> action) : ViewItem(title)
{
    private Action<T>? _action = action;

    public Action<T>? Action => _action;
}