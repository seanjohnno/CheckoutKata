using Checkout;
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
            var productRepository = new ProductRepository();
            _checkout = new Checkout.Checkout(productRepository);
        }

        [Fact]
        public void ScanItems()
        {
            _checkout.ScanProduct("A99");

            var scannedProduct = _checkout.ScannedProductList.First();

            scannedProduct.SKU.Should().Be("A99");
            scannedProduct.UnitPrice.Should().Be(50);
        }
    }
}
