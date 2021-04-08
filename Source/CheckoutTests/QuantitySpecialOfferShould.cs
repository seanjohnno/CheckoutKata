using Checkout;
using Checkout.SpecialOffers;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CheckoutTests
{
    public class QuantitySpecialOfferShould
    {
        private const string BiscuitSKU = "B15";
        private const int QuantityOf2 = 2;
        private const int SpecialOfferPriceOf45 = 45;

        private static readonly Product BiscuitProduct = new Product { SKU = BiscuitSKU };
        private static readonly QuantitySpecialOffer biscuitCountOf2SpecialOffer = new QuantitySpecialOffer(BiscuitSKU, QuantityOf2, SpecialOfferPriceOf45);

        [Fact]
        public void ApplyWhenQuantityAndProductMatches()
        {
            var scannedItems = CreateScannedItemList(BiscuitProduct, BiscuitProduct);

            biscuitCountOf2SpecialOffer.DoesSpecialOfferApply(scannedItems).Should().BeTrue();
        }

        [Fact]
        public void DoesNotApplyWhenQuantityDoesNotMatch()
        {
            var scannedItems = CreateScannedItemList(BiscuitProduct);

            biscuitCountOf2SpecialOffer.DoesSpecialOfferApply(scannedItems).Should().BeFalse();
        }

        [Fact]
        public void ReturnCorrectAppliedDiscount()
        {
            var scannedItems = CreateScannedItemList(BiscuitProduct, BiscuitProduct);

            var appliedDiscount = biscuitCountOf2SpecialOffer.ApplySpecialOffer(scannedItems);

            appliedDiscount.OfferPrice.Should().Be(SpecialOfferPriceOf45);
            appliedDiscount.ProductsWithoutOffersApplied.Should().BeEmpty();
        }

        private static List<Product> CreateScannedItemList(params Product[] products)
        {
            return products.ToList();
        }
    }
}
