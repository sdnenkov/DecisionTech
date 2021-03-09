using System.Collections.Generic;
using System.Linq;
using DecisionTech.Entities;
using DecisionTech.Enums;

namespace DecisionTech.Strategies.Discounts
{
    public class ThreeMilkFourthFreeDiscount : IDiscount
    {
        public decimal GetDiscount(IEnumerable<BasketItem> items)
        {
            var milk = items.FirstOrDefault(e => e.Product.Type == ProductType.Milk);
            var milkQuantity = (milk?.Quantity ?? 0);
            var milkCount = items.FirstOrDefault(e => e.Product.Type == ProductType.Milk)?.Quantity ?? 0;
            int possibleDiscountedMilks = milkCount / 3;
            int discountedMilks = milkQuantity < possibleDiscountedMilks ? milkQuantity : possibleDiscountedMilks;
            var milkPrice = milk?.Product?.Price ?? 0;

            return milkPrice * discountedMilks;
        }
    }
}