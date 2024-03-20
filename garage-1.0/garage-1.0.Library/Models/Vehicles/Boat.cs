namespace Garage_1_0.Library.Models.Vehicles;

public class Boat : Vehicle
{

    public Boat(Guid id, string registrationNumber) : base(id, registrationNumber)
    { }

    public Boat(Guid id,
                string registrationNumber,
                string? color = null) : base(id, registrationNumber, color)
    { }

    public Boat(Guid id,
                string registrationNumber,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    { }
}
