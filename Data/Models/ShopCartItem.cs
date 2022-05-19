namespace ASP.NETWebAplicationShop.Data.Models
{
    //Корзина на сайте
    public class ShopCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; } 

        public string ShopCartId{ get; set; }
    }
}
