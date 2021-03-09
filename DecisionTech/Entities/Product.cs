using System;
using DecisionTech.Enums;

namespace DecisionTech.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public ProductType Type { get; set; }
        public decimal Price => GetPrice();

        public Product(ProductType type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        /// <summary>
        /// Calculates price based on product type - temporary solution due to lack of database
        /// </summary>
        /// <returns></returns>
        private decimal GetPrice()
        {
            switch (Type)
            {
                case ProductType.Bread:
                    return 1m;
                case ProductType.Milk:
                    return 1.15m;
                case ProductType.Butter:
                    return 0.8m;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}