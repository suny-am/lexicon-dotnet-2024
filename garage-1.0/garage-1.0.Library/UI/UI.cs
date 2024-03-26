namespace Garage_1_0.Library.UI;

using System.Data;
using Garage_1_0.Library.Models;
using Garage_1_0.Library.Services;
using Garage_1_0.Library.UI.Views;
using Microsoft.Extensions.Configuration;
using SuperConsole;

public class UI : IUI
{
    private static IO _io = IO.Instance;
    private static readonly Lazy<UI> lazy =
        new(() => new UI());

    private string _title = default!;
    private string? _header = null;
    private IConfiguration? _configuration = null!;
    private IEnumerable<IUIView>? _views = [];
    private IEnumerable<IGarage<IParkingSpot>>? _garageList = [];
    private IGarage<IParkingSpot>? _selectedGarage = null;
    private IUIView? _activeView = null;

    public static UI Instance { get { return lazy.Value; } }
    public static bool InstanceCreated { get { return lazy.IsValueCreated; } }
    public IConfiguration? Configuration
    {
        get => _configuration;
        set => _configuration = value;
    }
    public string Title
    {
        get => _title;
        set
        {
            if (value is null)
                throw new DataException("invalid data source {value.GeType()}");
            _title = value;
        }
    }
    public IEnumerable<IUIView>? Views
    {
        get => _views;
        set
        {
            if (value is null || _views?.Count() != 0)
                throw new NullReferenceException("views cannot be reset");
            _views = value;
        }
    }
    public IUIView? ActiveView
    {
        get => _activeView;
        set
        {
            if (value is null)
                throw new DataException("invalid data source {value.GeType()}");
            _activeView = value;
        }
    }

    public IGarage<IParkingSpot>? SelectedGarage
    {
        get => _selectedGarage;
        set => _selectedGarage = value;

    }

    public int? SelectedGarageCapacity
    {
        get => _selectedGarage?.Spots.Where(v => v.Vehicle is not null).Count();
    }

    public IEnumerable<IGarage<IParkingSpot>>? GarageList
    {
        get => _garageList;
        set
        {
            if (value is null)
                throw new DataException("invalid data source {value.GeType()}");
            _garageList = value.AsEnumerable();
            SetSelectedGarage();
        }
    }

    public string? Header { get => _header; set => _header = value; }

    public void Quit()
    {
        IO.Instance.ClearAll();
        Environment.Exit(1);
    }

    public void SetSelectedGarage()
    {
        if (SelectedGarage is null && GarageList!.Any())
        {
            SelectedGarage = GarageList!.First();
        }
    }

    public void LoadGarages()
    {
        if (Configuration is null)
        {
            throw new Exception("No App Configuration found.");
        }
        try
        {
            FileReader fileReader = new(Configuration);
            GarageList = fileReader.LoadData();
        }
        catch (Exception ex)
        {
            _io.Write(ex.Message, foreground: "red", newline: true);
        }
    }

    public void SaveChanges()
    {
        if (Configuration is null)
        {
            throw new Exception("No App Configuration found.");
        }
        try
        {
            FileWriter fileWriter = new(Configuration);
            bool success = fileWriter.WriteData();
            if (success)
            {
                _io.WriteEncoded($"[green]Garagelist [blue][Count: {GarageList!.Count()}] [blue]successfully saved to file.[green]");
            }
        }
        catch (Exception ex)
        {
            _io.Write(ex.Message, foreground: "red", newline: true);
        }
        Console.ReadKey();
    }
}