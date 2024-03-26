namespace Garage_1_0.Library.Services;

using Garage_1_0.Library.Models;
using Garage_1_0.Library.UI;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class FileWriter(IConfiguration configuration) : IService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly string _filePath = configuration.GetRequiredSection("settings:data:fileService:json:filePath").Value!;
    private readonly UI _ui = UI.Instance;

    public IConfiguration Configuration => _configuration;
    public string FilePath => _filePath;

    public bool WriteData()
    {
        IEnumerable<IGarage<IParkingSpot>>? garages = _ui.GarageList;
        if (garages!.Count() is 0)
        {
            throw new Exception("No garages currently stored in runtime memory");
        }
        string garageJsonString = JsonConvert.SerializeObject(garages);
        try
        {
            var formatedGarageDataObject = new { garages = garages!.Select(g => new { g.Name, g.Spots }) };
            var garagesJsonString = JsonConvert.SerializeObject(formatedGarageDataObject);
            File.WriteAllText(FilePath, garagesJsonString);
        }
        catch (JsonException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }
}
