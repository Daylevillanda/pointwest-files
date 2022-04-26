namespace EntityFrameworkDemo.Models
{
    public class ProductOrder : BaseEntity
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}