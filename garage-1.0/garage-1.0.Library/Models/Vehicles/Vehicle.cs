
using System.Text;
using System.Text.RegularExpressions;

namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(string registrationNumber) : IVehicle
{
    private string _registrationNumber = registrationNumber;
    private string? _model;
    private string? _color;

    public Vehicle(string registrationNumber,
                    string? color = "na") : this(registrationNumber)
    {
        _color = ValidateColor(color);
    }

    public Vehicle(string registrationNumber,
                    string? color = "na",
                    string? model = "na") : this(registrationNumber, color)
    {
        _model = ValidateModel(model);
    }

    public string VehicleType => GetType().Name.ToLower();
    public string RegistrationNumber => _registrationNumber;
    public string? Model { get => _model; set => _model = ValidateModel(value); }
    public string? Color { get => _color; set => _color = ValidateColor(value); }

    protected static string ValidateRegistrationNumber(string? registrationNumber)
    {
        ArgumentNullException.ThrowIfNull(registrationNumber);
        return registrationNumber.ToLower();
    }

    protected static string? ValidateModel(string? model)
    {
        bool isInt = int.TryParse(model, out int _);
        if (isInt) throw new ArgumentException("model cannot be an integer!");
        return model?.ToLower() ?? "na";
    }

    protected static string ValidateColor(string? color)
    {
        if (color == "gray") color = "grey";
        string? formatedColor = color?.ToLower();
        if (formatedColor is null)
        {
            return "NA";
        }
        string pattern = @"red|green|blue|yellow|orange|purple|white|black|grey|pink|brown|teal|multi|gold|silver|na";
        if (Regex.Match(formatedColor, pattern).Success is false) throw new ArgumentException($"Invalid color selection! \"{formatedColor}\"");
        return formatedColor;
    }

    public override string ToString()
    {
        StringBuilder stats = new();
        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | " +
                    $"Color: {Color} | " +
                    $"Model: {Model} | ");
        return stats.ToString();
    }
}