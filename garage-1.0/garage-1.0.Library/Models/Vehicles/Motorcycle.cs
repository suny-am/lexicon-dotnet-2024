namespace Garage_1_0.Library.Models.Vehicles;

public class Motorcycle : Vehicle
{

    public Motorcycle(Guid id, string registrationNumber) : base(id, registrationNumber)
    { }

    public Motorcycle(Guid id,
                string registrationNumber,
                string? color = null) : base(id, registrationNumber, color)
    { }

    public Motorcycle(Guid id,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    { }
    
    private readonly int _wheelCount = 2;
    public int WheelCount => _wheelCount;
}
