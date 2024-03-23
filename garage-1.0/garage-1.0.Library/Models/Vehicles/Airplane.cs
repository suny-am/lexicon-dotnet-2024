namespace Garage_1_0.Library.Models.Vehicles;

using System.Text;

public class Airplane : Vehicle
{

    private int _engineCount;

    public Airplane(string registrationNumber, int engineCount) : base(registrationNumber)
    {
        _engineCount = ValidateEngineCount(engineCount);
    }

    public Airplane(string registrationNumber,
                int engineCount,
                string? color) : base(registrationNumber, color)
    {
        _engineCount = ValidateEngineCount(engineCount);
    }

    public Airplane(string registrationNumber,
                int engineCount,
                string? color,
                string? model) : base(registrationNumber, color, model)
    {
        _engineCount = engineCount;
    }

    public int EngineCount => _engineCount;

    private static int ValidateEngineCount(int? engineCount)
    {
        ArgumentNullException.ThrowIfNull(engineCount);
        if (engineCount < 1 || engineCount > 10) throw new ArgumentOutOfRangeException(nameof(engineCount));
        return (int)engineCount;
    }

    public override string ToString()
    {
        StringBuilder stats = new();
        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | " +
                    $"Engine Count: {EngineCount} | ");
        if (Color is not null) stats.Append($"Color: {Color} | ");
        if (Model is not null) stats.Append($"Model: {Model} | ");
        return stats.ToString();
    }
}
