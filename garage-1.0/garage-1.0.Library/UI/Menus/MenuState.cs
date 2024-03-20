
namespace Garage_1_0.Library.UI.Menus;

public class MenuState : IMenuState
{
    private IMenu _activeMenu = default!;

    public IMenu ActiveMenu
    {
        get => _activeMenu;
        set => _activeMenu = value;
    }
}