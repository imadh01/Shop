using Shop.DataHub.Models.Domain;

namespace Shop.DataHub.Repositary
{
    public interface ICouponData
    {
        List<Coupon> Get();
        Coupon GetById(Guid id);
        Coupon Create(Coupon coupon);
        Guid? GetCouponIdByCouponCode(string couponCode);
        Coupon Update(Coupon coupon);
        void Delete(Coupon coupon);
    }
}
