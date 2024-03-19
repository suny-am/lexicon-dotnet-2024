namespace Garage_1_0.Models.Vehicles;

public abstract class Vehicle(Guid id, Guid registryId, string name) : IVehicle
{
    private Guid id = id;
    private Guid registryId = registryId;

    private string name = name;

    public Guid Id
    {
        get
        {
            return id;
        }
        // TBD! Validate!
        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        // TBD! Validate!
        set
        {
            name = value;
        }
    }
    public Guid RegistryId
    {
        get
        {
            return registryId;
        }
        // TBD! Validate!
        set
        {
            registryId = value;
        }
    }
}