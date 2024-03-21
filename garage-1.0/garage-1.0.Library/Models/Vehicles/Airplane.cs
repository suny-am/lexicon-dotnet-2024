namespace Garage_1_0.Library.Models.Vehicles;

public class Airplane : Vehicle
{

    public Airplane(Guid id, string vehicleType, string registrationNumber) : base(id, vehicleType, registrationNumber)
    { }

    public Airplane(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null) : base(id, vehicleType, registrationNumber, color)
    { }

    public Airplane(Guid id,
                string vehicleType,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, vehicleType, registrationNumber, color, model)
    { }
}
