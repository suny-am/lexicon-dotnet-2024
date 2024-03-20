namespace Garage_1_0.Library.Models.Vehicles;

public class Airplane(Guid id, string registrationNumber, string? model, string? color) 
            : Vehicle(id, registrationNumber, model, color)
{

}
