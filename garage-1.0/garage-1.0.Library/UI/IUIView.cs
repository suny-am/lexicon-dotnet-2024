namespace Garage_1_0.Library.UI;

public interface IUIView
{
    public UI ParentUI { get; }
    public string Title { get; }
    public IEnumerable<IViewItem> ViewItems { get; }
    public void Enter();
}

