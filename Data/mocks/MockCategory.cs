using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories 
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", categoryDescription="Современный вид транспорта"},
                    new Category { categoryName ="Класические автомобили", categoryDescription = "Машины с двс"}
                }; 
            }
        }

    }
}
