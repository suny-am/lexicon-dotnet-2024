using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;

UI ui = UI.Instance;

// TBD! For now let's just create and populate our views here
// this might be difficult/overkill to apply via configuration

// sub menus
IEnumerable<IViewItem> garageMenuItems =
[
    new ViewActionItem<object>("New", GarageView.New, null),
    new ViewActionItem<object>("Load", GarageView.Load, null),
    new ViewActionItem<object>("Delete", GarageView.Delete, null),
    new ViewActionItem<object>("Back", GarageView.BackToMainMenu, null)
];
IEnumerable<IViewItem> vehicleMenuItems =
[
    new ViewActionItem<object>("Register", VehicleView.Register, null),
    new ViewActionItem<object>("Deregister", VehicleView.Deregister, null),
    new ViewActionItem<object>("Search", VehicleView.Search, null),
    new ViewActionItem<object>("Back", VehicleView.BackToMainMenu, null)
];

UIView garageView = new("Garages", garageMenuItems);
UIView vehicleView = new("Vehicles", vehicleMenuItems);

// Main menu
IEnumerable<IViewItem> viewItems =
[
    new ViewActionItem<object>("Garages", garageView.Enter, null),
    new ViewActionItem<object>("Vehicles", vehicleView.Enter, null),
    new ViewActionItem<object>("Save changes", ui.SaveChanges, null),
    new ViewActionItem<object>("Quit", ui.Quit, null)
];

UIView mainMenuView = new("Main Menu", viewItems);

ui.Views = [mainMenuView, garageView, vehicleView];

// Select a view as entry point
mainMenuView.Enter();

// Garage<ParkingSpot> garage = new("test", 300);

// VehicleRepository<Vehicle> vehicleRepository = new(garage);


// IEnumerable<Vehicle> vehicles =
// [
//             new Car ("abc123", true, "red"),
//             new Car ("dcp123", true, "red"),
//             new Bus ("def123", "gasoline", 6, color: "red"),
//             new Bus("asaff123", "gasoline", 6),
//             new Bus("de4737f123", "gasoline", 6),
//             new Motorcycle("ghj123", 2, color: "silver"),
//             new Boat("xyz123", false, color: "gold"),
//             new Airplane("trt123", 4, color: "white"),
// ];

// foreach (var vehicle in vehicles)
// {
//     vehicleRepository.Add(vehicle);
// }

// foreach (var v in vehicleRepository.All())
// {
//     Console.WriteLine(v);
// }

// Console.Read();