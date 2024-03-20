
namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(Guid id, string registrationNumber, string? model, string? color ) : IVehicle
{
    private Guid _id = id;
    private string _registrationNumber = registrationNumber;
    private string? _model = model;
    private string? _color = color;

    public Guid Id => _id;

    public string RegistrationNumber => _registrationNumber;

    public string? Model { get => _model; }
    public string? Color { get => _color; set => _color = value; }
}