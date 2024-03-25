namespace Garage_1_0.Library.Utilities;

using System.Text.RegularExpressions;
using Garage_1_0.Library.Models.Vehicles;
using SuperConsole;

public class VehicleRepositoryHelper
{
    private static IO _io = IO.Instance;

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
        if (searchParams.Any(p => p.Length != 2))
            throw new ArgumentException("Invalid syntax in search params construction!");
        foreach (var p in searchParams)
        {
            if (Regex.Match(p[0], @"^color$|^model$|^vehicletype$|^wheelcount$|^regnumber$").Success is false)
                throw new ArgumentException($"Invalid flag: {p[0]} ");
        }
        return searchParams;
    }

    public static bool MultiQueryVehicle(IVehicle? vehicle, Dictionary<string, object> payload)
    {
        bool isMatch = false;

        bool colorMatch = true;
        bool modelMatch = true;
        bool vehicleTypeMatch = true;
        bool wheelCountMatch = true;
        bool regNumberMatch = true;

        if (vehicle is null) return isMatch;
        if (payload["regnumber"] is not null)
        {
            regNumberMatch = vehicle.RegistrationNumber == (string)payload["regnumber"];
        }
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
            wheelCountMatch = vehicle.WheelCount == int.Parse((string)payload["wheelcount"]);
        }

        if (colorMatch && modelMatch && vehicleTypeMatch && wheelCountMatch && regNumberMatch)
            isMatch = true;

        return isMatch;
    }

    public static void ErrorMessage(Exception ex)
    {
        _io.ClearAll();
        _io.Write(ex.Message + $"{Environment.NewLine}Press any key to continue.", foreground: "red", newline: true);
        Console.ReadKey();
    }
}