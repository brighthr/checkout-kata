using Kata.Checkout.Interfaces;

namespace Kata.Checkout
{
    public class Product : IProduct
    {
        public Product(char sku, int price)
        {
            SKU = sku;
            Price = price;
        }

        public char SKU { get; set; }
        public int Price { get; set; }
    }
}