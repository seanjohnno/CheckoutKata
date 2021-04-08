using System.Collections.Generic;

namespace Checkout.SpecialOffers
{
    public interface ISpecialOffer
    {
        bool DoesSpecialOfferApply(List<Product> scannedProducts);
        
    }
}
