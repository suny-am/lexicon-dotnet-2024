using Garage_1_0.Library.Models;
using Garage_1_0.Library.Repositories;

Garage<ParkingSpot> garage = new(vehicleCapacity: 30);

GarageRepository<ParkingSpot> garageRepository = new(garage);