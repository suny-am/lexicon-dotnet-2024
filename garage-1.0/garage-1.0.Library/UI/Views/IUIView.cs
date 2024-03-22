namespace Garage_1_0.Library.UI.Views;

public interface IUIView
{
    public string Title { get; }
    public IEnumerable<IViewItem> ViewItems { get; }
    public void Enter();
}

