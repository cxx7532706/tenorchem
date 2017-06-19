using System.ComponentModel.DataAnnotations;
using System;

namespace tenorchem.Models
{
    public class PurchaseRecord
    {
        public int PurchaseRecordId {set; get;}
        [Required]
        [Display(Name = "供应商")]
        public int SupplierId {set; get;}
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "购买日期")]
        public DateTime PurchaseDate {get; set;}
        [Required]
        [Display(Name = "每吨单价（元）")]
        public double PricePerTon {set; get;}
        [Required]
        [Display(Name = "数量（吨）")]
        public double Quantity {set; get;}
        [Required]
        [Display(Name = "总价（元）")]
        public double TotalPaidPrice {set; get;}

        [Display(Name = "每吨补贴（元）")]
        public double PaidBackPerTon {set; get;}
        [Display(Name = "补贴总额（元）")]
        public double TotalPaidBack {set; get;}
        [Display(Name = "附加说明")]
        public string comment {get; set;}
        [Display(Name = "产品名称")]
        public int ProductId {get; set;}

        public virtual Supplier Supplier {get; set;}

        public virtual Product Product {get; set;}

    }
}