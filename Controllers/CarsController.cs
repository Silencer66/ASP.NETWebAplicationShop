using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;
using ASP.NETWebAplicationShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETWebAplicationShop.Controllers
{
    /// <summary>
    /// здесь будут функции при вызове которых будет возвращаться тип  ViewResult
    /// ViewREsult - результат в виде html странички
    /// </summary>
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult list(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory= null;
            if (string.IsNullOrEmpty(category))
                cars = _allCars.Cars.OrderBy(i => i.carId);
            
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.carId);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Класические автомобили")).OrderBy(i => i.carId);
                    currCategory = _category;
                }
                currCategory = "Класические автомобили";

            }
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currentcategory = currCategory
            };

            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
