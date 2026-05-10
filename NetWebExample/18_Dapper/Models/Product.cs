namespace _18_Dapper.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }//FK
        public Category? Category { get; set; }//Foreign key referansı

    }
}
