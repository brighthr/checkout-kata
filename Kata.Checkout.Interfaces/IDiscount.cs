namespace Kata.Checkout.Interfaces
{
    public interface IDiscount
    {
        char SKU { get; set; }
        int Quantity { get; set; }
        int Value { get; set; }
    }
}