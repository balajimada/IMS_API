using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Model
{
   public class CategoryModel
    {
        public Int64 CategoryID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public decimal GST { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
