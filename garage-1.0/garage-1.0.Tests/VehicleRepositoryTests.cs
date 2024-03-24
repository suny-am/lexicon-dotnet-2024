namespace garage_1._0.Tests;

using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;
using Moq;

public class VehicleRepositoryTests
{
    private Garage<IParkingSpot> _garage = new("mockGarage", 5);
    private Mock<VehicleRepository<IVehicle>> _mockRepository;
    private IVehicle _mockCar;

    public VehicleRepositoryTests()
    {
        _mockCar = new Car(registrationNumber: "RTR808", false, color: "red", model: "xc90");
        _mockRepository = new Mock<VehicleRepository<IVehicle>>(_garage);
    }

    [Fact]
    public void Repository_Adds_Vehicle_To_Garage()
    {
        // ACT
        _mockRepository.Object.Add(_mockCar);

        // ASSERT
        Assert.Contains(_mockCar, _mockRepository.Object.All()!);
    }

    [Fact]
    public void Repository_Finds_Vehicle_In_Garage()
    {
        // ARRANGE
        _mockRepository.Object.Add(_mockCar);

        // ACT
        var result = _mockRepository.Object.Find(s => s?.RegistrationNumber == _mockCar.RegistrationNumber).Single();

        // ASSERT
        Assert.Equal(_mockCar, result);
    }

    [Fact]
    public void Repository_Removes_Vehicle_From_Garage()
    {
        // ARRANGE
        _mockRepository.Object.Add(_mockCar);

        // ACT
        _mockRepository.Object.Remove(_mockCar.RegistrationNumber);

        // ASSERT
        Assert.DoesNotContain(_mockCar, _mockRepository.Object.All());
    }

    [Fact]
    public void Repository_Updates_Vehicle_In_Garage_With_Correct_Values()
    {
        // ARRANGE
        _mockRepository.Object.Add(_mockCar);
        var car = _mockRepository.Object.Find(c => c!.RegistrationNumber == "RTR808").First()!;

        // ACT
        car.Color = "purple";
        _mockRepository.Object.Update(car);

        // ASSERT
        var resultColor = _mockRepository.Object.Find(c => c!.RegistrationNumber == "RTR808").First()!.Color;
        Assert.Equal("purple", resultColor);
    }
}