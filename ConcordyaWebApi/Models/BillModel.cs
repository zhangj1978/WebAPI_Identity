using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcordyaPayee.Web.Api.Models
{
    public class BillModel
    {
        public string Id { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual List<BillItemModel> Items { get; set; }
    }
}