namespace Garage_1_0.Library.Models.Vehicles;

public class Bus(Guid id, Guid registryId, string name, int wheelCount) : IVehicle
{
    private Guid _id = id;
    private Guid _registryId = registryId;
    private string _name = name;
    private readonly int _wheelCount = wheelCount;
    private string? _color;

    public string? Color { get => _color; set => _color = value; }

    public int WheelCount
    {
        get => _wheelCount;
    }

    public Guid Id => _id;

    public Guid RegistryId => _registryId;

    public string Name { get => _name; set => _name = value; }
}
