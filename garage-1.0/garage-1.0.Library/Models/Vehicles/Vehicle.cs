namespace Garage_1_0.Library.Models.Vehicles;
using System.Text.RegularExpressions;

public abstract class Vehicle(string registrationNumber) : IVehicle
{
    private string _registrationNumber = registrationNumber;
    private string? _model;
    private string? _color;
    private int? _wheelCount;
    private enum _allowedColors
    {
        red, green, blue, yellow, orange, purple,
        white, black, grey, pink, brown,
        teal, multi, gold, silver, na
    };

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

    public Vehicle(string registrationNumber,
                    string? color = "na",
                    string? model = "na",
                    int? wheelCount = 4) : this(registrationNumber, color, model)
    {
        _wheelCount = wheelCount;
    }

    public string VehicleType => GetType().Name.ToLower();
    public string RegistrationNumber => _registrationNumber;
    public virtual int? WheelCount => _wheelCount;
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
            return "na";
        }

        if (Enum.TryParse<_allowedColors>(formatedColor, true, out _) is false)
            throw new ArgumentException($"Invalid color selection! \"{formatedColor}\"");
        return formatedColor;
    }

    public override string ToString()
    {
        var stats = string.Format("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}",
                        $"{RegistrationNumber}",
                        $"{VehicleType}",
                        $"{(WheelCount is null ? "NA" : WheelCount)}",
                        $"{Color ?? "NA"}",
                        $"{Model ?? "NA"}");
        return stats;
    }
}