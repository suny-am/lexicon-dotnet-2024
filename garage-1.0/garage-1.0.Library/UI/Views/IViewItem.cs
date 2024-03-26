namespace Garage_1_0.Library.UI;

public interface IViewItem
{
    public string Title { get; }
}

public interface IViewActionItem<T> : IViewItem
{
    public Action? Action { get; }
    public Action<T>? ParamsAction { get; }
}