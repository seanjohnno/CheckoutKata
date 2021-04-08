using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.SpecialOffers
{
    public class QuantitySpecialOffer : ISpecialOffer
    {
        private readonly string _productSKU;
        private readonly int _appliedAtQuantity;
        private readonly int _offerPrice;

        public QuantitySpecialOffer(string productSKU, int appliedAtQuantity, int offerPrice)
        {
            _productSKU = productSKU;
            _appliedAtQuantity = appliedAtQuantity;
            _offerPrice = offerPrice;
        }

        public AppliedOffer ApplySpecialOffer(List<Product> scannedItems)
        {
            if(DoesSpecialOfferApply(scannedItems))
            {
                var productsNotInOffer = scannedItems.Where(p => p.SKU != _productSKU);
                var productsWithSameSKUAsOffer = scannedItems.Where(p => p.SKU == _productSKU).ToList();
                var productsWithSameSKUAfterQuantityRemoved = RemoveProductCount(productsWithSameSKUAsOffer, _appliedAtQuantity);

                var allPoductsWithoutOfferApplied = productsNotInOffer.Concat(productsWithSameSKUAfterQuantityRemoved).ToList();
                return new AppliedOffer(_offerPrice, allPoductsWithoutOfferApplied);
            }

            return null;
        }

        private bool DoesSpecialOfferApply(List<Product> scannedProducts)
        {
            return scannedProducts.Where(p => p.SKU == _productSKU).Count() >= _appliedAtQuantity;
        }

        private static List<Product> RemoveProductCount(List<Product> productsInOffer, int quantity)
        {
            if (productsInOffer.Count >= quantity)
            {
                productsInOffer.RemoveRange(0, quantity);
            }
            return productsInOffer;
        }
    }
}
