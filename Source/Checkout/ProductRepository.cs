using System.Collections.Generic;

namespace Checkout
{
    public class ProductRepository
    {
        private static readonly Dictionary<string, Product> Products = new Dictionary<string, Product>
        {
            {"A99", new Product{ SKU = "A99", UnitPrice = 50 } },
            {"B15", new Product{ SKU = "B15", UnitPrice = 30 } },
            {"C40", new Product{ SKU = "C40", UnitPrice = 60 } }
        };

        public Product GetProductBySKU(string sku)
        {
            return Products[sku];
        }
    }
}
