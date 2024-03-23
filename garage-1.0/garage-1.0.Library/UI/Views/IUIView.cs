namespace Garage_1_0.Library.UI.Views;

public interface IUIView
{
    public string Title { get; }
    public IEnumerable<IViewItem>? ViewMenuItems { get; }
    public void Enter();
}

