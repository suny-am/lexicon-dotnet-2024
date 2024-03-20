namespace Garage_1_0.Library.UI.Menus;

public class Menu(IEnumerable<IMenuOption> options) : IMenu
{
    private IEnumerable<IMenuOption> _menuOptions = options;

    public IEnumerable<IMenuOption> MenuOptions
    {
        get => _menuOptions;
        set => _menuOptions = value;
    }
}
