using Catel.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Service.BusinessLogic;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;
        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productServices.Get();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var product = _productServices.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddProductDTO request)
        {
            if (ModelState.IsValid)
            {
                var response = _productServices.Create(request);
                if (response == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(GetById), new { id = response.ProductId }, response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] AddProductDTO request)
        {
            var product = _productServices.Update(id, request);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var product = _productServices.Delete(id);
            if (product == false)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
    
