using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordyaPayee.Model.Entities
{
    public class SMSSendRequest
    {
        public enum RequestStatus  {Created, Pending, Send, Received, Failed, None};

        public int Id { get; set; }
        /// <summary>
        /// 发送至
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// <1--可替换的文本，用于替换发送内容里面的占位符-->
        /// 先搞成指定的一个属性，仅用于保存验证码
        /// </summary>
        public string VerifyCode{ get; set; }
        /// <summary>
        /// 过期时间，超过这个时间则消息无效
        /// </summary>
        public DateTime ValidUntil { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public RequestStatus Status { get; set; }
    }
}
