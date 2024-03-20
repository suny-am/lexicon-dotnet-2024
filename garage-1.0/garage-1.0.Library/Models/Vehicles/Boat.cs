namespace Garage_1_0.Library.Models.Vehicles;

public class Boat(Guid id, Guid registryId, string name) : IVehicle
{
    private Guid _id = id;
    private Guid _registryId = registryId;
    private string _name = name;
    private string? _color;

    public Guid Id => _id;

    public string? Color { get => _color; set => _color = value; }

    public Guid RegistryId => _registryId;

    public string Name { get => _name; set => _name = value; }
}
