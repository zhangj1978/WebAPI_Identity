using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Model;

namespace ConcordyaPayee.Data
{
    public class ConcordyaPayeeDataContext : DbContext
    {
        public DbSet<SMSSendRequest> SmsSendOuts { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
