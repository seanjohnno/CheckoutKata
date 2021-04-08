using Checkout;
using Checkout.SpecialOffers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CheckoutTests
{
    public class QuantitySpecialOfferShould
    {
        private const string AppleSKU = "A99";
        private const string BiscuitSKU = "B15";
        private const int QuantityOf2 = 2;
        private const int UnitPriceOf45 = 45;

        private static readonly Product BiscuitProduct = new Product { SKU = BiscuitSKU };
        private static readonly Product AppleProduct = new Product { SKU = AppleSKU };

        [Fact]
        public void ApplyWhenQuantityAndProductMatches()
        {
            var quantitySpecialOffer = new QuantitySpecialOffer(BiscuitSKU, QuantityOf2, UnitPriceOf45);

            var scannedItems = CreateScannedItemList(BiscuitProduct, BiscuitProduct);

            quantitySpecialOffer.DoesSpecialOfferApply(scannedItems).Should().BeTrue();
        }

        [Fact]
        public void DoesNotApplyWhenQuantityDoesNotMatch()
        {
            var quantitySpecialOffer = new QuantitySpecialOffer(BiscuitSKU, QuantityOf2, UnitPriceOf45);

            var scannedItems = CreateScannedItemList(BiscuitProduct);

            quantitySpecialOffer.DoesSpecialOfferApply(scannedItems).Should().BeFalse();
        }

        private List<Product> CreateScannedItemList(params Product[] products)
        {
            return products.ToList();
        }
    }
}
