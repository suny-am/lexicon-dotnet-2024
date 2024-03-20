using Garage_1_0.Library.UI.Menus;

public class MenuBuilder(MenuState? state) : IMenuBuilder
{
    private MenuState? _state = state;

    public MenuState? State { get; set; }

    public void Build()
    {
        if (_state is null) throw new Exception("No state found");

        var options = _state.ActiveMenu.MenuOptions;

        foreach (var option in options)
        {
            Console.WriteLine(option.Title);
        }
    }
}