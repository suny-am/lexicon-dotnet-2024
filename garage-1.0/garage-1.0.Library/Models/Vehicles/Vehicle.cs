
using System.Text.RegularExpressions;

namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(Guid id, string registrationNumber) : IVehicle
{
    private Guid _id = id;
    private string _registrationNumber = registrationNumber;
    private string? _model;
    private string? _color;

    public Vehicle(Guid id,
                    string registrationNumber,
                    string? color = null) : this(id, registrationNumber)
    {
        _color = color?.ToLower();
    }

    public Vehicle(Guid id,
                    string registrationNumber,
                    string? color = null,
                    string? model = null) : this(id, registrationNumber, color)
    {
        _model = ValidateModel(model);
    }

    public Guid Id => _id;
    public string VehicleType => GetType().Name.ToLower();
    public string RegistrationNumber => _registrationNumber;
    public string? Model { get => _model; }
    public string? Color { get => _color; set => _color = ValidateColor(value); }

    protected static string ValidateModel(string? model)
    {
        ArgumentNullException.ThrowIfNull(model);
        bool isInt = int.TryParse(model, out int _);
        if (isInt) throw new ArgumentException("model cannot be an integer!");
        return model;
    }
    protected static string ValidateColor(string? color)
    {
        ArgumentNullException.ThrowIfNull(color);
        if (color == "gray") color = "grey";
        string pattern = @"red|green|blue|yellow|orange|purple|white|black|grey|pink|brown|teal|multi|gold|silver";
        if (Regex.Match(color, pattern).Success is false) throw new ArgumentException("Invalid color selection!");
        return color;
    }
}