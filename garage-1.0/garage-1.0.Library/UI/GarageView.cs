
using System.Text.RegularExpressions;
using Garage_1_0.Library.Models;
using SuperConsole;

namespace Garage_1_0.Library.UI;

public partial class GarageView(string title, IEnumerable<IViewItem> viewItems) : UIView(title, viewItems)
{
    private static UI _ui = UI.Instance;
    private static IO _io = IO.Instance;

    // WIP! Need to make this less bloated; 
    // Garage  Repository and error handling does exist but not used yet...
    public static void New()
    {
        bool inputAccepted = false;
        Garage<ParkingSpot>? garageToCreate = null;
        do
        {
            Console.CursorVisible = true;
            _io.ClearAll();
            _io.Write("Specify a name for the garage", foreground: "green", newline: true);
            _io.Write("Garage name: ", foreground: "green");
            string? name = _io.ReadAndClear();
            if (name is null || name.Length is 0 || int.TryParse(name, out _) is true)
            {
                _io.Write("Invalid name input. Name cannot include digits and cannot be empty." +
                         "Press any key to contiue.", foreground: "red", newline: true);
                Console.ReadKey();
                continue;
            }
            if (UI.Instance.GarageList!.Any(g => g.Name == name))
            {
                _io.Write($"Garage with name \"{name}\" already exists." +
                        "Press any key to contiue.", foreground: "red", newline: true);
                Console.ReadKey();
                continue;
            }
            _io.Write(name, newline: true);
            _io.Write("Select a maximum parking capacity", foreground: "green", newline: true);
            _io.Write("Maximum Capacity: ", foreground: "green");
            bool validCapacity = int.TryParse(_io.ReadAndClear(), out int capacity);
            if (!validCapacity || capacity <= 0)
            {
                _io.Write("Invalid capacity input. Capacity value must be a positive integer." +
                        "Press any key to contiue.", foreground: "red", newline: true);
                Console.ReadKey();
                continue;
            }
            garageToCreate = new(name, capacity);
            var garageList = _ui.GarageList?.ToList();
            garageList!.Add(garageToCreate);
            _ui.GarageList = garageList.AsEnumerable();
            inputAccepted = true;
        }
        while (inputAccepted is false);

        bool complete = false;
        int activeIndex = 0;

        do
        {
            var backMenuItems = BackMenuItems("New");
            _io.ClearAll();
            Console.CursorVisible = false;
            _io.Write($"{garageToCreate!.Name} added to garage list." +
                        Environment.NewLine +
                        "Go back or continue?" +
                        Environment.NewLine +
                        "---",
                        foreground: "green", newline: true);

            foreach (var item in backMenuItems)
            {
                string color = "green";
                if (item == backMenuItems.ElementAt(activeIndex))
                {
                    color = "red";
                }
                _io.Write(item.Title, foreground: color, newline: true);
            }
            WatchInput(ref activeIndex, ref complete, backMenuItems);
        } while (!complete);

    }

    public static void Load()
    {
        bool complete = false;
        int activeIndex = 0;
        do
        {
            string color = "green";
            ViewActionItem<object>[] backMenuItems = BackMenuItems("Load");
            IEnumerable<ViewActionItem<object>> garageItemList;

            _io.ClearAll();
            if (!UI.Instance.GarageList!.Any())
            {
                _io.Write("No garages found.");
            }
            else if (UI.Instance.GarageList!.Count() == 1)
            {
                color = "red";
                var garage = UI.Instance.GarageList!.First();
                var garageActionItem = new ViewActionItem<Garage<ParkingSpot>>(garage.Name,
                                        action: null,
                                        paramsAction: garage => UI.Instance.SelectedGarage = garage);
                _io.Write(UI.Instance.GarageList!.ElementAt(0).Name, foreground: color, newline: true);
                WatchInput(ref activeIndex, ref complete, backMenuItems);
            }
            else
            {
                garageItemList = UI.Instance.GarageList!
                                .Select(g => new ViewActionItem<object>
                                (g.Name, action: null, paramsAction: garage => UI.Instance.SelectedGarage = (Garage<ParkingSpot>?)garage));
                foreach (var garage in UI.Instance.GarageList!)
                {
                    if (UI.Instance.GarageList.ElementAt(activeIndex) == garage)
                    {
                        color = "red";
                    }
                    _io.Write(garage.Name, foreground: color, newline: true);
                }
                WatchInput(ref activeIndex, ref complete, garageItemList);
            }
        } while (true);
    }

    public static void Delete()
    {
        bool complete = false;
        int activeIndex = 0;
        do
        {
            var backMenuItems = BackMenuItems("Delete");
            _io.ClearAll();
            if (!UI.Instance.GarageList!.Any())
            {
                _io.Write("No garages found.", foreground: "red", newline: true);
            }
            else
            {
                _io.Write("Select a garage to delete.", foreground: "green", newline: true);
                foreach (var garage in UI.Instance.GarageList!)
                {
                    string color = "green";
                    if (UI.Instance.GarageList.ElementAt(activeIndex) == garage)
                    {
                        color = "red";
                    }
                    _io.Write(garage.Name, foreground: color, newline: true);
                }
            }
            WatchInput(ref activeIndex, ref complete, backMenuItems);
        } while (true);
    }

    public static void BackToMainMenu()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }

    private static ViewActionItem<object>[] BackMenuItems(string context)
    {
        ViewActionItem<object> continueOption;

        if (context == "New")
        {
            continueOption = new("Continue", New, null);
        }
        else if (context == "Load")
        {
            continueOption = new("Load", Load, null);
        }
        else
        {
            continueOption = new("Delete", Delete, null);
        };

        ViewActionItem<object>[] backMenuItems =
      [
            continueOption,
            new("Back", action: _ui.Views.First(v => v.Title == "Garages").Enter, paramsAction: null)
      ];
        return backMenuItems;
    }

    // ,
    private static void WatchInput(ref int activeIndex, ref bool complete, IEnumerable<IViewActionItem<object>> viewItems)
    {
        var key = Console.ReadKey().Key;

        // prevent index overflow
        if (viewItems.Count() < 2) { return; }

        if (key is ConsoleKey.DownArrow && activeIndex < viewItems.Count() - 1)
        {
            activeIndex++;
        }
        else if (key is ConsoleKey.UpArrow && activeIndex > 0)
        {
            activeIndex--;
        }
        else if (key is ConsoleKey.Enter)
        {
            var targetItem = viewItems.ElementAt(activeIndex);

            {
                if (targetItem!.Action is not null)
                {
                    targetItem.Action.Invoke();
                }
                // we know this is an Action<T>
                else
                {
                    targetItem!.ParamsAction!.Invoke(targetItem.Title);
                }
            }
            complete = true;
        }
    }

    [GeneratedRegex(@"/[\d]/")]
    private static partial Regex InvalidGarageName();
}