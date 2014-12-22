using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Model.Entities;

namespace ConcordyaPayee.Model.Entities
{
    public class Bill
    {
        public string Id { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int BillStatus { get; set; }
        public bool IsRecurring { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual List<BillItem> BillItems { get; set; }
    }
}
