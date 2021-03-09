using System;
using System.Collections.Generic;
using System.Linq;
using DecisionTech.DTOs;
using DecisionTech.Entities;
using DecisionTech.Strategies.Discounts;

namespace DecisionTech.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly List<BasketItem> items;
        private readonly IDiscountCalculator discountCalculator;

        public BasketService(IDiscountCalculator discountCalculator)
        {
            items = new List<BasketItem>();
            this.discountCalculator = discountCalculator;
        }

        public void AddItem(Product product, int quantity)
        {
            if (HasProduct(product.Id))
            {
                IncreaseItemQuantity(product.Id, quantity);
            }
            else
            {
                AddNewItem(product, quantity);
            }
        }

        private void IncreaseItemQuantity(Guid productId, int quantity)
            => items.FirstOrDefault(e => e.Product.Id == productId).Quantity += quantity;

        private void AddNewItem(Product product, int quantity)
            => items.Add(new BasketItem(product, quantity));

        public OrderSummaryDTO GetOrderSummary()
            => new OrderSummaryDTO()
                {
                    Total = GetTotal(),
                    Discount = GetDiscount()
                };

        private decimal GetTotal()
            => items
                .Select(e => e.Product.Price * e.Quantity)
                .Sum();

        private decimal GetDiscount() => discountCalculator.GetDiscount(items);

        private bool HasProduct(Guid productId)
            => items.Any(e => e.Product.Id == productId);
    }
}