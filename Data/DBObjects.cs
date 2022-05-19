using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            

            //если ни одного объекта нету
            if (!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));

            if (!context.Car.Any())
            {
                context.AddRange(
                    new Car
                    {
                        carName = "Tesla",
                        shortDescription = "Электро - мобиль",
                        longDescrition = "Тихая на дороге",
                        img = "/img/tesla.jpg",
                        carPrice = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        carName = "Bentley",
                        shortDescription = "Дорогая и призентабильная",
                        longDescrition = "Для состоятельных мужчин готовых на все",
                        img = "/img/2019_Bentley_Flying_Spur_W12_Front.jpg",
                        carPrice = 60000,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Класические автомобили"]
                    },
                    new Car
                    {
                        carName = "Daewoo",
                        shortDescription = "Доступная и классная",
                        longDescrition = "Подходит для семейного человека и комфортных поездок",
                        img = "/img/Daewoo_Espero_v.jpg",
                        carPrice = 10000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класические автомобили"]
                    });
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> _category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new Category[] {
                        new Category { categoryName = "Электромобили", categoryDescription="Современный вид транспорта"},
                        new Category { categoryName ="Класические автомобили", categoryDescription = "Машины с двс"}
                    };
                    _category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        _category.Add(el.categoryName, el);
                }
                return _category;
            }
        }
        
    }
}
