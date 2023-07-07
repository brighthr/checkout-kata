namespace Kata.Checkout.Interfaces
{
    public interface IOfferService
    {
        bool IsOfferAvailable(char item);
        int GetDiscountedPrice(char item, int quantity, int regularPrice);
    }

}
