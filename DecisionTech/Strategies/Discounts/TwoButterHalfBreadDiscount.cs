using System.Collections.Generic;
using System.Linq;
using DecisionTech.Entities;
using DecisionTech.Enums;

namespace DecisionTech.Strategies.Discounts
{
    public class TwoButterHalfBreadDiscount : IDiscount
    {
        private const decimal BREAD_DISCOUNT_PERCENTAGE = 0.5m;

        public decimal GetDiscount(IEnumerable<BasketItem> items)
        {
            var bread = items.FirstOrDefault(e => e.Product.Type == ProductType.Bread);
            var breadCount = (bread?.Quantity ?? 0);
            var butterCount = items.FirstOrDefault(e => e.Product.Type == ProductType.Butter)?.Quantity ?? 0;
            int possibleDiscountedBreads = butterCount / 2;
            int discountedBreads = breadCount < possibleDiscountedBreads ? breadCount : possibleDiscountedBreads;
            var breadPrice = bread?.Product?.Price ?? 0;

            return breadPrice * discountedBreads * BREAD_DISCOUNT_PERCENTAGE;
        }
    }
}