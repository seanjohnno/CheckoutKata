using System.Collections.Generic;

namespace Checkout.SpecialOffers
{
    public class AppliedOffer
    {
        public AppliedOffer(int offerPrice, List<Product> productsWithoutOffersApplied)
        {
            OfferPrice = offerPrice;
            ProductsWithoutOffersApplied = productsWithoutOffersApplied;
        }

        public int OfferPrice { get; }

        public List<Product> ProductsWithoutOffersApplied { get; }
    }
}