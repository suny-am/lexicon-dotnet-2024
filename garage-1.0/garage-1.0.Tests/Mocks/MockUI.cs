using Garage_1_0.Library.Models;
using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;
using Microsoft.Extensions.Configuration;

namespace Garage_1_0.Tests.Mocks;

public class MockUI : IUI
{

    private string _title = default!;
    private IConfiguration? _configuration;
    private IEnumerable<IUIView> _views = [];
    private IEnumerable<IGarage<IParkingSpot>>? _garageList = [];

    public string Title
    {
        get => _title;
        set => _title = value;
    }
    public IConfiguration? Configuration
    {
        get => _configuration;
        set => _configuration = value;
    }
    public IEnumerable<IUIView>? Views
    {
        get => _views;
        set
        {
            if (value is null)
                throw new NullReferenceException("source not found.");
            _views = value;
        }
    }
    public IEnumerable<IGarage<IParkingSpot>>? GarageList
    {
        get => _garageList;
        set =>
        _garageList = value;
    }
    public IGarage<IParkingSpot>? SelectedGarage
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public void LoadGarages()
    {
        throw new NotImplementedException();
    }

    public void Quit()
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void SetSelectedGarage()
    {
        throw new NotImplementedException();
    }
}