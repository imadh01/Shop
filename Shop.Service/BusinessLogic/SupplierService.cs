using Shop.DataHub.Models.Domain;
using Shop.DataHub.Repositary;
using Shop.Service.DTOs;
using Shop.Service.Interfaces;

namespace Shop.Service.BusinessLogic
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierData _data;
        public SupplierService(ISupplierData data)
        {
            _data = data;
        }
        public List<SupplierDTO> Get()
        {
            var supplierdata = _data.Get();
            var supplier = new List<SupplierDTO>();
            foreach (var item in supplierdata)
            {
                supplier.Add(new SupplierDTO()
                {
                    SupplierId = item.SupplierId,
                    SupplierName = item.SupplierName,
                    Contact = item.Contact,
                    Address = item.Address
                });
            }
            return supplier;
        }
        public SupplierDTO GetById(Guid id)
        {
            var supplierdata = _data.GetById(id);
            var supplier = new SupplierDTO()
            {
                SupplierId = supplierdata.SupplierId,
                SupplierName = supplierdata.SupplierName,
                Contact = supplierdata.Contact,
                Address = supplierdata.Address
            };
            return supplier;
        }
        public SupplierDTO Create(AddSupplierDTO input)
        {
            var supplier = new Supplier()
            {
                SupplierName = input.SupplierName,
                Contact = input.Contact,
                Address = input.Address,
                City = input.City,
                AgencyName = input.AgencyName
            };

            supplier = _data.Create(supplier);

            var output = new SupplierDTO()
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Contact = supplier.Contact,
                Address = supplier.Address
            };

            return output;
        }
        public SupplierDTO Update(Guid SupplierId, AddSupplierDTO input)
        {
            var supplier = _data.GetById(SupplierId);
            if (supplier == null)
            {
                return null;
            }
            supplier.SupplierName = input.SupplierName;
            supplier.Contact = input.Contact;
            supplier.Address = input.Address;
            supplier = _data.Update(supplier);
            var output = new SupplierDTO()
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Contact = supplier.Contact,
                Address = supplier.Address
            };
            return output;
        }
        public bool Delete(Guid SupplierId)
        {
            var supplier = _data.GetById(SupplierId);
            if (supplier == null)
            {
                return false;
            }
            _data.Delete(supplier);
            return true;
        }
    }
}


