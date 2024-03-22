using Garage_1_0.Library.Models;
using SuperConsole;

namespace Garage_1_0.Library.UI.Views;

public class UIView(string title, IEnumerable<IViewItem> viewItems) : IUIView
{
    private IO _io = IO.Instance;
    private static UI _ui = UI.Instance;
    private string _title = title;
    private IEnumerable<IViewItem> _viewItems = viewItems;
    private static int _activeIndex = 0;

    public string Title => _title;
    public IEnumerable<IViewItem> ViewItems => _viewItems;
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

        var viewItems = ViewItems.Select((item, index) => new { index, item });

        foreach (var item in viewItems)
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
        _ui.Header = "[cyan]Garage 1.0" +
             Environment.NewLine +
             "---" +
             Environment.NewLine +
                Title +
             Environment.NewLine +
             "---" +
             Environment.NewLine +
             $"Selected garage: [magenta]{UI.Instance.SelectedGarage?.Name
             ?? "No garage selected"}[magenta]" +
             Environment.NewLine +
             "[cyan]---[cyan]" +
             Environment.NewLine;
    }

    protected void WatchInput()
    {
        do
        {
            Render();
            var key = Console.ReadKey().Key;

            if (key is ConsoleKey.Enter)
            {
                var activeItem = ViewItems.ElementAt(ActiveIndex) as ViewActionItem<object>;
                activeItem?.Action!.Invoke();
            }
            else if (key is ConsoleKey.DownArrow && ActiveIndex < ViewItems.Count() - 1)
            {
                ActiveIndex++;
            }
            else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
            {
                ActiveIndex--;
            }
        } while (true);
    }

    protected static void WatchInput(ref bool complete, IEnumerable<ViewActionItem<object>> viewItems)
    {
        var key = Console.ReadKey().Key;
        // prevent index overflow
        if (viewItems!.Count() < 2) { complete = true; }

        if (key is ConsoleKey.DownArrow && ActiveIndex < viewItems!.Count() - 1)
        {
            ActiveIndex++;
        }
        else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
        {
            ActiveIndex--;
        }
        else if (key is ConsoleKey.Enter)
        {
            var targetItem = viewItems!.ElementAt(ActiveIndex);
            targetItem.Action!.Invoke();
            complete = true;
        }
    }

    // necessary overload
    protected static void WatchInput(ref bool complete, IEnumerable<ViewActionItem<Garage<ParkingSpot>>> garageItems)
    {
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
            Garage<ParkingSpot>? targetGarage = _ui.GarageList!
                                                .FirstOrDefault(g => g.Name == targetItem!.Title)
                                                ?? throw new ArgumentException("Target not found");
            targetItem!.ParamsAction!.Invoke(targetGarage);
            complete = true;
        }
    }

}