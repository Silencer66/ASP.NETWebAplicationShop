using ASP.NETWebAplicationShop.Data.Models;

namespace ASP.NETWebAplicationShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        /// <summary>
        /// Функция, которая возвращает список
        /// просто получает данные
        /// </summary>
        IEnumerable<Category> AllCategories { get; }
    }
}
