using System.Collections.Generic;
using System.Linq;
using DecisionTech.Entities;

namespace DecisionTech.Strategies.Discounts
{
    //Separate calculator to handle the discounts in order to produce a discount for the basket
    //Single responsibility
    public class DiscountCalculator : IDiscountCalculator
    {
        public IEnumerable<IDiscount> GetDiscountStrategies()
        {
            return new List<IDiscount>()
            {
                new TwoButterHalfBreadDiscount(),
                new ThreeMilkFourthFreeDiscount()
            };
        }

        public decimal GetDiscount(IEnumerable<BasketItem> items)
        { 
            var discounts = GetDiscountStrategies();
            return discounts
                .Select(e => e.GetDiscount(items))
                .Sum();
        }
    }
}