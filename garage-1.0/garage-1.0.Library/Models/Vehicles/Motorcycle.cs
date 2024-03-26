namespace Garage_1_0.Library.Models.Vehicles;

public class Motorcycle : Vehicle
{

    private int _seatCount;

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

    public Motorcycle(string registrationNumber,
                int seatCount,
                string? color = null,
                string? model = null,
                int? wheelCount = 2) : base(registrationNumber, color, model, wheelCount)
    {
        _seatCount = ValidateSeatCount(seatCount);
    }

    public int SeatCount => _seatCount;

    private static int ValidateSeatCount(int? seatCount)
    {
        ArgumentNullException.ThrowIfNull(seatCount);
        if (seatCount < 1 || seatCount > 4) throw new ArgumentOutOfRangeException(nameof(seatCount));
        return (int)seatCount;
    }
}
