using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Model.Entities;
using ConcordyaPayee.Web.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConcordyaPayee.Web.Api.Controllers
{
    public class BillController : ApiController
    {
        private IBillRepository _billRepo;
        private IBillItemRepository _billItemRepo;
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationUser _currentUser;

        public BillController(IBillRepository billRepo, IBillItemRepository billItemRepo, IUnitOfWork unitOfWork)
        {
            _billRepo = billRepo;
            _billItemRepo = billItemRepo;
            _unitOfWork = unitOfWork;
        }

        public BillController()
            //: this(DependencyResolver.Current.GetService<IBillRepository>(),
            //DependencyResolver.Current.GetService<IBillItemRepository>(),
            //DependencyResolver.Current.GetService<IUnitOfWork>())
        {
            var dbFactory = new DatabaseFactory();
            _billRepo = new BillRepository(dbFactory);
            _billItemRepo = new BillItemRepository(dbFactory);
            _unitOfWork = new UnitOfWork(dbFactory);

            //_billRepo = DependencyResolver.Current.GetService<IBillRepository>();
            //_billItemRepo = DependencyResolver.Current.GetService<IBillItemRepository>();
            //_unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
        }

        public IHttpActionResult Get()
        {
            var sevenDaysAgo = DateTime.Now.AddDays(-7);
            var _userId = User.Identity.GetUserId();
            var billEntitys = _billRepo.GetAll().OrderByDescending(k=> k.LastUpdatedOn).ToList();

            List<BillModel> billDtos = new List<BillModel>(billEntitys.Count());
            foreach (var e in billEntitys)
            {
                //var d = ModelFactory.Create(e);
                var d = AutoMapper.Mapper.Map<BillModel>(e);
                billDtos.Add(d);
            }
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(billDtos, Formatting.Indented, jsonSerializerSettings);

            return Ok(billDtos);
        }

        
        public IHttpActionResult Get([FromUri]string id)
        {
            var eBill = _billRepo.Get(b => b.Id == id && b.AgingStatus == Model.AgingStatus.Regular);
            if (eBill == null) return NotFound();
            var dtoBill = ModelFactory.Create(eBill);
            return Ok(dtoBill);
        }

        /// <summary>
        /// 新增一笔Bill信息
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] BillModel bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (bill == null) return InternalServerError(new ArgumentNullException("Bills 信息为空"));
            var _currentUser = User.Identity.GetUserId();
            var dateNow = DateTime.UtcNow;

            bill.Id = Guid.NewGuid().ToString();
            bill.CreatedBy = User.Identity.GetUserId();
            bill.CreatedOn = dateNow;
            bill.LastUpdatedOn = dateNow;
            bill.LastUpdatedBy = User.Identity.GetUserId();

            var entity = ModelFactory.Create(bill);
            // remove the navigation object, to stop EF save referenced object. http://msdn.microsoft.com/en-us/magazine/dn166926.aspx
            entity.Category = null;
            entity.Vendor = null;
            entity.RecurringSetting = null;

            if (entity.BillItems != null)
            {
                foreach (var item in entity.BillItems)
                {
                    item.BillId = entity.Id;
                    item.Bill = null;
                    item.Id = Guid.NewGuid().ToString();
                    _billItemRepo.Add(item);
                }
            }
            _billRepo.Add(entity);
            try
            {
                _unitOfWork.Commit();
            }
                catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                return InternalServerError(dbEx);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            return Created("/bill/"+bill.Id,bill);
        }

        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                _billRepo.Delete(b => b.Id == id);
                _unitOfWork.Commit();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok();
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
