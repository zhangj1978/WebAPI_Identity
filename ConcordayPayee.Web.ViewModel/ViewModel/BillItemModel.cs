using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcordyaPayee.Web.ViewModel
{
    public class BillItemModel
    {
        public string Id { get; set; }
        public string href { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastUpdatedOn { get; set; }
        //public string LastUpdatedBy { get; set; }
        public string BillId { get; set; }
    }
}