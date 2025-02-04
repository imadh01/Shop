using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Service.BusinessLogic;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierServices;
        public SupplierController(ISupplierService supplierServices)
        {
            _supplierServices = supplierServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var supplier = _supplierServices.Get();
            return Ok(supplier);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var supplier = _supplierServices.GetById(id);
            return Ok(supplier);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddSupplierDTO request)
        {
            var response = _supplierServices.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.SupplierId }, response);
        }
    
    [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, AddSupplierDTO request)
        {
            var supplier = _supplierServices.Update(id, request);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var supplier = _supplierServices.Delete(id);
            if (supplier == false) {
                return NotFound();
            }
            return Ok(supplier);
        }
    }
}
