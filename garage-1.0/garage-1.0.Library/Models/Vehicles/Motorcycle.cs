namespace Garage_1_0.Library.Models.Vehicles;

public class Motorcycle : Vehicle
{

    public Motorcycle(Guid id, string vehicleType, string registrationNumber) : base(id, vehicleType, registrationNumber)
    { }

    public Motorcycle(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null) : base(id, vehicleType, registrationNumber, color)
    { }

    public Motorcycle(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, vehicleType, registrationNumber, color, model)
    { }

    private readonly int _wheelCount = 2;
    public int WheelCount => _wheelCount;
}
