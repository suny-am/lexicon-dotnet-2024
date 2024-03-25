namespace Garage_1_0.Library.UI.Views;

using Garage_1_0.Library.Models;
using SuperConsole;

public partial class GarageView() : MainMenuView()
{
    private static UI _ui = UI.Instance;
    private static IO _io = IO.Instance;
    private string _title = "Garages";
    private IEnumerable<IViewItem> _viewMenuItems =
    [
        new ViewActionItem<object>("New", New, null),
        new ViewActionItem<object>("Load", Load, null),
        new ViewActionItem<object>("Delete", Delete, null),
        new ViewActionItem<object>("Back", BackToMainMenu, null)
    ];

    public override IEnumerable<IViewItem> ViewMenuItems => _viewMenuItems;
    public override string Title => _title;

    // WIP! Need to make this less bloated; 
    // Garage  Repository and error handling does exist but not used yet...
    public static void New()
    {
        bool operationComplete = false;
        Garage<IParkingSpot>? garageToCreate = null;
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
                        Environment.NewLine +
                         "Press any key to contiue.", foreground: "red", newline: true);
                Console.ReadKey();
                continue;
            }
            // TBD! use Garage Repository
            if (_ui.GarageList!.Any(g => g.Name == name))
            {
                _io.Write($"Garage with name \"{name}\" already exists." +
                        "Press any key to contiue.", foreground: "red", newline: true);
                Console.ReadKey();
                continue;
            }
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
            var garageList = _ui.GarageList!.ToList();
            garageList!.Add(garageToCreate);
            _ui.GarageList = garageList;
            operationComplete = true;
            if (_ui.SelectedGarage is null)
                _ui.SelectedGarage = garageToCreate;
        }
        while (operationComplete is false);

        bool unitComplete = false;
        ActiveIndex = 0;
        var backMenuItems = BackMenuItems("New");

        do
        {
            _io.ClearAll();
            Console.CursorVisible = false;
            _io.WriteEncoded($"[blue]{garageToCreate!.Name}[blue][green] added to garage list." +
                        Environment.NewLine +
                        "Go back or continue?[green]" +
                        Environment.NewLine +
                        "---" +
                        Environment.NewLine);

            foreach (var item in backMenuItems)
            {
                string color = "green";
                if (item == backMenuItems.ElementAt(ActiveIndex))
                {
                    color = "red";
                }
                _io.Write(item.Title, foreground: color, newline: true);
            }
            WatchInput(ref unitComplete, backMenuItems);
        } while (!unitComplete);

    }

    public static void Load()
    {
        bool operationComplete = false;
        ActiveIndex = 0;
        do
        {
            string color = "green";
            ViewActionItem<object>[] backMenuItems = BackMenuItems("Load");
            _io.ClearAll();
            if (!_ui.GarageList!.Any())
            {
                _io.WriteEncoded($"[red]No garages found." +
                               Environment.NewLine +
                               "Press any key to continue[red]");
                WatchInput(ref operationComplete, backMenuItems);
            }
            else if (_ui.GarageList!.Count() == 1)
            {
                color = "red";
                var garage = _ui.GarageList!.First();
                var garageActionItem = new ViewActionItem<object>(garage.Name, null, LoadGarage);
                _io.Write(_ui.GarageList!.ElementAt(0).Name, foreground: color, newline: true);
                WatchInput(ref operationComplete, backMenuItems);
            }
            else
            {
                try
                {
                    // TBD! use Garage Repository to create suitable items instead
                    var garageItemList = _ui.GarageList!
                                   .Select(g => new ViewActionItem<IGarage<IParkingSpot>>
                                   (g.Name, null, LoadGarage));
                    _io.Write("Select a garage to load:", foreground: "green", newline: true);
                    foreach (var garage in _ui.GarageList!)
                    {
                        color = "green";
                        if (_ui.GarageList.ElementAt(ActiveIndex) == garage)
                        {
                            color = "red";
                        }
                        _io.Write(garage.Name, foreground: color, newline: true);
                    }
                    WatchInput(ref operationComplete, garageItemList);
                }
                catch (ArgumentException ex)
                {
                    _io.Write(ex.Message, foreground: "red", newline: true);
                }
            }
        } while (!operationComplete);
    }

    public static void Delete()
    {
        bool operationComplete = false;
        ActiveIndex = 0;
        string targetGarageName = "";
        ViewActionItem<object>[] backMenuItems = BackMenuItems("Delete");

        do
        {
            _io.ClearAll();
            if (!UI.Instance.GarageList!.Any())
            {
                _io.WriteEncoded($"[red]No garages found." +
                                Environment.NewLine +
                                "Press any key to continue[red]");
                WatchInput(ref operationComplete, backMenuItems);
            }
            else
            {
                // TBD! use Garage Repository to create suitable items instead
                var garageItemList = _ui.GarageList!
                                    .Select(g => new ViewActionItem<IGarage<IParkingSpot>>
                                    (g.Name, null, DeleteGarage));
                try
                {
                    _io.Write("Select a garage to delete:", foreground: "green", newline: true);
                    foreach (var garage in _ui.GarageList!)
                    {
                        string color = "green";
                        if (_ui.GarageList.ElementAt(ActiveIndex) == garage)
                        {
                            targetGarageName = garage.Name;
                            color = "red";
                        }
                        _io.Write(garage.Name, foreground: color, newline: true);
                    }
                }
                catch (Exception ex)
                {
                    _io.Write(ex.Message, foreground: "red", newline: true);
                }
                WatchInput(ref operationComplete, garageItemList);
            }
        } while (!operationComplete);

        bool unitComplete = false;
        ActiveIndex = 0;

        do
        {
            _io.ClearAll();
            Console.CursorVisible = false;
            _io.WriteEncoded($"[red]{targetGarageName}[red][green] deleted" +
                        Environment.NewLine +
                        "Go back or continue?[green]" +
                        Environment.NewLine +
                        "---" +
                        Environment.NewLine);

            foreach (var item in backMenuItems)
            {
                string color = "green";
                if (item == backMenuItems.ElementAt(ActiveIndex))
                {
                    color = "red";
                }
                _io.Write(item.Title, foreground: color, newline: true);
            }
            WatchInput(ref unitComplete, backMenuItems);
        } while (!unitComplete);
    }

    public static void BackToMainMenu()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }

    private static void LoadGarage(object garageToLoad)
    {
        if (garageToLoad is not Garage<IParkingSpot>)
            throw new ArgumentException("Invalid object type for Load operation");
        _ui.SelectedGarage = (Garage<IParkingSpot>?)garageToLoad;
    }

    private static void DeleteGarage(IGarage<IParkingSpot> garageToDelete)
    {
        if (garageToDelete is null)
            throw new ArgumentException("Invalid object type for Delete operation");
        if (_ui.SelectedGarage == garageToDelete)
        {
            _ui.SelectedGarage = null;
        }
        var garageTempList = _ui.GarageList!.ToList();
        garageTempList.Remove(garageToDelete);
        _ui.GarageList = garageTempList;
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


}