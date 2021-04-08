﻿using System;
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

        public bool DoesSpecialOfferApply(List<Product> scannedProducts)
        {
            return scannedProducts.Where(p => p.SKU == _productSKU).Count() >= _appliedAtQuantity;
        }

        public AppliedOffer ApplySpecialOffer(List<Product> scannedItems)
        {
            throw new NotImplementedException();
        }
    }
}
