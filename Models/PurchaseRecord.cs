using System.ComponentModel.DataAnnotations;
using System;

namespace tenorchem.Models
{
    public class PurchaseRecord
    {
        public int PurchaseRecordId {set; get;}
        [Required]
        public int SupplierId {set; get;}
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate {get; set;}
        [Required]
        public double PricePerTon {set; get;}
        [Required]
        public double Quantity {set; get;}
        [Required]
        public double TotalPaidPrice {set; get;}

        public double PaidBackPerTon {set; get;}
        
        public double TotalPaidBack {set; get;}
        public string comment {get; set;}

        public int ProductId {get; set;}

        public virtual Supplier Supplier {get; set;}

        public virtual Product Product {get; set;}

    }
}