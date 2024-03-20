namespace Garage_1_0.Library.Models.Vehicles;

public class Motorcycle(Guid id, string registrationNumber, string? model, string? color)
            : Vehicle(id, registrationNumber, model, color)
{
    private readonly int _wheelCount = 2;
    public int WheelCount => _wheelCount;
}
