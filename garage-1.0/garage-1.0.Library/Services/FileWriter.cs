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
        IEnumerable<Garage<IParkingSpot>> garages = _ui.GarageList!;
        string garageJsonString = JsonConvert.SerializeObject(garages);
        try
        {

            File.WriteAllText(FilePath, garageJsonString);
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
