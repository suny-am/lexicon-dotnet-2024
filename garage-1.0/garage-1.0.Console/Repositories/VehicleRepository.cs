using Garage_1_0.Models;
using Garage_1_0.Models.Vehicles;

namespace Garage_1_0.Repositories;

public class VehicleRepository(Garage<Vehicle> garage) : IVehicleRepository
{
    private Garage<Vehicle> garage = garage;

}