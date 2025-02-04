namespace Shop.Service.DTOs
{
    public class AddCouponDTO
    {
        public string CouponCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal DiscountValue { get; set; }
        public string DiscountType { get; set; }

    }
}
