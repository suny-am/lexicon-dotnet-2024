using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using Garage_1_0.Library.UI;
/* 
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
mainMenuView.Enter(); */

Garage<ParkingSpot> garage = new("test", 300);

VehicleRepository<Vehicle> vehicleRepository = new(garage);

Car car = new(Guid.NewGuid(), "abc123", true);
Bus bus = new(Guid.NewGuid(), "def123", "gasoline", 6);
Motorcycle motorcycle = new(Guid.NewGuid(), "ghj123", 2);
Boat boat = new(Guid.NewGuid(), "xyz123", false);
Airplane airplane = new(Guid.NewGuid(), "trt123", 4);

vehicleRepository.Add(car);
vehicleRepository.Add(bus);
vehicleRepository.Add(motorcycle);
vehicleRepository.Add(boat);
vehicleRepository.Add(airplane);

foreach (var v in vehicleRepository.All())
{
    Console.WriteLine(v?.RegistrationNumber);
}
Console.Read();