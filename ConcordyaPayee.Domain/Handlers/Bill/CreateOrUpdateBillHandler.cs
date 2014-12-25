using ConcordayPayee.Web.ViewModel;
using ConcordyaPayee.CommandProcessor;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Domain.Handlers.Bill
{
    public class CreateOrUpdateBillHandler : ICommandHandler<CreateOrUpdateBillCommand>
    {
        private readonly IBillItemRepository _billItemRepository;
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrUpdateBillHandler(IBillItemRepository billItemRepository, IBillRepository billRepository,IUnitOfWork unitOfWork)
        {
            this._billItemRepository = billItemRepository;
            this._billRepository = billRepository;
            this._unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateBillCommand command)
        {
            var bill = new BillModel
            {
                Id = command.Id,
                BillNumber = command.BillNumber,
                Amount = command.Amount,
                BillDate = command.BillDate,
                Category = command.Category,
                CreatedBy = command.CreatedBy,
                CreatedOn = command.CreatedOn,
                Description =command.Description,
                DueDate = command.DueDate,
                IsRecurring = command.IsRecurring,
                Items = command.Items,
                LastUpdatedBy = command.LastUpdatedBy,
                LastUpdatedOn = command.LastUpdatedOn,
                RecurringSetting = command.RecurringSetting,
                Status = command.Status,
                Vendor = command.Vendor
            };

            var entity = ModelFactory.Create(bill);

            if (string.IsNullOrEmpty(command.Id))
            {
                
                if (entity.BillItems != null)
                {
                    foreach (var item in entity.BillItems)
                    {
                        _billItemRepository.Add(item);
                    }
                }

                _billRepository.Add(entity);
                _unitOfWork.Commit();

            }
            else
            {
                if (entity.BillItems != null)
                {
                    foreach (var item in entity.BillItems)
                    {
                        _billItemRepository.Update(item);
                    }
                }

                _billRepository.Update(entity);
                _unitOfWork.Commit();
            }

            return new CommandResult(true);
        }
    }
}
