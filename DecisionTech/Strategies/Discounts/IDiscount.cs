using System.Collections.Generic;
using DecisionTech.Entities;

namespace DecisionTech.Strategies.Discounts
{
    //Strategy pattern
    public interface IDiscount
    {
        decimal GetDiscount(IEnumerable<BasketItem> items);
    }
}