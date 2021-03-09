using DecisionTech.DTOs;
using DecisionTech.Entities;

namespace DecisionTech.Services.Basket
{
    //To be used with DI to give flexibility when mocking in the future
    public interface IBasketService
    {
        void AddItem(Product product, int quantity);
        OrderSummaryDTO GetOrderSummary();
    }
}