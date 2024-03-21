namespace Garage_1_0.Library.Models.Vehicles;

public class Car : Vehicle
{

    public Car(Guid id, string vehicleType, string registrationNumber) : base(id, vehicleType, registrationNumber)
    { }

    public Car(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null) : base(id, vehicleType, registrationNumber, color)
    { }

    public Car(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, vehicleType, registrationNumber, color, model)
    { }

    private readonly int _wheelCount = 4; // TBD! Read from config?
    public int WheelCount => _wheelCount;
}
