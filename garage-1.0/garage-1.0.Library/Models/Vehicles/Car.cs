namespace Garage_1_0.Library.Models.Vehicles;

public class Car(Guid id, string registrationNumber, string? model, string? color) 
            : Vehicle(id, registrationNumber, color, model)
{
    private readonly int _wheelCount = 4;
    public int WheelCount => _wheelCount;
}
