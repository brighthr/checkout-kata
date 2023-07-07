using NUnit.Framework;

namespace Kata.Checkout.Tests
{

    [TestFixture]
    public class CheckoutTests
    {
        private Checkout checkout;

        [SetUp]
        public void Setup()
        {
            List<Product> products = new List<Product>()
            {
                new Product('A', 50), new Product('B', 30), new Product('C', 20), new Product('D', 15)
            };

            List<Discount> specialOffers = new List<Discount>
            {
                new Discount(sku:'A',quantity:3,value:130),
                new Discount(sku:'B',quantity:2,value:45)
            };

            OfferService offerService = new OfferService(specialOffers);
            PricingService pricingService = new PricingService(products);

            checkout = new Checkout(pricingService, offerService);
        }

        [Test]
        public void Scan_ValidItem_AddsItemToCart()
        {
            // Arrange
            char item = 'A';

            // Act
            checkout.Scan(item);

            // Assert
            Assert.AreEqual(1, checkout.GetItemCount(item));
        }

        [Test]
        public void GetTotalPrice_NoItemsInCart_ReturnsZero()
        {
            // Arrange

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void GetTotalPrice_ItemsWithNoOffers_CalculatesTotalPrice()
        {
            // Arrange
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('C');

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(105, totalPrice);
        }

        [Test]
        public void GetTotalPrice_ItemsWithOffers_CalculatesTotalPrice()
        {
            // Arrange
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('B');
            checkout.Scan('C');
            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(6, checkout.GetCartItemCount());
            Assert.AreEqual(205, totalPrice);
        }

        [Test]
        public void GetTotalPriec_FiveItemsAdded_CalculateCarryingBagCharges()
        {
            // Arrange
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('C');
            checkout.Scan('D');
            checkout.Scan('D');

            int totalPrice = checkout.GetTotalPrice();

            Assert.AreEqual(135, totalPrice);
        }

        [Test]
        public void GetTotalPriec_SixItemsAdded_CalculateCarryingBagCharges()
        {
            // Arrange
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('C');
            checkout.Scan('D');
            checkout.Scan('D');
            checkout.Scan('D');

            int totalPrice = checkout.GetTotalPrice();

            Assert.AreEqual(155, totalPrice);
        }

    }

}
