public interface IViewItem
{
    public string Title { get; }
}

public interface IViewActionItem : IViewItem
{
    public Action Action { get; }
}