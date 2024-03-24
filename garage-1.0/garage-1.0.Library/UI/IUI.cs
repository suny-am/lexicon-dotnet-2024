namespace Garage_1_0.Library.UI;

using Garage_1_0.Library.UI.Views;

public interface IUI
{
    public string? Title { get; set; }
    public IEnumerable<IUIView> Views { get; }
    public void Quit();
}
