namespace Garage_1_0.Library.Models.Vehicles;

public class Boat : Vehicle
{

    public Boat(Guid id, string vehicleType, string registrationNumber) : base(id, vehicleType, registrationNumber)
    { }

    public Boat(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null) : base(id, vehicleType, registrationNumber, color)
    { }

    public Boat(Guid id,
                string registrationNumber,
                string vehicleType,
                string? color = null,
                string? model = null) : base(id, vehicleType, registrationNumber, color, model)
    { }
}
