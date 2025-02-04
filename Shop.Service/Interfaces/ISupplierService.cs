using Shop.Service.DTOs;

namespace Shop.Service.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierDTO> Get();
        SupplierDTO GetById(Guid id);
        SupplierDTO Create(AddSupplierDTO input);
        SupplierDTO Update(Guid SupplierId, AddSupplierDTO input);
        bool Delete(Guid SupplierId);

    }
}
