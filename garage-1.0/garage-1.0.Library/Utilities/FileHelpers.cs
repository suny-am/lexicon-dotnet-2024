namespace Garage_1_0.Library.Utilities;

using Garage_1_0.Library.Models.Vehicles;
using Newtonsoft.Json.Linq;
using Garage_1_0.Library.Models;

public class FileHelpers
{
    public static void AddVehicleToSpot(JToken jsonData, ref ParkingSpot spot)
    {
        JToken vehicleData = jsonData.First().First();
        spot.Vehicle = VehicleFromData(vehicleData);
    }

    public static IVehicle? VehicleFromData(JToken vehicleData)
    {
        IVehicle? vehicleToLoad = null;
        bool exists = vehicleData.HasValues;

        if (exists)
        {
            string registrationNumber = vehicleData["RegistrationNumber"]!.ToString();
            string? color = vehicleData["Color"]!.ToString().Length is 0 ? null : vehicleData["Color"]!.ToString();
            string? model = vehicleData["Model"]!.ToString().Length is 0 ? null : vehicleData["Model"]!.ToString();
            string vehicleType = vehicleData["VehicleType"]!.ToString();
            switch (vehicleType)
            {
                case "car":
                    {
                        bool isElectric = (bool)vehicleData["Electric"]!;
                        vehicleToLoad = new Car(registrationNumber, isElectric, color, model);
                        break;
                    }
                case "bus":
                    {
                        int wheelCount = (int)vehicleData["WheelCount"]!;
                        string fuelType = (string)vehicleData["FuelType"]!;
                        vehicleToLoad = new Bus(registrationNumber, fuelType, wheelCount, color, model);
                        break;
                    }
                case "motorcycle":
                    {
                        int seatCount = (int)vehicleData["SeatCount"]!;
                        vehicleToLoad = new Motorcycle(registrationNumber, seatCount, color, model);
                        break;
                    }
                case "boat":
                    {
                        bool hasSail = (bool)vehicleData["Sail"]!;
                        vehicleToLoad = new Boat(registrationNumber, hasSail, color, model);
                        break;
                    }
                case "airplane":
                    {
                        int engineCount = (int)vehicleData["EngineCount"]!;
                        vehicleToLoad = new Airplane(registrationNumber, engineCount, color, model);
                        break;
                    }
            }
        }

        return vehicleToLoad;
    }
}