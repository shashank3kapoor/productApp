using System;

namespace CoreProductApi.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImage { get; set; }
    }
}
