
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;

namespace Garage_1_0.Library.UI;

public class VehicleView(string title, IEnumerable<IViewItem> viewItems) : UIView(title, viewItems)
{
    private static UI _ui = UI.Instance;
    private GarageRepository<Vehicle> _garageRepository = new();
    private static readonly ViewActionItem<object>[] _backMenuItems =
       [
           new("Continue", Console.WriteLine, null ),
           new("Back", _ui.Views.First(v => v.Title == "Garages").Enter, null)
       ];

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

    public static void BackToMainMenu()
    {
        var mainMenu = _ui.Views.First(v => v.Title == "Main Menu");
        mainMenu.Enter();
    }
}