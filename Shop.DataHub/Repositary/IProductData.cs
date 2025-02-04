using Shop.DataHub.Models.Domain;

namespace Shop.DataHub.Repositary
{
    public interface IProductData
    {
        List<Product> Get();
        Product GetById(Guid id);
        Product Create(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
