using System.Text;

namespace Garage_1_0.Library.Models.Vehicles;

public class Car : Vehicle
{
    private bool _electric;
    private readonly int _wheelCount = 4;

    public Car(string registrationNumber, bool electric) : base(registrationNumber)
    {
        _electric = VerifyElectric(electric);
    }

    public Car(string registrationNumber,
                bool electric,
                string? color = null) : base(registrationNumber, color)
    {
        _electric = VerifyElectric(electric);
    }

    public Car(string registrationNumber,
                bool electric,
                string? color = null,
                string? model = null) : base(registrationNumber, color, model)
    {
        _electric = VerifyElectric(electric);
    }

    public bool Electric => _electric;
    public int WheelCount => _wheelCount;

    private static bool VerifyElectric(bool? electric)
    {
        ArgumentNullException.ThrowIfNull(electric);
        return (bool)electric;
    }


    public override string ToString()
    {
        StringBuilder stats = new();

        string isElectric = Electric ? "yes" : "no";

        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | " +
                    $"Electric: {isElectric} | ");
        if (Color is not null) stats.Append($"Color: {Color} | ");
        if (Model is not null) stats.Append($"Model: {Model} | ");
        return stats.ToString();
    }
}
