using System.Text;

namespace Garage_1_0.Library.Models.Vehicles;

public class Boat : Vehicle
{
    private bool _sail;

    public Boat(string registrationNumber, bool sail) : base(registrationNumber)
    {
        _sail = ValidateSail(sail);
    }

    public Boat(string registrationNumber,
                bool sail,
                string? color) : base(registrationNumber, color)
    {
        _sail = ValidateSail(sail);
    }

    public Boat(string registrationNumber,
                bool sail,
                string? color,
                string? model) : base(registrationNumber, color, model)
    {
        _sail = ValidateSail(sail);
    }

    public bool Sail => _sail;

    private static bool ValidateSail(bool? sail)
    {
        ArgumentNullException.ThrowIfNull(sail);
        return (bool)sail;
    }

    public override string ToString()
    {
        StringBuilder stats = new();
        string hasSail = Sail ? "yes" : "no";
        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | " +
                    $"Sail: {hasSail} | ");
        if (Color is not null) stats.Append($"Color: {Color} | ");
        if (Model is not null) stats.Append($"Model: {Model} | ");
        return stats.ToString();
    }
}
