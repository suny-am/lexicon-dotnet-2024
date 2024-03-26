namespace Garage_1_0.Library.UI.Views;

using Garage_1_0.Library.Models;
using SuperConsole;

public class MainMenuView(IEnumerable<IViewItem>? viewMenuItems = null) : IUIView
{
    private string _title = "Main Menu";
    private IEnumerable<IViewItem>? _viewMenuItems = viewMenuItems;
    private static int _activeIndex = 0;

    protected static UI _ui = UI.Instance;
    protected static IO _io = IO.Instance;

    protected static bool _operationComplete;
    protected static bool _unitComplete;

    public virtual string Title => _title;
    public virtual IEnumerable<IViewItem>? ViewMenuItems => _viewMenuItems;
    public static int ActiveIndex { get => _activeIndex; set => _activeIndex = value; }

    public virtual void Enter()
    {
        // make sure a garage is selected before entering VehicleView
        if (Title == "Vehicles" && _ui.SelectedGarage is null)
        {
            _io.Write("A garage must be selected.", foreground: "red", newline: true);
            Console.ReadKey();
            return;
        }
        // watch input as long as the view is active
        _ui.ActiveView = this;
        do
        {
            WatchInput();
        } while (_ui.ActiveView == this);
    }

    private void Render()
    {
        Console.CursorVisible = false;
        _io.ClearAll();
        SetHeader();
        _io.WriteEncoded(_ui.Header ?? "");

        var viewMenuItems = ViewMenuItems!.Select((item, index) => new { index, item });

        foreach (var item in viewMenuItems)
        {
            string color = "green";
            if (item.index == ActiveIndex)
            {
                color = "red";
            }
            _io.Write(item.item.Title, foreground: color, newline: true);
        }
    }

    private void SetHeader()
    {
        _ui.Header = $"[cyan]{_ui.Title}" +
             Environment.NewLine +
             "---" +
             Environment.NewLine +
                Title +
             Environment.NewLine +
             "---" +
             Environment.NewLine +
            SelectedGarageInfo() +
             Environment.NewLine +
             "[cyan]---[cyan]" +
             Environment.NewLine;
    }

    private static string SelectedGarageInfo()
    {
        string garageInfo;
        if (_ui.SelectedGarage is null)
        {
            garageInfo = "No garage selected";
        }
        else
        {
            garageInfo = $"Selected garage: [cyan][magenta]{_ui.SelectedGarage?.Name}[magenta]" +
                        $" [Capacity: {_ui.SelectedGarageCapacity}/{_ui.SelectedGarage!.VehicleCapacity}]";
        }
        return garageInfo;
    }

    private void WatchInput()
    {
        do
        {
            Render();
            var key = Console.ReadKey().Key;

            if (key is ConsoleKey.Enter)
            {
                var activeItem = ViewMenuItems!.ElementAt(ActiveIndex) as ViewActionItem<object>;
                activeItem?.Action!.Invoke();
            }
            else if (key is ConsoleKey.DownArrow && ActiveIndex < ViewMenuItems!.Count() - 1)
            {
                ActiveIndex++;
            }
            else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
            {
                ActiveIndex--;
            }
        } while (true);
    }

    protected static void CancelOperation()
    {
        var key = Console.ReadKey().Key;
        if (key is ConsoleKey.Q)
        {
            _operationComplete = true;
            _unitComplete = true;
        }
    }

    protected static void WatchInput(ref bool complete, IEnumerable<ViewActionItem<object>> viewMenuItems)
    {
        Console.CursorVisible = false;
        var key = Console.ReadKey().Key;
        // prevent index overflow
        if (viewMenuItems!.Count() < 2) { complete = true; }

        if (key is ConsoleKey.DownArrow && ActiveIndex < viewMenuItems!.Count() - 1)
        {
            ActiveIndex++;
        }
        else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
        {
            ActiveIndex--;
        }
        else if (key is ConsoleKey.Enter)
        {
            var targetItem = viewMenuItems!.ElementAt(ActiveIndex);
            targetItem.Action!.Invoke();
            complete = true;
        }
        else if (key is ConsoleKey.Q)
        {
            _operationComplete = true;
            _unitComplete = true;
        }
    }

    // necessary overload
    protected static void WatchInput(ref bool complete, IEnumerable<IViewActionItem<IGarage<IParkingSpot>>> garageItems)
    {
        Console.CursorVisible = false;
        var key = Console.ReadKey().Key;
        // prevent index overflow
        if (garageItems!.Count() < 2) { complete = true; }

        if (key is ConsoleKey.DownArrow && ActiveIndex < garageItems!.Count() - 1)
        {
            ActiveIndex++;
        }
        else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
        {
            ActiveIndex--;
        }
        else if (key is ConsoleKey.Enter)
        {
            var targetItem = garageItems?.ElementAt(ActiveIndex);
            IGarage<IParkingSpot>? targetGarage = _ui.GarageList!
                                                .FirstOrDefault(g => g.Name == targetItem!.Title)
                                                ?? throw new ArgumentException("Target not found");
            targetItem!.ParamsAction!.Invoke(targetGarage);
            complete = true;
        }
        else if (key is ConsoleKey.Q)
        {
            _operationComplete = true;
            _unitComplete = true;
        }
    }
}