namespace ASP.NETWebAplicationShop.Data.Models
{
    public class Car
    {
        public int carId { get; set; }
        public string carName { get; set; }
        public string shortDescription { get; set; }
        public string longDescrition { get; set; }
        public string img { get; set; }
        //ushort - потому что не может быть с минусом
        public ushort carPrice { get; set; }
        //будет ли отображаться на главной
        public bool isFavourite { get; set; }

        //есть ли данный товар на складе
        public bool available { get; set; }

        //каждый товар будет прикреплен к определенной категории
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
        public string? state { get; set; }
    }
}
