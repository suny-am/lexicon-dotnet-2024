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
                string? color) : base(registrationNumber, color)
    {
        _electric = VerifyElectric(electric);
    }

    public Car(string registrationNumber,
                bool electric,
                string? color,
                string? model) : base(registrationNumber, color, model)
    {
        _electric = VerifyElectric(electric);
    }

    public bool Electric => _electric;
    public override int? WheelCount => _wheelCount;

    private static bool VerifyElectric(bool? electric)
    {
        ArgumentNullException.ThrowIfNull(electric);
        return (bool)electric;
    }
}
