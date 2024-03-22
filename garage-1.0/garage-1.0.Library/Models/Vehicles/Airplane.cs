namespace Garage_1_0.Library.Models.Vehicles;

public class Airplane : Vehicle
{

    private int _engineCount;

    public Airplane(Guid id, string registrationNumber, int engineCount) : base(id, registrationNumber)
    {
        _engineCount = engineCount;
    }

    public Airplane(Guid id,
                string registrationNumber,
                int engineCount,
                string? color = null) : base(id, registrationNumber, color)
    {
        _engineCount = engineCount;
    }

    public Airplane(Guid id,
                string registrationNumber,
                int engineCount,
                string? color = null,
                string? model = null) : base(id, registrationNumber, color, model)
    {
        _engineCount = engineCount;
    }

    public int EngineCount => _engineCount;
}
