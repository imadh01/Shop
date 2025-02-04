using Microsoft.Identity.Client;
using Shop.DataHub.Models.Domain;
using Shop.DataHub.Repositary;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Service.BusinessLogic
{
    public class CouponService : ICouponService
    {
        private readonly ICouponData _data;
        public CouponService(ICouponData data)
        {
            _data = data;
        }
        public List<CouponDTO> Get()
        {
            var coupondata = _data.Get();
            var coupon = new List<CouponDTO>();
            foreach (var item in coupondata)
            {
                coupon.Add(new CouponDTO()
                {
                    CouponId = item.CouponId,
                    CouponCode = item.CouponCode,
                    DiscountType = item.DiscountType,
                    ExpiryDate = item.ExpiryDate
                });
            }
            return coupon;
        }
        public CouponDTO GetById(Guid id)
        {
            var coupondata = _data.GetById(id);
            var coupon = new CouponDTO()
            {
                CouponId = coupondata.CouponId,
                CouponCode = coupondata.CouponCode,
                DiscountType = coupondata.DiscountType,
                ExpiryDate = coupondata.ExpiryDate
            };
            return coupon;
        }
        public CouponDTO Create(AddCouponDTO input)
        {
            var coupon = new Coupon()
            {
                CouponCode = input.CouponCode,
                DiscountType = input.DiscountType,
                ExpiryDate = input.ExpiryDate,
                DiscountValue = input.DiscountValue

            };

            coupon = _data.Create(coupon);

            var output = new CouponDTO()
            {
                CouponId = coupon.CouponId,
                CouponCode = coupon.CouponCode,
                DiscountType = coupon.DiscountType,
                ExpiryDate = coupon.ExpiryDate,
                DiscountValue = coupon.DiscountValue
            };

            return output;
        }
        public CouponDTO Update(Guid CouponId, AddCouponDTO input)
        {
            var coupon = _data.GetById(CouponId);
            if (coupon == null)
            {
                return null;
            }
            coupon.CouponCode = input.CouponCode;
            coupon.ExpiryDate = input.ExpiryDate;
            coupon.DiscountType = input.DiscountType;
            coupon = _data.Update(coupon);
            var output = new CouponDTO()
            {
                CouponId = coupon.CouponId,
                CouponCode = coupon.CouponCode,
                DiscountType = coupon.DiscountType,
                ExpiryDate = coupon.ExpiryDate
            };
            return output;
        }
            public bool Delete(Guid CouponId) {
                var coupon=_data.GetById(CouponId);
                if (coupon == null)
                {
                    return false;
                }
                _data.Delete(coupon);
                return true;



        }
    }
}

