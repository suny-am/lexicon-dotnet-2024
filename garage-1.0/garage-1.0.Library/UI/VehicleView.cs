
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using SuperConsole;

namespace Garage_1_0.Library.UI;

public class VehicleView(string title, IEnumerable<IViewItem> viewItems) : UIView(title, viewItems)
{
    private static UI _ui = UI.Instance;
    private static IO _io = IO.Instance;
    private GarageRepository<Vehicle> _garageRepository = new();

    public GarageRepository<Vehicle> GarageRepository => _garageRepository;

    public static void Register()
    {
        throw new NotImplementedException();
    }

    public static void Deregister()
    {
        throw new NotImplementedException();
    }

    public static void Search()
    {
        throw new NotImplementedException();
    }

    public static void Back()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }
}