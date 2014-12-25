using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Entity;
using ConcordyaPayee.Data.Repositories;

namespace ConcordyaPayee.Data.Repositories
{
    public class SmsSendRepository : RepositoryBase<SMSSendRequest>, ISmsRepository
    {
        public SmsSendRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface ISmsRepository : IRepository<SMSSendRequest>
    {

    }
}
