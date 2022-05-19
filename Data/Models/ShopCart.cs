using Microsoft.EntityFrameworkCore;

namespace ASP.NETWebAplicationShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContext appDBContent;
        public ShopCart(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }   

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContext>();
            
            //в эту переменную устанавливаем значение из сессии, если его нету - создаем новую
            //при последующих вызовах функции GetCart создавать новую не будем 
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car) {
            appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.carPrice
            });
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems() 
        { 
            return appDBContent.ShopCartItems.Where(x=>x.ShopCartId == ShopCartId).Include(x=>x.car).ToList();
        }
    }
}
