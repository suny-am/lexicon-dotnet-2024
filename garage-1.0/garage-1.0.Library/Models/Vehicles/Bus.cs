namespace Garage_1_0.Library.Models.Vehicles;

public class Bus(Guid id, string registrationNumber, int wheelCount, string? color, string? model)
            : Vehicle(id, registrationNumber, model, color)
{
    private readonly int _wheelCount = wheelCount;
    public int WheelCount => _wheelCount;
}
