using Shop.Service.DTOs;

namespace Shop.Service.Interfaces
{
    public  interface IProductService
    {
        List<ProductDTO> Get();
        ProductDTO GetById(Guid id);
        ProductDTO Create(AddProductDTO input);
        ProductDTO Update(Guid ProductId, AddProductDTO input);
        bool Delete(Guid ProductId);
    }
}
