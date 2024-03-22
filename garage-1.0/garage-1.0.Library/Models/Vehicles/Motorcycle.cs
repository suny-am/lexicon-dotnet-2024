namespace Garage_1_0.Library.Models.Vehicles;

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

    private static int ValidateSeatCount(int seatCount)
    {
        if (seatCount > 4) throw new ArgumentException("Seat count can't be greater than 4!");
        if (seatCount < 1) throw new ArgumentException("Seat count can't be less than 1!");
        return seatCount;
    }

    public int SeatCount => _seatCount;
    public int WheelCount => _wheelCount;
}
