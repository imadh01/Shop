using Shop.DataHub.Models.Domain;

namespace Shop.DataHub.Repositary
{
    public class CouponData:ICouponData
    {
        private readonly ShopDbContext _context;
        public CouponData(ShopDbContext context)
        {
            _context = context;
        }
        public List<Coupon> Get()
        {
            var coupon = _context.Coupons.ToList();
            return coupon;
        }
        public Coupon GetById(Guid id)
        {
            var coupon = _context.Coupons.FirstOrDefault(t => t.CouponId == id);
            return coupon;
        }
        public Coupon Create(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            _context.SaveChanges();
            return coupon;
        }
        public Guid?GetCouponIdByCouponCode(string couponCode)
        {
            var coupon = _context.Coupons.FirstOrDefault(x => x.CouponCode == couponCode);
            if (coupon != null)
            {
                return coupon.CouponId;
            }
            return null;
        }
        public Coupon Update(Coupon coupon)
        {
            _context.SaveChanges();
            return coupon;
        }
        public void Delete(Coupon coupon)
        {
            _context.Remove(coupon);
            _context.SaveChanges();
        }

    }
}
