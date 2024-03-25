using Garage_1_0.Library.Models;
using Garage_1_0.Library.UI.Views;
using Microsoft.Extensions.Configuration;

namespace Garage_1_0.Library.UI;

public interface IUI
{
    public string Title { get; set; }
    public IConfiguration? Configuration { get; set; }
    public IEnumerable<IUIView>? Views { get; set; }
    public IUIView? ActiveView { get; set; }
    public IEnumerable<IGarage<IParkingSpot>>? GarageList { get; set; }
    public IGarage<IParkingSpot>? SelectedGarage { get; set; }
    public void SaveChanges();
    public void SetSelectedGarage();
    public void LoadGarages();
    public void Quit();
}
