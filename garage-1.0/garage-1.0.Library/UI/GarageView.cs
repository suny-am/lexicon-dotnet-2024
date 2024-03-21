
using Garage_1_0.Library.Models;
using SuperConsole;

namespace Garage_1_0.Library.UI;

public class GarageView(string title, IEnumerable<IViewItem> viewItems) : UIView(title, viewItems)
{
    private static UI _ui = UI.Instance;
    private static IO _io = IO.Instance;

    public static void New()
    {
        Console.CursorVisible = true;
        _io.ClearAll();
        _io.Write("Specify a name for the garage", foreground: "green", newline: true);
        _io.Write("Garage name: ", foreground: "green");
        string? name = _io.ReadAndClear();
        if (name is null)
        {
            _io.Write("Invalid name input", foreground: "red", newline: true); return;
        }

        _io.Write("Select a maximum parking capacity", foreground: "green", newline: true);
        _io.Write("Maximum Capacity: ", foreground: "green");
        bool validCapacity = int.TryParse(_io.ReadAndClear(), out int capacity);
        if (!validCapacity || capacity <= 0)
        {
            _io.Write("Invalid capacity input", foreground: "red", newline: true); return;
        }

        Garage<ParkingSpot> newGarage = new(name, capacity);
        var garageList = _ui.GarageList?.ToList();
        garageList!.Add(newGarage);
        _ui.GarageList = garageList.AsEnumerable();
        _io.Write($"{newGarage.Name} added to garage list.", foreground: "green", newline: true);

        _io.Write("Go back or continue?", foreground: "green", newline: true);

    }

    public static void Load()
    {
        throw new NotImplementedException();
    }

    public static void Delete()
    {
        throw new NotImplementedException();
    }

    public static void Back()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }
}