using Microsoft.AspNetCore.Mvc;
using Shop.Service.BusinessLogic;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponServices;
        public CouponController(ICouponService couponServices)
        {
            _couponServices = couponServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var coupons = _couponServices.Get();
            return Ok(coupons);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var coupon = _couponServices.GetById(id);
            return Ok(coupon);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddCouponDTO request)
        {
            var response = _couponServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.CouponId }, response);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] AddCouponDTO request)
        {
            var coupon = _couponServices.Update(id, request);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var coupon = _couponServices.Delete(id);
            if (coupon == false)
            {
                return NotFound();
            }
            return Ok(coupon);
        }
    }
}
