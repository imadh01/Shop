using Shop.Service.DTOs;

namespace Shop.Service.Interfaces
{
    public  interface ICouponService
    {
        List<CouponDTO> Get();
        CouponDTO GetById(Guid id);
        CouponDTO Create(AddCouponDTO input);
        CouponDTO Update(Guid CouponId, AddCouponDTO input);
        bool Delete(Guid CouponId);
    }
}
