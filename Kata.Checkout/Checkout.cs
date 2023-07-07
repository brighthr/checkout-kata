using Kata.Checkout.Interfaces;

namespace Kata.Checkout
{
    public class Checkout : ICheckout
    {
        private readonly IPricingService pricingService;
        private readonly IOfferService offerService;
        private readonly List<char> cart;

        public Checkout(IPricingService pricingService, IOfferService offerService)
        {
            this.pricingService = pricingService ?? throw new ArgumentNullException(nameof(pricingService));
            this.offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
            cart = new List<char>();
        }

        public void Scan(char item)
        {
            cart.Add(item);
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            int carryingBagCount = 0;
            int carryingBagPrice = 5;

            if (GetCartItemCount() > 0)
            {

                carryingBagCount = (GetCartItemCount() - 1) / 5 + 1;

                totalPrice += carryingBagPrice * carryingBagCount;
            }


            var itemGroups = cart
           .GroupBy(s => s)
           .Select(group => new { SKU = group.Key, Count = group.Count() })
           .ToList();

            foreach (var item in itemGroups)
            {
                char itemName = item.SKU;
                int itemCount = item.Count;
                int itemPrice = pricingService.GetPrice(itemName);

                if (offerService.IsOfferAvailable(itemName))
                {
                    totalPrice += offerService.GetDiscountedPrice(itemName, itemCount, itemPrice);
                }
                else
                {
                    totalPrice += itemCount * itemPrice;
                }
            }

            return totalPrice;
        }

        public int GetItemCount(char item)
        {
            if (cart is not null)
            {
                return cart.Count(x => x == item);
            }

            return 0;
        }

        public int GetCartItemCount()
        {
            return cart.Count;
        }
    }

}