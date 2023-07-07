using NUnit.Framework;

namespace Kata.Checkout.Tests
{

    [TestFixture]
    public class OfferServiceTests
    {
        private OfferService offerService;

        [SetUp]
        public void Setup()
        {
            List<Discount> specialPrices = new List<Discount>
        {
            new Discount( 'A', 3 ,130),
            new Discount( 'B', 2 ,45)
        };

            offerService = new OfferService(specialPrices);
        }

        [Test]
        public void IsOfferAvailable_ValidItem_ReturnsTrue()
        {
            // Arrange

            // Act
            bool offerAvailableA = offerService.IsOfferAvailable('A');
            bool offerAvailableB = offerService.IsOfferAvailable('B');

            // Assert
            Assert.IsTrue(offerAvailableA);
            Assert.IsTrue(offerAvailableB);
        }

        [Test]
        public void IsOfferAvailable_InvalidItem_ReturnsFalse()
        {
            // Arrange

            // Act
            bool offerAvailableC = offerService.IsOfferAvailable('C');
            bool offerAvailableD = offerService.IsOfferAvailable('D');

            // Assert
            Assert.IsFalse(offerAvailableC);
            Assert.IsFalse(offerAvailableD);
        }

        [Test]
        public void GetDiscountedPrice_ApplicableOffer_ReturnsCorrectPrice()
        {
            // Arrange
            int quantityA = 5;
            int quantityB = 4;
            int regularPriceA = 50;
            int regularPriceB = 30;

            // Act
            int discountedPriceA = offerService.GetDiscountedPrice('A', quantityA, regularPriceA);
            int discountedPriceB = offerService.GetDiscountedPrice('B', quantityB, regularPriceB);

            // Assert
            Assert.AreEqual(230, discountedPriceA);
            Assert.AreEqual(90, discountedPriceB);
        }

        [Test]
        public void GetDiscountedPrice_NoOffer_ReturnsRegularPrice()
        {
            // Arrange
            int quantityC = 3;
            int quantityD = 2;
            int regularPriceC = 20;
            int regularPriceD = 15;

            // Act
            int discountedPriceC = offerService.GetDiscountedPrice('C', quantityC, regularPriceC);
            int discountedPriceD = offerService.GetDiscountedPrice('D', quantityD, regularPriceD);

            // Assert
            Assert.AreEqual(60, discountedPriceC);
            Assert.AreEqual(30, discountedPriceD);
        }
    }

}