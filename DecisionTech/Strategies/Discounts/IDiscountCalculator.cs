using System.Collections.Generic;
using DecisionTech.Entities;

namespace DecisionTech.Strategies.Discounts
{
    public interface IDiscountCalculator
    {
        decimal GetDiscount(IEnumerable<BasketItem> items);
        IEnumerable<IDiscount> GetDiscountStrategies();
    }
}