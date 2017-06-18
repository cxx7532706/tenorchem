using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace tenorchem.Models

{
    public class Product
    {
        public int ProductId {get; set;}
        [Required]
        public string Name {get; set;}
        public string Purity {get; set;}
        public string Comment {get; set;}

        public virtual ICollection<PurchaseRecord> PurchaseRecord {get; set;}


    }
}