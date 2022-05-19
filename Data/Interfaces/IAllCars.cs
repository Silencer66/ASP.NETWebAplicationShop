using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get;}
        Car getObjectCar(int carId);

    }
}
