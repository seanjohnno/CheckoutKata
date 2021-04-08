using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.SpecialOffers
{
    public interface ISpecialOffer
    {
        bool DoesSpecialOfferApply(List<Product> scannedProducts);
        
    }
}
