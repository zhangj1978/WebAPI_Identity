using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Model.Entities;

namespace ConcordyaPayee.Data
{
    public class ConcordyaPayeeDataContext : DbContext
    {
        public DbSet<SMSSendRequest> SmsSendOuts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
