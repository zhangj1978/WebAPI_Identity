using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositors;
using ConcordyaPayee.Web.Api.Models;

namespace ConcordyaPayee.Web.Api.Controllers
{

    public class BillController : ApiController
    {
        private IBillRepository _billRepo;
        private IUnitOfWork _unitOfWork;

        public BillController(IBillRepository billRepo, IUnitOfWork unitOfWork)
        {
            _billRepo = billRepo;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 新增一笔Bill信息
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] BillItemModel bill)
        {

            return InternalServerError();
        }
    }
}
