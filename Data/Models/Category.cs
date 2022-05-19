namespace ASP.NETWebAplicationShop.Data.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public List<Car> cars { get; set; }
    }
}
