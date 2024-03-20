using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;

namespace garage_1._0.Tests;

public class GarageRepositoryTests
{
    private Garage<ParkingSpot> _garage = new(5);
    private GarageRepository<IVehicle> _mockRepository;
    private IVehicle _mockCar;

    public GarageRepositoryTests()
    {
        _mockCar = new Car(id: Guid.NewGuid(), registrationNumber: "RTR808", color: "red");
        _mockRepository = new GarageRepository<IVehicle>(_garage);
    }

    [Fact]
    public void Repository_Adds_Vehicle_To_Garage()
    {
        // ACT
        _mockRepository.Add(_mockCar);

        // ASSERT
        Assert.Contains(_mockCar, _mockRepository.All()!);
    }

    [Fact]
    public void Repository_Finds_Vehicle_In_Garage()
    {
        // ARRANGE
        _mockRepository.Add(_mockCar);

        // ACT
        var result = _mockRepository.Find(s => s?.Id == _mockCar.Id).Single();

        // ASSERT
        Assert.Equal(_mockCar, result);
    }

    [Fact]
    public void Repository_Removes_Vehicle_From_Garage()
    {
        // ARRANGE
        _mockRepository.Add(_mockCar);

        // ACT
        _mockRepository.Remove(_mockCar);

        // ASSERT
        Assert.DoesNotContain(_mockCar, _mockRepository.All());
    }

    [Fact]
    public void Repository_Updates_Vehicle_In_Garage_With_Correct_Values()
    {
        // ARRANGE
        _mockRepository.Add(_mockCar);
        var car = _mockRepository.Find(c => c!.RegistrationNumber == "RTR808").First()!;

        // ACT
        car.Color = "purple";
        _mockRepository.Update(car);

        // ASSERT
        var resultColor = _mockRepository.Find(c => c!.RegistrationNumber == "RTR808").First()!.Color;
        Assert.Equal("purple", resultColor);
    }
}