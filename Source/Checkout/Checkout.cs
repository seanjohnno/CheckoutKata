using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Checkout
    {
        private readonly ProductRepository _productRepository;

        public Checkout(ProductRepository productRepository)
        {
            ScannedProductList = new List<Product>();
            _productRepository = productRepository;
        }

        public void ScanProduct(string sku)
        {
            var product = _productRepository.GetProductBySKU(sku);
            ScannedProductList.Add(product);
        }

        public List<Product> ScannedProductList { get; private set; }

        public int CalculateTotalPrice()
        {
            return ScannedProductList.Sum(p => p.UnitPrice);
        }
    }
}
