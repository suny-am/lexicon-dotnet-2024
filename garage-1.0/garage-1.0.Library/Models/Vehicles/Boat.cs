namespace Garage_1_0.Library.Models.Vehicles;

public class Boat : Vehicle
{
    private bool _sail;

    public Boat(string registrationNumber, bool sail) : base(registrationNumber)
    {
        _sail = sail;
    }

    public Boat(string registrationNumber,
                bool sail,
                string? color = null) : base(registrationNumber, color)
    {
        _sail = sail;
    }

    public Boat(string registrationNumber,
                bool sail,
                string? color = null,
                string? model = null) : base(registrationNumber, color, model)
    {
        _sail = sail;
    }

    public bool Sail => _sail;
}
