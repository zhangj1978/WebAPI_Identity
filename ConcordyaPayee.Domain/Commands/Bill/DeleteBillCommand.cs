using ConcordyaPayee.CommandProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Domain
{
    public class DeleteBillCommand :ICommand
    {
        public string BillId { get; set; }
    }
}
