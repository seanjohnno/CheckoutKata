# CheckoutKata

> "How you would refactor your solution to deliver future requirements"

I've kept the code light and MVPish as the brief seems to nudge towards rather than making assumptions. So in make believe land where I'm having a chat with product, covids over and we're even having a pub planning session, these are the questions that immediately spring to mind:

### Questions

* Does the offer apply multiple times? is that configurable? i.e. would 4 biscuits would give you 2 discounts
* Do we have different types of offers? Percentage, 3 for 2, etc. I've handily left that extensible with ISpecialOffer for almost zero extra effort
* Can multiple offers apply?

If the answer is yes to all the above, then I think we'd need to alter Checkout::CalculateTotalPrice as follows:

1. Take the list of all scanned items
2. Run through all the offer rules, if any offers apply then use X to pick the offer. X is a business rule but let's say it's "pick the best offer"
3. We now have an offer and a remaining list if items
4. Goto 1 with the remaining list of items, keep looping until no further offers are applied
5. Sum all offers + non discounted items

* Can multiple offers apply to the same item(s)?
* Are there contraints? Perhaps time? Perhaps the amount of time they can be applied?

If so, perhaps we could solve these with decorators around offer implementations

* Perhaps you really love your customers and want to find the absolute best offer combination across all items?

The scenario being that discount 'A' gives us the biggest discount on its own, but it has items which when removed nullify offers 'B' and 'C'. However, 'B' and 'C' combined give the customer a bigger discount than 'A'. Tradeoff being harder to reason over & more computationally expensive
