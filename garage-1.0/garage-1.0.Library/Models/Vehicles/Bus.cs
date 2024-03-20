namespace Garage_1_0.Library.Models.Vehicles;

public class Bus : Vehicle
{

    public Bus(Guid id, string registrationNumber, int wheelCount) : base(id, registrationNumber)
    { 
        _wheelCount = wheelCount;
    }

    public Bus(Guid id,
                string registrationNumber,
                string? color = null) : base(id, registrationNumber, color)
    { }

    public Bus(Guid id,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    { }

    private readonly int _wheelCount = 4; // TBD! Read from config?
    public int WheelCount => _wheelCount;
}
