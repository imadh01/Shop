using Shop.DataHub.Models.Domain;
using System.Linq;

namespace Shop.DataHub.Repositary
{
    public class SupplierData : ISupplierData
    {
        private readonly ShopDbContext _context;
        public SupplierData(ShopDbContext context)
        {
            _context = context;
        }
        public List<Supplier> Get()
        {
            var supplier = _context.Suppliers.ToList();
            return supplier;
        }
        public Supplier GetById(Guid id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(t => t.SupplierId == id);
            return supplier;
        }
        public Supplier Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }
        public Guid? GetSupplierIdBySupplierName(string supplierName)
        {
            var supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierName == supplierName);
            if (supplier != null)
            {
                return supplier.SupplierId;
            }
            return null;

        }
        public Supplier Update(Supplier supplier)
        {
            _context.SaveChanges();
            return supplier;
        }
        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}

