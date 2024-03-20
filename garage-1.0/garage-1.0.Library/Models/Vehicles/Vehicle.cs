
namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(Guid id, string registrationNumber) : IVehicle
{
    private Guid _id = id;
    private string _registrationNumber = registrationNumber;
    private string? _model;
    private string? _color;

    public Vehicle(Guid id, 
                    string registrationNumber, 
                    string? color = null) : this(id, registrationNumber)
    {
        _color = color;
    }

    public Vehicle(Guid id, 
                    string registrationNumber, 
                    string? color = null, 
                    string? model = null) : this(id, registrationNumber, color)
    {
        _model = model;
    }


    public Guid Id => _id;
    public string RegistrationNumber => _registrationNumber;
    public string? Model { get => _model; }
    public string? Color { get => _color; set => _color = value; }
}