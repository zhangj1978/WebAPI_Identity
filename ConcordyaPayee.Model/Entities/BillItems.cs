using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Model.Entities
{
    public class BillItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastUpdatedOn { get; set; }
        //public string LastUpdatedBy { get; set; }
        public string BillId{ get; set; }
        public virtual Bill Bill { get; set; }
    }
}
