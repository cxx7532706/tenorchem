using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace tenorchem.Models
{
    public class Supplier
    {
        public int SupplierId {get; set;}
        [Required]
        public string SupplierName {get; set;}
        public string Comment {get; set;}

        public virtual ICollection<PurchaseRecord> PurchaseRecord {get; set;}

    }
}