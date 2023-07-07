using Kata.Checkout.Interfaces;

namespace Kata.Checkout
{
    public class PricingService : IPricingService
    {
        private readonly List<Product> products;

        public PricingService(List<Product> prices)
        {
            this.products = prices ?? throw new ArgumentNullException(nameof(prices));
        }

        public int GetPrice(char sku)
        {
            return products.Single(p => p.SKU == sku).Price;
        }
    }

}
