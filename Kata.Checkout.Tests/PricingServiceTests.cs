using Xunit;
using System.Collections.Generic;

namespace Kata.Checkout.Tests
{

    public class PricingServiceTests
    {
        private PricingService pricingService;

        public PricingServiceTests()
        {
            List<Product> products = new List<Product>()
            {
                new Product('A', 50), new Product('B', 30), new Product('C', 20), new Product('D', 15)
            };

            pricingService = new PricingService(products);
        }

        [Fact]
        public void GetPrice_ValidItem_ReturnsCorrectPrice()
        {
            // Arrange

            // Act
            int priceA = pricingService.GetPrice('A');
            int priceB = pricingService.GetPrice('B');
            int priceC = pricingService.GetPrice('C');
            int priceD = pricingService.GetPrice('D');

            // Assert
            Assert.Equal(50, priceA);
            Assert.Equal(30, priceB);
            Assert.Equal(20, priceC);
            Assert.Equal(15, priceD);
        }
    }

}
