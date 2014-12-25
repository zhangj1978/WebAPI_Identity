using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ConcordyaPayee.Web.Api.Models
{
    public class ResponseBaseModel 
    {
        public string ErrorCode { get; set; }
        public string ErrorBrief { get; set; }
        public Exception Exception { get; set; }
    }
}