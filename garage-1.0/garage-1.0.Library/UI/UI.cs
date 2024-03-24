namespace Garage_1_0.Library.UI;

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
    private IEnumerable<IUIView> _views = [];
    private IEnumerable<Garage<IParkingSpot>> _garageList = [];
    private string? _title;
    private Garage<IParkingSpot>? _selectedGarage = null;
    private string? _header = null;
    private IUIView? _activeView = null;

    public IConfiguration? Configuration { get; set; }
    public static UI Instance { get { return lazy.Value; } }
    public static bool InstanceCreated { get { return lazy.IsValueCreated; } }
    public string? Title { get => _title; set => _title = value; }
    public IEnumerable<IUIView> Views { get => _views; set => _views = value; }
    public IUIView? ActiveView { get => _activeView; set => _activeView = value; }
    public Garage<IParkingSpot>? SelectedGarage { get => _selectedGarage; set => _selectedGarage = value; }
    public IEnumerable<Garage<IParkingSpot>>? GarageList
    {
        get => _garageList;
        set
        {
            if (value is not null)
            {
                _garageList = value.AsEnumerable();
                SetSelectedGarage();
            }
        }
    }

    public string? Header { get => _header; set => _header = value; }

    public void Quit()
    {
        IO.Instance.ClearAll();
        Environment.Exit(1);
    }

    private void SetSelectedGarage()
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
                _io.WriteEncoded($"[green]Garagelist [blue][Count: {GarageList!.Count()}][blue]successfully saved to file.[green]");
            }
        }
        catch (Exception ex)
        {
            _io.Write(ex.Message, foreground: "red", newline: true);
        }
        Console.ReadKey();
    }
}