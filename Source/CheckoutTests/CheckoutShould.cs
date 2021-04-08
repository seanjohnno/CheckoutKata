using FluentAssertions;
using System.Linq;
using Xunit;

namespace CheckoutTests
{
    public class CheckoutShould
    {
        private readonly Checkout.Checkout _checkout;

        public CheckoutShould()
        {
            _checkout = new Checkout.Checkout();
        }

        [Fact]
        public void ScanItems()
        {
            _checkout.ScanProduct("A99");

            var productList = _checkout.ScannedProductList();
            var scannedProduct = productList.First();

            scannedProduct.SKU.Should().Be("A99");
            scannedProduct.UnitPrice.Should().Be(50);
        }
    }
}
