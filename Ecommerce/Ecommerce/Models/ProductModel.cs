namespace Ecommerce.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public  string Photo {get;set;}
        public bool? isActive { get; set; }
        public int CategoryId { get; set; }

    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public bool isActive { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }

}
