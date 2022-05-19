using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETWebAplicationShop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContext appDBContent;

        public CarRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(x => x.isFavourite).Include(c=>c.Category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(x=> x.carId == carId);
    }
}
