using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ConcordyaPayeeDataContext dataContext;
        public ConcordyaPayeeDataContext Get()
        {
            return dataContext ?? (dataContext = new ConcordyaPayeeDataContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
