using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;
using Microsoft.Extensions.Configuration;

// Load configuration settings
IConfiguration configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables()
                                .Build();

// Load garage data from file
UI.Instance.Configuration = configuration;
UI.Instance.LoadGarages();

// sub menus
GarageView garageView = new("Garages");
VehicleView vehicleView = new("Vehicles");

// Main menu
// Was unable to remove this part from the entrypoint due to the references to instance objects
// creating singletons ended up circular load operations?
IEnumerable<IViewItem> viewItems =
[
    new ViewActionItem<object>("Garages", garageView.Enter, null),
    new ViewActionItem<object>("Vehicles", vehicleView.Enter, null),
    new ViewActionItem<object>("Save changes", UI.Instance.SaveChanges, null),
    new ViewActionItem<object>("Quit", UI.Instance.Quit, null)
];

MainMenuView mainMenuView = new("Main Menu", viewItems);
UI.Instance.Views = [mainMenuView, garageView, vehicleView];

// Select a view as entry point
mainMenuView.Enter();