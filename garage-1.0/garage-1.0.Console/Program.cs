using Garage_1_0.Library.Models;
using Garage_1_0.Library.Models.Vehicles;
using Garage_1_0.Library.Repositories;

Garage<ParkingSpot> garage = new(vehicleCapacity: 30);

GarageRepository<ParkingSpot> garageRepository = new(garage);

Car car1 = new(Guid.NewGuid(), Guid.NewGuid(), "myCar");

garageRepository.Add(car1);

var targetCar = garageRepository.All()?.Single(v => v?.Id == car1.Id);

Console.WriteLine(targetCar?.Name);


