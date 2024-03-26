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
}
