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
                product.Add(new ProductDTO()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = (int)item.ProductPrice,
                    DiscountAmount = (int)item.DiscountAmount
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
        public ProductDTO Update(Guid ProductId, AddProductDTO input)
        {
            var supplierid = _supplierData.GetSupplierIdBySupplierName(input.SupplierName);
            var couponid = _couponData.GetCouponIdByCouponCode(input.CouponCode);
            var product = _data.GetById(ProductId);
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
        public bool Delete(Guid ProductId)
        {
            var product = _data.GetById(ProductId);
            if (product == null)
            {
                return false;
            }
            _data.Delete(product);
            return true;
        }
       
    }
}



