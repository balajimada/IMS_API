using System;

namespace Agro.Model
{
    public class ProductModel
    {
        public Int64 ProductID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescr { get; set; }
        public string ProductTags { get; set; }
        public decimal ReceviedCost { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal TotalPrice { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }   

}
