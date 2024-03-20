namespace Garage_1_0.Library.Models.Vehicles;

public class Car : Vehicle
{

    public Car(Guid id, string registrationNumber) : base(id, registrationNumber)
    { }

    public Car(Guid id,
                string registrationNumber,
                string? color = null) : base(id, registrationNumber, color)
    { }

    public Car(Guid id,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    { }

    private readonly int _wheelCount = 4; // TBD! Read from config?
    public int WheelCount => _wheelCount;
}
