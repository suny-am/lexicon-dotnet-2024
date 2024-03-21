namespace Garage_1_0.Library.UI;

public interface IUI
{
    public IEnumerable<IUIView> Views { get; }
    public void Quit();
}
