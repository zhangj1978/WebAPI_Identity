using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcordyaPayee.CommandProcessor
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult>  Validate(TCommand command);
    }
}
