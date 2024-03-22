namespace Garage_1_0.Library.Models.Vehicles;

public class Airplane : Vehicle
{

    private int _engineCount;

    public Airplane(string registrationNumber, int engineCount) : base(registrationNumber)
    {
        _engineCount = engineCount;
    }

    public Airplane(string registrationNumber,
                int engineCount,
                string? color = null) : base(registrationNumber, color)
    {
        _engineCount = engineCount;
    }

    public Airplane(string registrationNumber,
                int engineCount,
                string? color = null,
                string? model = null) : base(registrationNumber, color, model)
    {
        _engineCount = engineCount;
    }

    public int EngineCount => _engineCount;
}
