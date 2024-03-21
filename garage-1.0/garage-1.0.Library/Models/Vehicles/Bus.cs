namespace Garage_1_0.Library.Models.Vehicles;

public class Bus : Vehicle
{

    public Bus(Guid id, string vehicleType, string registrationNumber, int wheelCount) : base(id, vehicleType, registrationNumber)
    {
        _wheelCount = wheelCount;
    }

    public Bus(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null) : base(id, vehicleType, registrationNumber, color)
    { }

    public Bus(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, vehicleType, registrationNumber, color, model)
    { }

    private readonly int _wheelCount = 4; // TBD! Read from config?
    public int WheelCount => _wheelCount;
}
