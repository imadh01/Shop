using Shop.DataHub.Models.Domain;
using Shop.DataHub.Repositary;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Service.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductData _data;
        private readonly ISupplierData _supplierData;
        private readonly ICouponData _couponData;
        public ProductService(IProductData data, ISupplierData supplierdata, ICouponData coupondata)
        {
            _data = data;
            _supplierData = supplierdata;
            _couponData = coupondata;

        }
        public List<ProductDTO> Get()
        {
            var productdata = _data.Get();
            var product = new List<ProductDTO>();
            foreach (var item in productdata)
            {
                decimal finalPrice = item.ProductPrice;

                if (item.Coupon != null && item.Coupon.ExpiryDate >= DateTime.UtcNow)
                {
                    if (item.Coupon.DiscountType == "Cash-Off")
                    {
                        finalPrice = item.ProductPrice - item.Coupon.DiscountValue;
                    }
                    else if (item.Coupon.DiscountType == "Percentage")
                    {
                        finalPrice = item.ProductPrice * (1 - (item.Coupon.DiscountValue / 100));
                    }
                }
                product.Add(new ProductDTO()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = (int)item.ProductPrice,
                    DiscountAmount = (int)(item.ProductPrice - finalPrice),  

                    DiscountType = item.Coupon != null ?
                (item.Coupon.DiscountType == "Cash-Off" ? "Cash-Off" : "Percentage") : "-",

                    supplier = item.Supplier != null ? new SupplierDTO()
                    {
                        SupplierId = item.Supplier.SupplierId,
                        SupplierName = item.Supplier.SupplierName,
                        AgencyName = item.Supplier.AgencyName,
                        Contact = item.Supplier.Contact,
                        Address = item.Supplier.Address,
                        City = item.Supplier.City
                    } : null,
                    coupon = item.Coupon != null ? new CouponDTO()
                    {
                        CouponId = item.Coupon.CouponId,
                        CouponCode = item.Coupon.CouponCode,
                        ExpiryDate = item.Coupon.ExpiryDate,
                        DiscountValue = item.Coupon.DiscountValue,
                    } : null

                });
            }
            return product;
        }
        public ProductDTO GetById(Guid id)
        {
            var productdata = _data.GetById(id);
            var product = new ProductDTO()
            {
                ProductId = productdata.ProductId,
                ProductName = productdata.ProductName,
                ProductPrice = (int)productdata.ProductPrice,
                DiscountAmount = (int)productdata.DiscountAmount
            };
            return product;
        }
        public ProductDTO Create(AddProductDTO input)
        {
            var couponid = _couponData.GetCouponIdByCouponCode(input.CouponCode);
            var supplierid = _supplierData.GetSupplierIdBySupplierName(input.SupplierName);
            if (couponid != null && supplierid != null)
            {
                var product = new Product()
                {
                    ProductName = input.ProductName,
                    ProductPrice = input.ProductPrice,
                    DiscountAmount = input.DiscountAmount,
                    CouponId = couponid.Value,
                    SupplierId = supplierid.Value

                };

                product = _data.Create(product);

                var output = new ProductDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = (int)product.ProductPrice,
                    DiscountAmount = (int)product.DiscountAmount
                };

                return output;
            }
            return null;
        }
        public ProductDTO Update(Guid id, AddProductDTO input)
        {
            var supplierid = _supplierData.GetSupplierIdBySupplierName(input.SupplierName);
            var couponid = _couponData.GetCouponIdByCouponCode(input.CouponCode);
            var product = _data.GetById(id);
            if (supplierid != null && couponid != null & product != null)
            {
                product.SupplierId = supplierid.Value;
                product.CouponId = couponid.Value;
                product.ProductName = input.ProductName;
                product.ProductPrice = input.ProductPrice;
                product.DiscountAmount = input.DiscountAmount;
                product = _data.Update(product);
                var output = new ProductDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = (int)product.ProductPrice,
                    DiscountAmount = (int)product.DiscountAmount
                };
                return output;
            }
            return null;
        }
        public bool Delete(Guid id)
        {
            var product = _data.GetById(id);
            if (product == null)
            {
                return false;
            }
            _data.Delete(product);
            return true;
        }
    }
}


