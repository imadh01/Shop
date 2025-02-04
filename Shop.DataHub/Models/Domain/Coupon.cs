using System.ComponentModel.DataAnnotations;

namespace Shop.DataHub.Models.Domain
{
    public class Coupon
    {
        public Guid CouponId { get; set; }
        public string CouponCode { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

}
