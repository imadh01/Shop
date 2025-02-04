namespace Shop.Service.DTOs
{
    public class CouponDTO
    {
        public Guid CouponId { get; set; }
        public string CouponCode { get; set; }
        public string DiscountType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal DiscountValue { get; set; }
    }
}
