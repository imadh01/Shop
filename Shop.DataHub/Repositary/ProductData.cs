using Shop.DataHub.Models.Domain;

namespace Shop.DataHub.Repositary
{
    public class ProductData : IProductData
    {
        private readonly ShopDbContext _context;
        public ProductData(ShopDbContext context)
        {
            _context = context;
        }
        public List<Product> Get()
        {
            var product = _context.Products.ToList();
            return product;
        }
        public Product GetById(Guid id)
        {
            var product = _context.Products.FirstOrDefault(t => t.ProductId == id);
            return product;
        }
        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        public Product Update(Product product)
        {
            _context.SaveChanges();
            return product;
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();

        }
    }
}
