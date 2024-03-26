namespace Garage_1_0.Library.Services;

using Garage_1_0.Library.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Garage_1_0.Library.Utilities;

public class FileReader : IService
{
    private readonly IConfiguration _configuration;
    private readonly string _filePath;

    public FileReader(IConfiguration configuration)
    {
        _configuration = configuration;
        _filePath = _configuration!.GetRequiredSection("settings:data:fileService:json:filePath").Value!;
    }

    public IConfiguration Configuration => _configuration!;
    public string FilePath => _filePath;

    public Garage<IParkingSpot>[] LoadData()
    {
        var vehicleDataString = File.ReadAllText(FilePath);
        JObject vehicleDataObject = JsonConvert.DeserializeObject<JObject>(vehicleDataString)!;
        JToken garages = vehicleDataObject.Property("garages")!.Value;
        Garage<IParkingSpot>[] garageList = new Garage<IParkingSpot>[garages.Count()];

        for (int i = 0; i < garages.Count(); i++)
        {
            string name = garages.ElementAt(i)["Name"]!.ToString();
            IEnumerable<JToken> vehicles = garages.ElementAt(i)["Spots"]!;
            Garage<IParkingSpot> garageToCreate = new(name, vehicles!.Count());
            for (int ii = 0; ii < vehicles!.Count(); ii++)
            {
                ParkingSpot spot = new();
                FileHelpers.AddVehicleToSpot(vehicles.ElementAt(ii), ref spot);
                garageToCreate.Spots[ii] = spot;
            }
            garageList[i] = garageToCreate;
        }
        return garageList;
    }


}
