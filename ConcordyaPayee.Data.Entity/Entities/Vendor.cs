using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcordyaPayee.Data.Entity
{
    public class Vendor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
