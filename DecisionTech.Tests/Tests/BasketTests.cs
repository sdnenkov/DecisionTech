using DecisionTech.Entities;
using DecisionTech.Enums;
using DecisionTech.Services.Basket;
using DecisionTech.Strategies.Discounts;
using NUnit.Framework;

namespace DecisionTech.Tests.Tests
{
    public class BasketTests
    {
        private IBasketService sut;

        [SetUp]
        public void Setup()
        {
            sut = new BasketService(new DiscountCalculator());
        }

        [Test]
        public void EachProductOnceNoDiscount()
        {
            sut.AddItem(new Product(ProductType.Bread), 1);
            sut.AddItem(new Product(ProductType.Butter), 1);
            sut.AddItem(new Product(ProductType.Milk), 1);

            var orderSummary = sut.GetOrderSummary();
            Assert.That(orderSummary.GrandTotal, Is.EqualTo(2.95));
        }

        [Test]
        public void TwoButterHalfBreadDiscount()
        {
            sut.AddItem(new Product(ProductType.Bread), 2);
            sut.AddItem(new Product(ProductType.Butter), 2);

            var orderSummary = sut.GetOrderSummary();
            Assert.That(orderSummary.GrandTotal, Is.EqualTo(3.1));
        }

        [Test]
        public void ThreeMilkFourthFreeDiscount()
        {
            sut.AddItem(new Product(ProductType.Milk), 4);

            var orderSummary = sut.GetOrderSummary();
            Assert.That(orderSummary.GrandTotal, Is.EqualTo(3.45));
        }

        [Test]
        public void DoubleMilkSingleBreadDiscount()
        {
            sut.AddItem(new Product(ProductType.Milk), 8);
            sut.AddItem(new Product(ProductType.Butter), 2);
            sut.AddItem(new Product(ProductType.Bread), 1);

            var orderSummary = sut.GetOrderSummary();
            Assert.That(orderSummary.GrandTotal, Is.EqualTo(9));
        }
    }
}