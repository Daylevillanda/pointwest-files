using System;

namespace myDemo3c
{
    internal class Program
    {
        class Product
        {
            public int Id { get; set; }

            public Product(){}
            public Product(int Id)
            {
                this.Id = Id;
            }
        }

        //class ProductCatalog
        //{
        //    Product product;
        //    Product product2;
        //    public ProductCatalog()
        //    {
        //        this.product = new Product(10);
        //        this.product2 = new Product
        //        {
        //            Id = 2
        //        };
        //    }
        //}
        static void Main(string[] args)
        {
            Product product = new Product
            {
                Id = 1
            };
        }
    }
}
