using Kata.Checkout.Interfaces;

public class OfferService : IOfferService
{
    private readonly List<Discount> specialPrices;

    public OfferService(List<Discount> specialPrices)
    {
        this.specialPrices = specialPrices ?? throw new ArgumentNullException(nameof(specialPrices));
    }

    public bool IsOfferAvailable(char item)
    {
        return specialPrices.Any(x => x.SKU.Equals(item));
    }

    public int GetDiscountedPrice(char item, int quantity, int regularPrice)
    {
        var discountedProduct = specialPrices.FirstOrDefault(x => x.SKU.Equals(item));

        if (discountedProduct is not null)
        {
            int specialPrice = discountedProduct.Value;
            int numSpecialPriceGroups = quantity / discountedProduct.Quantity;
            int remainingItems = quantity % discountedProduct.Quantity;

            return (numSpecialPriceGroups * specialPrice) + (remainingItems * regularPrice);
        }

        return quantity * regularPrice;
    }
}
