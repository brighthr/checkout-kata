namespace Kata.Checkout.Interfaces
{
    public interface ICheckout
    {
        void Scan(char item);
        int GetTotalPrice();
    }
}
