using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Entity;

namespace ConcordyaPayee.Data.Repositories
{
    public class BillItemRepository : RepositoryBase<BillItem>, IBillItemRepository
    {
        public BillItemRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IBillItemRepository : IRepository<BillItem>
    {

    }
}
