using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Model.Entities;

namespace ConcordyaPayee.Data.Repositors
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(IDatabaseFactory dbFactory):base(dbFactory)
        {
            
        }
    }

    public interface IBillRepository:IRepository<Bill>
    {

    }
}
