using System.Runtime.CompilerServices;
using Garage_1_0.Library.UI.Menus;

UIManager.Init();

public static class UIManager
{
    private static bool running;
    private static int _activeOptionIndex = 0;
    private readonly static IEnumerable<MenuOption> mainMenuOptions = [
        new(title: "Sub menu 1", SubMenu1),
        new(title: "Sub menu 2", SubMenu2),
        new(title: "Quit", Quit),
    ];
    private readonly static IEnumerable<MenuOption> subMenu1Options = [
        new(title: "Action 1", Action1),
        new(title: "Back", Back),
    ];
    private readonly static IEnumerable<MenuOption> subMenu2Options = [
        new(title: "Action 2", Action2),
        new(title: "Back", Back),
    ];

    private readonly static Menu mainMenu = new(mainMenuOptions);
    private readonly static Menu subMenu1 = new(subMenu1Options);
    private readonly static Menu subMenu2 = new(subMenu2Options);

    private static MenuState _state = new()
    {
        ActiveMenu = mainMenu
    };


    public static MenuState State { get => _state; set => _state = value; }

    private readonly static MenuBuilder menuBuilder = new(State);

    public static int ActiveOptionIndex { get => _activeOptionIndex; set => _activeOptionIndex = value; }


    public static void Init()
    {
        Render();
        Console.CursorVisible = false;
        running = true;
        do
        {
            WatchInput();
        } while (running);
    }

    public static void Render()
    {
        Console.Clear();
        var activeOptions = State.ActiveMenu.MenuOptions.Select((option, index) => new { option, index });

        foreach (var option in activeOptions)
        {
            if (option.index == ActiveOptionIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(option.option.Title);
            Console.ResetColor();
        }
    }

    public static void WatchInput()
    {
        var input = Console.ReadKey();

        if (input.Key is ConsoleKey.UpArrow && ActiveOptionIndex > 0)
        {
            ActiveOptionIndex--;
        }
        else if (input.Key is ConsoleKey.DownArrow && ActiveOptionIndex < State.ActiveMenu.MenuOptions.Count() - 1)
        {
            ActiveOptionIndex++;
        }
        else if (input.Key is ConsoleKey.Enter)
        {
            var activeOptions = State.ActiveMenu.MenuOptions.Select((option, index) => new { option, index });
            activeOptions.ElementAt(ActiveOptionIndex).option.Action.Invoke();
        }
        Render();
    }

    public static void SubMenu1()
    {
        State.ActiveMenu = subMenu1;
    }

    public static void SubMenu2()
    {
        State.ActiveMenu = subMenu2;
    }

    public static void Quit()
    {
        running = false;
        Console.Clear();
    }

    public static void Back()
    {
        State.ActiveMenu = mainMenu;
    }

    public static void Action1()
    {

    }

    public static void Action2()
    {

    }
}


