﻿using System;
namespace ConcordyaPayee.CommandProcessor
{
     public class ValidationHandlerNotFoundException : Exception
    {
         public ValidationHandlerNotFoundException(Type type)
            : base(string.Format("Validation handler not found for command type: {0}", type))
        {
        }
    }
}
