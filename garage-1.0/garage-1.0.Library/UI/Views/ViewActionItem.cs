namespace Garage_1_0.Library.UI.Views;

public class ViewActionItem<T>(string title, Action? action, Action<T>? paramsAction) : ViewItem(title), IViewItem, IViewActionItem<T>
{
    public Action? Action { get; } = action;
    public Action<T>? ParamsAction { get; } = paramsAction;
}