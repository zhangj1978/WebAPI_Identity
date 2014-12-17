using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
