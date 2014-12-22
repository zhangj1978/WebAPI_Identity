using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Model.Entities;
using ConcordyaPayee.Web.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ConcordyaPayee.Web.Api.Controllers
{

    //[System.Web.Http.Authorize]
    public class BillController : ApiController
    {
        private IBillRepository _billRepo;
        private IBillItemRepository _billItemRepo;
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationUser _currentUser;

        //public BillController(IBillRepository billRepo, IBillItemRepository billItemRepo, IUnitOfWork unitOfWork)
        //{
        //    _billRepo = billRepo;
        //    _billItemRepo = billItemRepo;
        //    _unitOfWork = unitOfWork;
        //}

        public BillController()
            //:this(DependencyResolver.Current.GetService<IBillRepository>(),
            //DependencyResolver.Current.GetService<IBillItemRepository>(),
            //DependencyResolver.Current.GetService<IUnitOfWork>())
        {
            var dbFactory = new DatabaseFactory();
            _billRepo = new BillRepository(dbFactory);
            _billItemRepo = new BillItemRepository(dbFactory);
            _unitOfWork = new UnitOfWork(dbFactory);
        }

        public IHttpActionResult Get()
        {
            var sevenDaysAgo = DateTime.Now.AddDays(-7);
            var _userId = User.Identity.GetUserId();
            var billEntitys = _billRepo.GetAll().ToList();
            //var billEntitys = _billRepo.GetMany(
            //    b => b.DueDate >= sevenDaysAgo
            //        && b.CreatedBy == _currentUser.Id);

            List<BillModel> billDtos = new List<BillModel>(billEntitys.Count());
            foreach (var e in billEntitys)
            {
                var d = new BillModel();
                d.Amount = e.TotalAmount;
                d.Id = e.Id;
                d.CreatedBy = e.Id;
                d.DueDate = e.DueDate;
                d.BillDate = e.DueDate;
                d.BillNumber = e.BillNumber;
                d.CategoryId = e.CategoryId;
                d.Description = e.Description;
                d.Status = (BillStatus)e.BillStatus;

                billDtos.Add(d);
            }
            return Ok(billDtos);
        }

        public IHttpActionResult Get([FromUri]string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增一笔Bill信息
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] BillModel bill)
        {
            
            if (bill == null) return InternalServerError(new ArgumentNullException("Bills 信息为空"));

            //_userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //_currentUser = _userManager.FindById(User.Identity.GetUserId());

            var dateNow = DateTime.UtcNow;
            bill.Id = Guid.NewGuid().ToString();
            bill.CreatedBy = User.Identity.GetUserId();
            bill.CreatedOn = dateNow;
            bill.LastUpdatedOn = dateNow;
            bill.LastUpdatedBy = User.Identity.GetUserId();

            var entity = ModelFactory.Create(bill);

            if (entity.BillItems != null)
            {
                foreach (var item in entity.BillItems)
                {
                    _billItemRepo.Add(item);
                }
            }
            _billRepo.Add(entity);
            _unitOfWork.Commit();
            return Ok(bill);
        }

        private BillItemModel CreateBillItem(BillItemModel item)
        {
            var newItem = item;
#if DEBUG
            newItem.Id = Guid.NewGuid().ToString();
#endif
            return newItem;
        }
    }
}
