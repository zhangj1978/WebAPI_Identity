using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Model.Entities;

namespace ConcordyaPayee.Data.Repositories
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(IDatabaseFactory dbFactory):base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public override IEnumerable<Bill> GetAll()
        {
            var bills = base.DataContext.Bills.Take(30);
            return bills; 
        }

        public IDatabaseFactory _dbFactory { get; set; }
    }

    public interface IBillRepository:IRepository<Bill>
    {

    }
}
