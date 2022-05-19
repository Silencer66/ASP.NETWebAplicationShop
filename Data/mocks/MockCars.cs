using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data.mocks
{
    public class MockCars : IAllCars
    {

        private readonly ICarsCategory _carsCategory = new MockCategory();
        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>()
                {
                    new Car {
                        carName="Tesla",
                        shortDescription="Электро мобиль",
                        longDescrition="Тихая на дороге",
                        img="/img/tesla.jpg",
                        carPrice= 45000,
                        isFavourite = true,
                        available = true,
                        Category = _carsCategory.AllCategories.Last()
                    },
                    new Car {
                        carName = "Bentley",
                        shortDescription = "Дорогая и призентабильная",
                        longDescrition = "Для состоятельных мужчин готовых на все",
                        img = "/img/2019_Bentley_Flying_Spur_W12_Front.jpg",
                        carPrice = 60000,
                        isFavourite = false,
                        available = false,
                        Category = _carsCategory.AllCategories.Last()
                    },
                    new Car{
                        carName = "Daewoo",
                        shortDescription = "Доступная и классная",
                        longDescrition = "Подходит для семейного человека и комфортных поездок",
                        img= "/img/Daewoo_Espero_v.jpg",
                        carPrice=10000,
                        isFavourite= false,
                        available= true,
                        Category= _carsCategory.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
