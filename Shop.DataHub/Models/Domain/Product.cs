using System.ComponentModel.DataAnnotations;

namespace Shop.DataHub.Models.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; } 
        public decimal DiscountAmount { get; set; }
        public Guid? CouponId { get; set; }
        public Guid? SupplierId { get; set; }

        // Navigation properties
        public Coupon? Coupon { get; set; }
        public Supplier? Supplier { get; set; }
    }

}
