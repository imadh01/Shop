using System.ComponentModel.DataAnnotations;

namespace Shop.DataHub.Models.Domain
{
    public class Supplier
    {
        public Guid SupplierId { get; set; } 
        public string SupplierName { get; set; }
        public string AgencyName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

}
