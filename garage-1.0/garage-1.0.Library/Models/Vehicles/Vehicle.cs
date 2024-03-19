namespace Garage_1_0.Library.Models.Vehicles;

public abstract class Vehicle(Guid id, Guid registryId, string name) : IVehicle
{
    private Guid _id = id;
    private Guid _registryId = registryId;

    private string _name = name;

    public Guid Id
    {
        get
        {
            return _id;
        }
        // TBD! Validate!
        set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        // TBD! Validate!
        set
        {
            _name = value;
        }
    }
    public Guid RegistryId
    {
        get
        {
            return _registryId;
        }
        // TBD! Validate!
        set
        {
            _registryId = value;
        }
    }
}
