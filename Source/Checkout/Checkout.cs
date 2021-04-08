using System;
using System.Collections.Generic;

namespace Checkout
{
    public class Checkout
    {
        private readonly ProductRepository productRepository;

        public Checkout(ProductRepository productRepository)
        {
            ScannedProductList = new List<Product>();
            this.productRepository = productRepository;
        }

        public void ScanProduct(string sku)
        {
            var product = productRepository.GetProductBySKU(sku);
            ScannedProductList.Add(product);
        }

        public List<Product> ScannedProductList { get; private set; }
    }
}
