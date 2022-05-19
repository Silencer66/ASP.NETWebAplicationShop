using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string currentcategory { get; set; } 
    }
}
