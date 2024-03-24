namespace Garage_1_0.Library.Utilities;

using Garage_1_0.Library.Models.Vehicles;

public class VehicleRepositoryHelper
{
    public static Dictionary<string, object> ConstructQueryPayload(string[][] flagList)
    {
        Dictionary<string, object> flags = new()
        {
            {"color", null!},
            {"vehicletype", null!},
            {"wheelcount", null!},
            {"model", null!},
            {"regnumber", null!},
        };

        foreach (var flag in flagList)
        {
            var flagKey = flag[0].ToLower();
            var flagValue = flag[1].ToLower();

            switch (flagKey.ToLower())
            {
                case "color":
                    {
                        flags["color"] = flagValue;
                        break;
                    }
                case "model":
                    {
                        flags["model"] = flagValue;
                        break;
                    }
                case "wheelcount":
                    {
                        flags["wheelcount"] = flagValue;
                        break;
                    }
                case "vehicletype":
                    {
                        flags["vehicletype"] = flagValue;
                        break;
                    }
                case "regnumber":
                    {
                        flags["regnumber"] = flagValue;
                        break;
                    }
            }
        }
        return flags;
    }

    public static string[][] GenerateSearchParams(string queryInput)
    {
        var searchParams = queryInput.Split("--")
                              .Where(q => q.Length > 0)
                              .Select(q => q.TrimEnd().Split(" ")).ToArray();
        if (searchParams.Any(p => p.Length != 2)) throw new ArgumentException("Invalid syntax in search params construction!");
        return searchParams;
    }

    public static bool MultiQueryVehicle(IVehicle? vehicle, Dictionary<string, object> payload)
    {
        bool isMatch = false;

        bool colorMatch = true;
        bool modelMatch = true;
        bool vehicleTypeMatch = true;
        bool wheelCountMatch = true;

        if (vehicle is null) return isMatch;
        if (vehicle.RegistrationNumber == (string)payload["regnumber"])
            return true;

        if (payload["color"] is not null)
        {
            colorMatch = vehicle.Color == (string)payload["color"];
        }
        if (payload["model"] is not null)
        {
            modelMatch = vehicle.Model == (string)payload["model"];
        }
        if (payload["vehicletype"] is not null)
        {
            vehicleTypeMatch = vehicle.VehicleType == (string)payload["vehicletype"];
        }
        if (payload["wheelcount"] is not null)
        {
            wheelCountMatch = vehicle.WheelCount == (int)payload["wheelcount"];
        }

        if (colorMatch && modelMatch && vehicleTypeMatch && wheelCountMatch)
            isMatch = true;

        return isMatch;
    }

}