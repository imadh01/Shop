using Shop.DataHub.Models.Domain;

namespace Shop.DataHub.Repositary
{
    public interface ISupplierData
    {
        List<Supplier> Get();
        Supplier GetById(Guid id);
        Supplier Create(Supplier supplier);
        Guid? GetSupplierIdBySupplierName(string supplierName);
        Supplier Update(Supplier supplier);
        void Delete(Supplier supplier);
    }
}
