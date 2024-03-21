using Garage_1_0.Library.UI;

UI ui = UI.Instance;

// sub menus
IEnumerable<IViewItem> garageMenuItems = [

    new ViewActionItem("New", GarageView.New),
    new ViewActionItem("Load", GarageView.Load),
    new ViewActionItem("Delete", GarageView.Delete),
    new ViewActionItem("Back", GarageView.Back)
];
IEnumerable<IViewItem> vehicleMenuItems = [
    new ViewActionItem("Register", VehicleView.Register),
    new ViewActionItem("Deregister", VehicleView.Deregister),
    new ViewActionItem("Search", VehicleView.Search),
    new ViewActionItem("Back", VehicleView.Back)
];

UIView garageView = new("Garages", garageMenuItems);
UIView vehicleView = new("Vehicles", vehicleMenuItems);

// Main menu
IEnumerable<IViewItem> viewItems =
[
    new ViewActionItem("Garages", garageView.Enter),
    new ViewActionItem("Vehicles", vehicleView.Enter),
    new ViewActionItem("Save changes", ui.SaveChanges),
    new ViewActionItem("Quit", UI.Instance.Quit)
];

UIView mainMenuView = new("Main Menu", viewItems);

ui.Views = [mainMenuView, garageView, vehicleView];

mainMenuView.Enter();
