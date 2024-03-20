using Garage_1_0.Library.UI.Menus;

public class MenuOption(string title, Action action) : IMenuOption
{
    private string _title = title;
    private Action _action = action;

    public string Title
    {
        get => _title;
        set => _title = value;
    }
    public Action Action
    {
        get => _action;
        set => _action = value;
    }
}
