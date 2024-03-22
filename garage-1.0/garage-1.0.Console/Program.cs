using Garage_1_0.Library.UI;

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
