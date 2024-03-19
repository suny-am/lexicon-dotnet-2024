using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;

namespace garage_1._0.Tests;

public class GarageRepositoryTests
{
    private Garage<ParkingSpot> _garage = new Garage<ParkingSpot>(5);
    private GarageRepository<IVehicle> _mockRepository;
    private IVehicle _mockCar;

    public GarageRepositoryTests()
    {
        _mockCar = new Car(Guid.NewGuid(), Guid.NewGuid(), "testCar");
        _mockRepository = new GarageRepository<IVehicle>(_garage);
    }

    [Fact]
    public void Repository_Adds_Vehicle_To_Empty_Garage_at_first_index()
    {
        // ARRANGE

        // ACT
        _mockRepository.Add(_mockCar);

        // ASSERT
        Assert.Contains(_mockCar, _mockRepository.All()!);
    }
}