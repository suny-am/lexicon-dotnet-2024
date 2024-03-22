using System.Text.RegularExpressions;

namespace Garage_1_0.Library.Models.Vehicles;

public class Bus : Vehicle
{
    private readonly int _wheelCount = 4; // TBD! Read from config?
    private string _fuelType;

    public Bus(Guid id, string registrationNumber, string fuelType, int wheelCount) : base(id, registrationNumber)
    {
        ValidateWheelCount(wheelCount);


        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    public Bus(Guid id,
                string registrationNumber,
                string fuelType,
                int wheelCount,
                string? color = null) : base(id, registrationNumber, color)
    {
        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    public Bus(Guid id,
                string registrationNumber,
                string fuelType,
                int wheelCount,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    {
        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    private static int ValidateWheelCount(int wheelCount)
    {
        if (int.IsOddInteger(wheelCount)) throw new ArgumentException("Wheel count must be an even integer");
        if (wheelCount < 4) throw new ArgumentException("Wheel count cannot be less than 4");
        return wheelCount;
    }

    private static string ValidateFuelType(string fuelType)
    {
        if (Regex.Match(fuelType.ToLower(), @"gasoline|diesel").Success is false)
        {
            throw new ArgumentException($"Invalid argument provided for fuel type: {fuelType}");
        }
        return fuelType;
    }

    public int WheelCount => _wheelCount;
    public string FuelType => _fuelType;
}
