namespace Garage_1_0.Library.Models.Vehicles;

public interface IVehicle
{
    public Guid Id { get; }
    public Guid RegistryId { get; }
    public string Name { get; set; }
    public string? Color { get; set; }
}