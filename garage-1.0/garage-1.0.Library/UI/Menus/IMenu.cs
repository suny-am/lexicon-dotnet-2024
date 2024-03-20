namespace Garage_1_0.Library.UI.Menus;

public interface IMenu
{
    public IEnumerable<IMenuOption> MenuOptions { get; set; }
}