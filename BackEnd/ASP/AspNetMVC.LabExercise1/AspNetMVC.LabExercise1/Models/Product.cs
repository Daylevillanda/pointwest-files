namespace AspNetMVC.LabExercise1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice
        {
            get { return this.Quantity * this.Price; }
            set { this.TotalPrice = value; }
        }
    }
}
