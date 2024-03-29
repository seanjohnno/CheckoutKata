﻿using Checkout.SpecialOffers;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Checkout
    {
        private readonly ProductRepository _productRepository;
        private readonly List<ISpecialOffer> _specialOffers;

        public Checkout(ProductRepository productRepository, List<ISpecialOffer> specialOffers)
        {
            ScannedProductList = new List<Product>();
            _productRepository = productRepository;
            this._specialOffers = specialOffers;
        }

        public void ScanProduct(string sku)
        {
            var product = _productRepository.GetProductBySKU(sku);
            ScannedProductList.Add(product);
        }

        public List<Product> ScannedProductList { get; private set; }

        public int CalculateTotalPrice()
        {
            var offerThatApplies = _specialOffers
                .Select(o => o.ApplySpecialOffer(ScannedProductList))
                .FirstOrDefault();

            return offerThatApplies != null ?
                offerThatApplies.OfferPrice + offerThatApplies.ProductsWithoutOffersApplied.Sum(p => p.UnitPrice) :
                ScannedProductList.Sum(p => p.UnitPrice);
        }
    }
}
