namespace Garage_1_0.Library.UI.Views;

using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using SuperConsole;

public class VehicleView(string title) : MainMenuView(title)
{
    private static UI _ui = UI.Instance;
    private static IO _io = IO.Instance;
    private IEnumerable<IViewItem> _viewMenuItems =
    [
        new ViewActionItem<object>("Register", Register, null),
        new ViewActionItem<object>("Deregister", Deregister, null),
        new ViewActionItem<object>("Search", Search, null),
        new ViewActionItem<object>("Back", BackToMainMenu, null)
    ];
    // TBD! need to guard against null value here.
    private static VehicleRepository<IVehicle>? _vehicleRepository = null;

    public override IEnumerable<IViewItem> ViewMenuItems => _viewMenuItems;
    public VehicleRepository<IVehicle>? VehicleRepository => _vehicleRepository;

    public static void Register()
    {
        bool operationComplete = false;
        IVehicle? vehicleToCreate = null;
        do
        {
            try
            {
                _io.WriteEncoded("[green]What kind of vehicle do you want to register?[green]" +
                          Environment.NewLine +
                          "(Available options: [red]Car[red], [yellow]Bus[yellow], [cyan]Motorcycle[cyan], " +
                          "[magenta]Boat[magenta], [blue]Airplane[blue]})" +
                          Environment.NewLine +
                          "[green]---[green]");

                string? vehicleType = _io.ReadAndClear()?.ToLower();
                _io.WriteEncoded("[green]Specify the vehicles registration number:[green]" +
                          Environment.NewLine +
                          "[green]---[green]");
                string? registrationNumber = _io.ReadAndClear()?.ToLower();

                // WIP! Allow user to specify extra attributes for vehicle in addition to the required ones
                switch (vehicleType)
                {
                    case "car":
                        {
                            _io.WriteEncoded("[green]Is the car electric (Y/N)?[green]" +
                                         Environment.NewLine +
                                        "[green]---[green]");
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

                            vehicleToCreate = new Car(registrationNumber!, electric);
                            break;
                        }
                    case "bus":
                        {
                            _io.WriteEncoded("[green]Specify the wheel count of the bus:[green]" +
                                             Environment.NewLine +
                                            "[green]---[green]");

                            _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int wheelCount);

                            _io.WriteEncoded("[green]Specify the fuel type of the bus:[green]" +
                                             Environment.NewLine +
                                            "[green]---[green]");

                            var fuelType = _io.ReadAndClear()?.ToLower();

                            vehicleToCreate = new Bus(registrationNumber!, fuelType!, wheelCount);
                            break;
                        }
                    case "motorcycle":
                        {
                            _io.WriteEncoded("[green]Specify the seat count of the motorcycle:[green]" +
                                             Environment.NewLine +
                                            "[green]---[green]");

                            _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int seatCount);

                            vehicleToCreate = new Motorcycle(registrationNumber!, seatCount);
                            break;
                        }
                    case "boat":
                        {
                            _io.WriteEncoded("[green]Does the boat have sails? (Y/N):[green]" +
                                             Environment.NewLine +
                                            "[green]---[green]");
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

                            vehicleToCreate = new Boat(registrationNumber!, sail);
                            break;
                        }
                    case "airplane":
                        {
                            _io.WriteEncoded("[green]Specify the engine count of the plane:[green]" +
                                            Environment.NewLine +
                                           "[green]---[green]");
                            _ = int.TryParse(_io.ReadAndClear()?.ToLower(), out int engineCount);

                            vehicleToCreate = new Airplane(registrationNumber!, engineCount);
                            break;
                        }
                }
                _vehicleRepository!.Add(vehicleToCreate!);
            }
            catch (Exception ex)
            {
                _io.Write(ex.Message, foreground: "red", newline: true);
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
                            $"{vehicleToCreate!.RegistrationNumber}[blue] registered in garage" +
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
                _io.WriteEncoded("[green]Specify the registration number of the vehiocle to delete[green]" +
                          Environment.NewLine +
                          "[green]---[green]");

                string? registrationNumber = _io.ReadAndClear()?.ToLower();
                _vehicleRepository?.Remove(registrationNumber);
            }
            catch (Exception ex)
            {
                _io.Write(ex.Message);
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

        do
        {
            _io.WriteEncoded("[green]Please provide a set of search flags (\"--flag\") to query the Registry." +
                        Environment.NewLine +
                      "a registration number flag (--regnumber $myRegNumber) will override all other flags " +
                        Environment.NewLine +
                      "Example query: '--wheelcount [red]4[red] --color [red]red[red] --type [red]car[red]'" +
                        Environment.NewLine +
                       "---[green]"
            );

            string? query = _io.ReadAndClear();
            string[]? searchParams = query?.Split("--");


        } while (!operationComplete);

    }

    public static void BackToMainMenu()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
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
            new("Back", action: _ui.Views.First(v => v.Title == "Garages").Enter, paramsAction: null)
      ];
        return backMenuItems;
    }
}