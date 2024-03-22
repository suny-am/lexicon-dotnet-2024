
using System.Text;
using System.Text.RegularExpressions;

namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(string registrationNumber) : IVehicle
{
    private string _registrationNumber = registrationNumber;
    private string? _model;
    private string? _color;

    public Vehicle(string registrationNumber,
                    string? color = null) : this(registrationNumber)
    {
        _color = ValidateColor(color);
    }

    public Vehicle(string registrationNumber,
                    string? color = null,
                    string? model = null) : this(registrationNumber, color)
    {
        _model = ValidateModel(model);
    }

    public string VehicleType => GetType().Name.ToLower();
    public string RegistrationNumber => _registrationNumber;
    public string? Model { get => _model; }
    public string? Color { get => _color; set => _color = ValidateColor(value); }

    protected static string ValidateRegistrationNumber(string? registrationNumber)
    {
        ArgumentNullException.ThrowIfNull(registrationNumber);
        return registrationNumber.ToLower();
    }

    protected static string ValidateModel(string? model)
    {
        ArgumentNullException.ThrowIfNull(model);
        bool isInt = int.TryParse(model, out int _);
        if (isInt) throw new ArgumentException("model cannot be an integer!");
        return model.ToLower();
    }

    protected static string ValidateColor(string? color)
    {
        ArgumentNullException.ThrowIfNull(color);
        if (color == "gray") color = "grey";
        string formatedColor = color.ToLower();
        string pattern = @"red|green|blue|yellow|orange|purple|white|black|grey|pink|brown|teal|multi|gold|silver";
        if (Regex.Match(formatedColor, pattern).Success is false) throw new ArgumentException($"Invalid color selection! \"{formatedColor}\"");
        return formatedColor;
    }

    public override string ToString()
    {
        StringBuilder stats = new();
        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | ");
        if (Color is not null) stats.Append($"Color: {Color} | ");
        if (Model is not null) stats.Append($"Model: {Model} | ");
        return stats.ToString();
    }
}