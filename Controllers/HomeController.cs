using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETWebAplicationShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        //функциия которая возвращает шаблон
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel { favCars = _carRep.getFavCars };
            return View(homeCars);
        }
    }
}
