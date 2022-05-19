using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;
using ASP.NETWebAplicationShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETWebAplicationShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        /// <summary>
        /// возвразаем шаблон
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }

        /// <summary>
        /// Добавляет товары в корзину, и переадресовывает на другую страничку 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RedirectToActionResult addtoCart(int id)
        {
            //Выбирает товар из базы по его id 
            //вернет либо найденный элемент либо дефолт(первый)
            var item = _carRep.Cars.FirstOrDefault(i=> i.carId == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            //
            return RedirectToAction("Index"); //возвращаем функцию Index
        }
    }
}
