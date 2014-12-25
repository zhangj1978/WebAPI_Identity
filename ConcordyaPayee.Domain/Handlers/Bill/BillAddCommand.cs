using ConcordyaPayee.CommandProcessor;
using ConcordyaPayee.Data.Entity;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConcordyaPayee.Domain.Handlers
{
    public class BillAddCommand : IValidationHandler<CreateOrUpdateBillCommand>
    {
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<ValidationResult> Validate(CreateOrUpdateBillCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
