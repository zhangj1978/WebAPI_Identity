using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Model.Entities
{
    public class CompanyCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}
