namespace Garage_1_0.Library.Models.Vehicles;

public class Boat(Guid id, string registrationNumber, string? color, string? model)
            : Vehicle(id, registrationNumber, model, color)
{

}
