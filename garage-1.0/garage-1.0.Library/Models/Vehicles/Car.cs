namespace Garage_1_0.Library.Models.Vehicles;

public class Car : Vehicle
{
    private bool _electric;
    private readonly int _wheelCount = 4;

    public Car(Guid id, string registrationNumber, bool electric) : base(id, registrationNumber)
    {
        _electric = electric;
    }

    public Car(Guid id,
                string registrationNumber,
                bool electric,
                string? color = null) : base(id, registrationNumber, color)
    {
        _electric = electric;
    }

    public Car(Guid id,
                string registrationNumber,
                bool electric,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    {
        _electric = electric;
    }

    public bool Electric => _electric;
    public int WheelCount => _wheelCount;
}
