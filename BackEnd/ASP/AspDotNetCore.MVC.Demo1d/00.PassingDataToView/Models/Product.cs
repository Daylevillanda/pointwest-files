using Microsoft.AspNetCore.Mvc;

namespace _00.PassingDataToView.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
