namespace DecisionTech.DTOs
{
    public class OrderSummaryDTO
    {
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal => Total - Discount;
    }
}