namespace Garage_1_0.Library.UI.Views;

using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using Garage_1_0.Library.Utilities;

public class VehicleView() : MainMenuView()
{
    private string _title = "Vehicles";
    private IEnumerable<IViewItem> _viewMenuItems =
    [
        new ViewActionItem<object>("Register", Register, null),
        new ViewActionItem<object>("Deregister", Deregister, null),
        new ViewActionItem<object>("Search", Search, null),
        new ViewActionItem<object>("Back", BackToMainMenu, null)
    ];
    // TBD! need to guard against null value here.
    private static VehicleRepository<IVehicle>? _vehicleRepository = new(_ui.GarageList!.First());

    public override IEnumerable<IViewItem> ViewMenuItems => _viewMenuItems;
    public VehicleRepository<IVehicle>? VehicleRepository { get => _vehicleRepository; set => _vehicleRepository = value; }
    public override string Title => _title;

    public static void Register()
    {
        bool operationComplete = false;
        IVehicle? vehicleToCreate = null;
        do
        {
            try
            {
                string vehicleType;
                string vehicleColor = null!;
                string vehicleModel = null!;
                string registrationNumber = null!;

                _io.ClearAll();
                Console.CursorVisible = true;
                _io.WriteEncoded("[green]What kind of vehicle do you want to register?[green]" +
                          Environment.NewLine +
                          "(Available options: [red]Car[red], [yellow]Bus[yellow], [cyan]Motorcycle[cyan], " +
                          "[magenta]Boat[magenta], [blue]Airplane[blue])" +
                          Environment.NewLine +
                          "[green]---[green]" +
                          Environment.NewLine);
                vehicleType = _io.ReadAndClear()?.ToLower()!;

                SetVehicleParams(ref registrationNumber, ref vehicleColor, ref vehicleModel);

                // WIP! Allow user to specify extra attributes for vehicle in addition to the required ones
                try
                {
                    switch (vehicleType)
                    {
                        case "car":
                            {
                                _io.WriteEncoded("[green]Is the car electric (Y/N)?[green]" +
                                             Environment.NewLine +
                                            "[green]---[green]" +
                                             Environment.NewLine);
                                bool electric = false;
                                bool electricVerified = false;
                                do
                                {
                                    var key = Console.ReadKey().Key;
                                    if (key is ConsoleKey.Y)
                                    {
                                        electric = true;
                                        electricVerified = true;
                                    }
                                    else if (key is ConsoleKey.N)
                                    {
                                        electric = false;
                                        electricVerified = true;
                                    }

                                } while (!electricVerified);

                                vehicleToCreate = new Car(registrationNumber!, electric, vehicleColor, vehicleModel);
                                break;
                            }
                        case "bus":
                            {
                                _io.WriteEncoded("[green]Specify the wheel count of the bus:[green]" +
                                                 Environment.NewLine +
                                                "[green]---[green]" +
                                                 Environment.NewLine);

                                _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int wheelCount);

                                _io.WriteEncoded("[green]Specify the fuel type of the bus:[green]" +
                                                 Environment.NewLine +
                                                "[green]---[green]" +
                                                 Environment.NewLine);

                                var fuelType = _io.ReadAndClear()?.ToLower();

                                vehicleToCreate = new Bus(registrationNumber!, fuelType!, wheelCount, vehicleColor, vehicleModel);
                                break;
                            }
                        case "motorcycle":
                            {
                                _io.WriteEncoded("[green]Specify the seat count of the motorcycle:[green]" +
                                                 Environment.NewLine +
                                                "[green]---[green]" +
                                                 Environment.NewLine);

                                _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int seatCount);

                                vehicleToCreate = new Motorcycle(registrationNumber!, seatCount, vehicleColor, vehicleModel);
                                break;
                            }
                        case "boat":
                            {
                                _io.WriteEncoded("[green]Does the boat have sails? (Y/N):[green]" +
                                                 Environment.NewLine +
                                                "[green]---[green]" +
                                                 Environment.NewLine);
                                bool sail = false;
                                bool sailVerified = false;
                                do
                                {
                                    var key = Console.ReadKey().Key;
                                    if (key is ConsoleKey.Y)
                                    {
                                        sail = true;
                                        sailVerified = true;
                                    }
                                    else if (key is ConsoleKey.N)
                                    {
                                        sail = false;
                                        sailVerified = true;
                                    }

                                } while (!sailVerified);

                                vehicleToCreate = new Boat(registrationNumber!, sail, vehicleColor, vehicleModel);
                                break;
                            }
                        case "airplane":
                            {
                                _io.WriteEncoded("[green]Specify the engine count of the plane:[green]" +
                                                Environment.NewLine +
                                                "[green]---[green]" +
                                                 Environment.NewLine);
                                _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int engineCount);

                                vehicleToCreate = new Airplane(registrationNumber!, engineCount, vehicleColor, vehicleModel);
                                break;
                            }
                    }
                }
                catch (ArgumentException)
                {
                    throw;
                }
                _vehicleRepository!.Add(vehicleToCreate!);
                operationComplete = true;
            }
            catch (Exception ex)
            {
                VehicleRepositoryHelper.ErrorMessage(ex);
            }
        } while (!operationComplete);

        bool unitComplete = false;
        ActiveIndex = 0;
        var backMenuItems = BackMenuItems("Register");

        do
        {
            _io.ClearAll();
            Console.CursorVisible = false;
            _io.WriteEncoded($"[blue]{vehicleToCreate!.GetType().Name} with registration number " +
                            $"[blue]{vehicleToCreate!.RegistrationNumber}[blue] registered in garage [magenta]{_ui.SelectedGarage!.Name}[magenta][green]" +
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

    public static void Deregister()
    {
        bool operationComplete = false;
        IVehicle? vehicleToDelete = null;
        do
        {
            try
            {
                _io.ClearAll();
                Console.CursorVisible = true;
                _io.WriteEncoded("[green]Specify the registration number of the vehicle to delete[green]" +
                          Environment.NewLine +
                          "[green]---[green]" +
                          Environment.NewLine +
                          "Reg #: ");

                string? registrationNumber = _io.ReadAndClear()?.ToLower();
                vehicleToDelete = _vehicleRepository?.Remove(registrationNumber);
                operationComplete = true;
            }
            catch (Exception ex)
            {
                VehicleRepositoryHelper.ErrorMessage(ex);
            }
        } while (!operationComplete);

        bool unitComplete = false;
        var backMenuItems = BackMenuItems("Deregister");
        ActiveIndex = 0;

        do
        {
            _io.ClearAll();
            Console.CursorVisible = false;
            _io.WriteEncoded($"[blue]{vehicleToDelete!.GetType().Name} with registration number " +
                            $"{vehicleToDelete!.RegistrationNumber}[blue] deregistered from garage" +
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

    public static void Search()
    {
        bool operationComplete = false;
        IEnumerable<IVehicle?> vehicleMatches = [];

        do
        {
            try
            {
                _io.ClearAll();
                Console.CursorVisible = true;
                _io.WriteEncoded("[green]Please provide a set of search flags (\"--flag\") to query the Registry." +
                            Environment.NewLine +
                          "a registration number flag (--regnumber $myRegNumber) will override all other flags " +
                            Environment.NewLine +
                          "Example query: '[green]--wheelcount [red]4[red] --color [red]red[red] --vehicletype [red]car[red]'" +
                            Environment.NewLine +
                           "[green]---[green]" +
                            Environment.NewLine +
                            "Query: "
                );

                string? query = _io.ReadAndClear();
                if (query?.Length == 0) throw new ArgumentException("Please enter a query.");
                var searchParams = VehicleRepositoryHelper.GenerateSearchParams(query!);
                var searchPayload = VehicleRepositoryHelper.ConstructQueryPayload(searchParams);
                vehicleMatches = _vehicleRepository!.Find(v => VehicleRepositoryHelper.MultiQueryVehicle(v, searchPayload));
                operationComplete = true;
            }
            catch (ArgumentException ex)
            {
                VehicleRepositoryHelper.ErrorMessage(ex);
            }
        } while (!operationComplete);

        bool unitComplete = false;
        var backMenuItems = BackMenuItems("Search");
        ActiveIndex = 0;

        do
        {
            _io.ClearAll();
            if (vehicleMatches.Count() is 0)
            {
                _io.Write("No matches found for query", foreground: "red", newline: true);
            }
            else
            {
                _io.Write($"Match count: {vehicleMatches.Count()}", foreground: "red", newline: true);
                var header = string.Format("[magenta]{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}[magenta]",
                        $"Reg. #",
                        $"Vehicle Type",
                        $"Wheels",
                        $"Color",
                        $"Model");
                _io.WriteEncoded(header + Environment.NewLine);
                foreach (IVehicle? match in vehicleMatches)
                {
                    _io.Write(match!.ToString()!, foreground: "blue", newline: true);
                }
            }

            _io.Write("---" +
                    Environment.NewLine +
                    "Go back or continue?", foreground: "green", newline: true);
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

    private static void SetVehicleParams(ref string registrationNumber, ref string vehicleColor, ref string vehicleModel)
    {

        _io.WriteEncoded("[green]Specify the vehicles registration number:[green]" +
                  Environment.NewLine +
                  "[green]---[green]" +
                  Environment.NewLine);
        registrationNumber = _io.ReadAndClear()?.ToLower()!;

        _io.WriteEncoded("[green]Specify the vehicles color (optional):[green]" +
                  Environment.NewLine +
                  "[green]---[green]" +
                  Environment.NewLine);
        vehicleColor = _io.ReadAndClear()?.ToLower()!;
        _io.WriteEncoded("[green]Specify the vehicles model (optional):[green]" +
                  Environment.NewLine +
                  "[green]---[green]" +
                  Environment.NewLine);
        vehicleModel = _io.ReadAndClear()?.ToLower()!;

        if (vehicleModel.Length == 0) vehicleModel = "NA";
        if (vehicleColor.Length == 0) vehicleColor = "NA";
    }

    private static void BackToMainMenu()
    {
        var mainMenu = _ui.Views!.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }

    private static ViewActionItem<object>[] BackMenuItems(string context)
    {
        ViewActionItem<object> continueOption;

        if (context == "Register")
        {
            continueOption = new("Continue", Register, null);
        }
        else if (context == "Deregister")
        {
            continueOption = new("Continue", Deregister, null);
        }
        else
        {
            continueOption = new("Continue", Search, null);
        }

        ViewActionItem<object>[] backMenuItems =
      [
            continueOption,
            new("Back", action: _ui.Views!.First(v => v.Title == "Vehicles").Enter, paramsAction: null)
      ];
        return backMenuItems;
    }
}