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
            _checkout.ScanProduct("B15");
            _checkout.ScanProduct("C40");
            _checkout.ScanProduct("A99");

            _checkout.ScannedProductList.Count.Should().Be(4);
            _checkout.ScannedProductList.Single(p => p.SKU == "B15" && p.UnitPrice == 30);
            _checkout.ScannedProductList.Single(p => p.SKU == "C40" && p.UnitPrice == 60);
            _checkout.ScannedProductList.Where(p => p.SKU == "A99" && p.UnitPrice == 50).ToList().Count.Should().Be(2);
        }
    }
}
