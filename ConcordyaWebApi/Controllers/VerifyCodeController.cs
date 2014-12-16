using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ConcordyaWebApi.Controllers
{
    [Route("api/verifycode")]
    public class VerifyCodeController : ApiController
    {
        /// <summary>
        /// 验证注册码
        /// </summary>
        /// <returns></returns>
        public bool Get([FromUri] string phone, string verifycode)
        {
            return phone == verifycode;
        }

        /// <summary>
        /// 申请验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Post([FromBody] string phone)
        {

            return true;
        }
    }
}