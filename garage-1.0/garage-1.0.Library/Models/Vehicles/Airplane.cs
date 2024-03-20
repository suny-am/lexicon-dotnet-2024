namespace Garage_1_0.Library.Models.Vehicles;

public class Airplane : Vehicle
{

    public Airplane(Guid id, string registrationNumber) : base(id, registrationNumber)
    { }

    public Airplane(Guid id,
                string registrationNumber,
                string? color = null) : base(id, registrationNumber, color)
    { }

    public Airplane(Guid id,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    { }
}
