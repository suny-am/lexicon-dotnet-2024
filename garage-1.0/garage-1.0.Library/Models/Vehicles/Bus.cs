namespace Garage_1_0.Library.Models.Vehicles;

using System.Text.RegularExpressions;

public class Bus : Vehicle
{
    private readonly int? _wheelCount = 4; // TBD! Read from config?
    private string _fuelType = "gasoline"; // TBD! Read from config?

    public Bus(string registrationNumber, string fuelType, int wheelCount) : base(registrationNumber)
    {
        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    public Bus(string registrationNumber,
                string fuelType,
                int? wheelCount,
                string? color) : base(registrationNumber, color)
    {
        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    public Bus(string registrationNumber,
                string fuelType,
                int? wheelCount,
                string? color,
                string? model) : base(registrationNumber, color, model)
    {
        _fuelType = ValidateFuelType(fuelType);
        _wheelCount = ValidateWheelCount(wheelCount);
    }

    public override int? WheelCount => _wheelCount;
    public string FuelType => _fuelType;

    private static int ValidateWheelCount(int? wheelCount)
    {
        ArgumentNullException.ThrowIfNull(wheelCount);
        if (int.IsOddInteger((int)wheelCount)) throw new ArgumentException("Wheel count must be an even integer");
        if (wheelCount < 4 || wheelCount > 18) throw new ArgumentOutOfRangeException(nameof(wheelCount) + " Range: 4-18");
        return (int)wheelCount;
    }

    private static string ValidateFuelType(string? fuelType)
    {
        ArgumentNullException.ThrowIfNull(fuelType);
        if (Regex.Match(fuelType.ToLower(), @"gasoline|diesel").Success is false)
        {
            throw new ArgumentException($"Invalid argument provided for fuel type: {fuelType}");
        }
        return fuelType;
    }
}
