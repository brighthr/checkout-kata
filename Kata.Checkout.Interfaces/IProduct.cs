namespace Kata.Checkout.Interfaces
{
    public interface IProduct
    {
        public char SKU { get; set; }
        public int Price { get; set; }
    }
}