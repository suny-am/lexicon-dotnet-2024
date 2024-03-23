namespace Garage_1_0.Library.Repositories;

using Garage_1_0.Library.Models;
using Garage_1_0.Library.Exceptions;

public class GarageRepository<T> : IRepository<Garage<ParkingSpot>>
{
    private IEnumerable<Garage<ParkingSpot>> _garageList = [];

    public Garage<ParkingSpot>? Add(Garage<ParkingSpot> garageToAdd)
    {
        var garageExists = _garageList.Any(g => g.Name == garageToAdd.Name);
        if (garageExists)
        {
            throw new GarageExistsException(garageToAdd.Name);
        }
        var garageTempList = _garageList.ToList();
        garageTempList.Add(garageToAdd);
        return garageToAdd;
    }

    public IEnumerable<Garage<ParkingSpot>> All()
    {
        return _garageList;
    }

    public bool Any()
    {
        return _garageList.Any();
    }

    public IEnumerable<Garage<ParkingSpot>?> Find(Func<Garage<ParkingSpot>, bool> predicate)
    {
        return _garageList.Where(predicate);
    }

    public Garage<ParkingSpot>? Remove(string garageToRemoveName)
    {
        Garage<ParkingSpot>? garage = _garageList
                                    .FirstOrDefault(g => g.Name == garageToRemoveName)
                                    ?? throw new GarageNotFoundException(garageToRemoveName);

        var garageListTemp = _garageList.ToList();
        garageListTemp.Remove(garage);
        _garageList = garageListTemp;
        return garage;
    }

    // TBD Used when saving to file!
    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Garage<ParkingSpot> Update(Garage<ParkingSpot> garageToUpdate)
    {
        Garage<ParkingSpot> garage = _garageList
                                    .FirstOrDefault(g => g.Name == garageToUpdate.Name)
                                    ?? throw new GarageNotFoundException(garageToUpdate.Name);
        return garage;
    }
}