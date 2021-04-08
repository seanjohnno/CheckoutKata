using System.Collections.Generic;

namespace Checkout.SpecialOffers
{
    public interface ISpecialOffer
    {
        AppliedOffer ApplySpecialOffer(List<Product> scannedItems);
    }
}
