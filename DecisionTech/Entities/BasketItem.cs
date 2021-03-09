using System;

namespace DecisionTech.Entities
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public BasketItem(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;
        }
    }
}