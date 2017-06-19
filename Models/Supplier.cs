using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace tenorchem.Models
{
    public class Supplier
    {
        public int SupplierId {get; set;}
        [Required]
        [Display(Name = "供应商名称")]
        public string SupplierName {get; set;}
        [Display(Name = "联系人")]
        public string Contactor {get; set;}
        [Display(Name = "联系电话")]
        public string ContactNumber {get;set;}
        [Display(Name = "供应商地址")]
        public string Address {get; set;}
        [Display(Name = "附加说明")]
        public string Comment {get; set;}

        public virtual ICollection<PurchaseRecord> PurchaseRecord {get; set;}

    }
}