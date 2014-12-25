using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Core.Common
{
    public enum BillStatus
    {
        Created,
        Submitted,
        Closed
    }

    public enum AgingStatus
    {
        Regular,
        Archieved,
        Deleted
    }
}
