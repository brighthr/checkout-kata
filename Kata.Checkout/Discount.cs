using Kata.Checkout.Interfaces;

public class Discount : IDiscount
{
    public Discount(char sku, int quantity, int value)
    {
        SKU = sku;
        Quantity = quantity;
        Value = value;
    }

    public char SKU { get; set; }
    public int Quantity { get; set; }
    public int Value { get; set; }
}