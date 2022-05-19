using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContext appDBContent;
        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
