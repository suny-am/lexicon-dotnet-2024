namespace Garage_1_0.Library.Models.Vehicles;

public interface IVehicle
{
    public string VehicleType { get; }
    public string RegistrationNumber { get; }
    public int? WheelCount { get; }
    public string? Model { get; }
    public string? Color { get; set; }
}