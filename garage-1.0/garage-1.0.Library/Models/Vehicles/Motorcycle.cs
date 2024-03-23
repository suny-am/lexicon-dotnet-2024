namespace Garage_1_0.Library.Models.Vehicles;

using System.Text;

public class Motorcycle : Vehicle
{

    private int _seatCount;
    private readonly int _wheelCount = 2;

    public Motorcycle(string registrationNumber, int seatCount) : base(registrationNumber)
    {

        _seatCount = ValidateSeatCount(seatCount);
    }

    public Motorcycle(string registrationNumber,
                int seatCount,
                string? color = null) : base(registrationNumber, color)
    {
        _seatCount = ValidateSeatCount(seatCount);
    }

    public Motorcycle(string registrationNumber,
                int seatCount,
                string? color = null,
                string? model = null) : base(registrationNumber, color, model)
    {
        _seatCount = ValidateSeatCount(seatCount);
    }

    public int SeatCount => _seatCount;
    public int WheelCount => _wheelCount;

    private static int ValidateSeatCount(int? seatCount)
    {
        ArgumentNullException.ThrowIfNull(seatCount);
        if (seatCount < 1 || seatCount > 4) throw new ArgumentOutOfRangeException(nameof(seatCount));
        return (int)seatCount;
    }

    public override string ToString()
    {
        StringBuilder stats = new();
        stats.Append($"Vehicle Type: {VehicleType} | " +
                    $"Registration Number: {RegistrationNumber} | " +
                    $"Seat count: {SeatCount} | ");
        if (Color is not null) stats.Append($"Color: {Color} | ");
        if (Model is not null) stats.Append($"Model: {Model} | ");
        return stats.ToString();
    }
}
