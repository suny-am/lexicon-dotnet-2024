namespace Garage_1_0.Library.Models.Vehicles;

public class Boat : Vehicle
{
    private bool _sail;

    public Boat(Guid id, string registrationNumber, bool sail) : base(id, registrationNumber)
    {
        _sail = sail;
    }

    public Boat(Guid id,
                string registrationNumber,
                bool sail,
                string? color = null) : base(id, registrationNumber, color)
    {
        _sail = sail;
    }

    public Boat(Guid id,
                string registrationNumber,
                bool sail,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    {
        _sail = sail;
    }

    public bool Sail => _sail;
}
