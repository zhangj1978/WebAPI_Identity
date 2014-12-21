using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ConcordyaPayee.Data.Repositories;
using System.Text;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data;
using ConcordyaPayee.Thirdparty.Core;
using System.Threading.Tasks;
using ConcordyaPayee.Model.Entities;

namespace ConcordyaPayee.Web.Api.Controllers
{
    [Route("api/verifycode")]
    public class VerifyCodeController : ApiController
    {
        private readonly ISmsRepository smsRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// 申请发送，或者验证注册码
        /// </summary>
        /// <param name="smsRepository"></param>
        /// <param name="unitOfWork"></param>
        public VerifyCodeController(ISmsRepository smsRepository, IUnitOfWork unitOfWork)
        {
            this.smsRepository = smsRepository;
            this.unitOfWork = unitOfWork;
        }

        public VerifyCodeController()
        {
            DatabaseFactory dbFactory = new DatabaseFactory();
            this.smsRepository = new SmsSendRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        public IUnitOfWork UnitOfWork { get; set; }

        private string GenerateRandomString()
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble() + 75)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private string GenerateRandomNumber(int length)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                string ch = Math.Floor(9 * random.NextDouble()).ToString();
                builder.Append(ch);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 验证注册码
        /// </summary>
        /// <returns>verifyResult:true 或者 verifyResult:false</returns>
        public IHttpActionResult Get([FromUri] string phone, string verifycode)
        {
#if DEBUG
            return Ok(new {verifyResult = phone == verifycode });
#endif

            var sms = smsRepository.GetMany(s => s.ValidUntil >= DateTime.Now && s.Phone == phone).OrderByDescending(k => k.LastUpdatedOn).ToList().First();
            var sentCode = string.Empty;
            if ((sms != null) && (!string.IsNullOrEmpty(sms.VerifyCode)))
            {
                sentCode = sms.VerifyCode;
            }
            else
            {
                return NotFound();
            }
            return Ok(new {verifyResult = sentCode == verifycode});
        }

        /// <summary>
        /// 申请验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>开发阶段返回 { phone = xxxx, sentCode = xxxx }</returns>
        public IHttpActionResult Post([FromBody]string phone)
        {
            //1. Generate Verifycode and saved to DB
            //2. Sendout verifycode via SMS provider
            var code = GenerateRandomNumber(6);
            var message = "【有序科技】您的注册验证码为：" + code + "。请在5分钟内输入";
            var sms = new SMSSendRequest(){ CreatedOn = DateTime.Now, Message = message, VerifyCode = code, Phone = phone, ValidUntil = DateTime.Now.AddMinutes(5), LastUpdatedOn = DateTime.Now, Status = SMSSendRequest.RequestStatus.Created };

            smsRepository.Add(sms);
            unitOfWork.Commit();
            var serviceResult = SmsServiceProvider.SendSms(phone, message);
            if (!serviceResult)
            {
                sms.LastUpdatedOn = DateTime.Now;
                sms.Status = SMSSendRequest.RequestStatus.Send;
                smsRepository.Update(sms);
                unitOfWork.Commit();
                return InternalServerError(new Exception("短信发送服务失败"));
            }
            else
            {
                sms.LastUpdatedOn = DateTime.Now;
                sms.Status = SMSSendRequest.RequestStatus.Send;
                smsRepository.Update(sms);
                unitOfWork.Commit();
#if DEBUG
                return Ok(new { phone = phone, sentCode = code });
#endif
                return Ok();
            }
        }
    }
}