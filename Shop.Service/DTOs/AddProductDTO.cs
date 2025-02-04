namespace Shop.Service.DTOs
{
    public class AddProductDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; }
        public string CouponCode { get; set; }
        public string SupplierName { get; set; }
        public int DiscountAmount { get; set; }

    }
}
