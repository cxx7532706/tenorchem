using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace tenorchem.Models

{
    public class Product
    {
        public int ProductId {get; set;}
        [Required]
        [Display(Name = "产品名称")]
        public string Name {get; set;}
        [Display(Name = "纯度(%)")]
        public string Purity {get; set;}
        [Display(Name = "附加说明")]
        public string Comment {get; set;}

        public virtual ICollection<PurchaseRecord> PurchaseRecord {get; set;}


    }
}