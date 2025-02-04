namespace Shop.Service.DTOs
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public CouponDTO coupon { get; set; }
        public SupplierDTO supplier { get; set; }
        public int DiscountAmount { get; set; }
    }
}
