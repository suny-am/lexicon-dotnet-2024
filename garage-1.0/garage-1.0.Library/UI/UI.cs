using Garage_1_0.Library.Models;
using Garage_1_0.Library.UI.Views;
using SuperConsole;

namespace Garage_1_0.Library.UI;

public class UI : IUI
{
    private static readonly Lazy<UI> lazy =
        new(() => new UI());
    private IEnumerable<IUIView> _views = [];
    private IEnumerable<Garage<ParkingSpot>> _garageList = [];
    private Garage<ParkingSpot>? _selectedGarage = null;
    private string? _header = null;
    private IUIView? _activeView = null;

    public static UI Instance { get { return lazy.Value; } }
    public static bool InstanceCreated { get { return lazy.IsValueCreated; } }
    public IEnumerable<IUIView> Views { get => _views; set => _views = value; }
    public IUIView? ActiveView { get => _activeView; set => _activeView = value; }
    public Garage<ParkingSpot>? SelectedGarage { get => _selectedGarage; set => _selectedGarage = value; }
    public IEnumerable<Garage<ParkingSpot>>? GarageList
    {
        get => _garageList;
        set
        {
            if (value is not null)
            {
                _garageList = value.AsEnumerable();
            }
        }
    }

    public string? Header { get => _header; set => _header = value; }

    public void Quit()
    {
        IO.Instance.ClearAll();
        Environment.Exit(1);
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }
}