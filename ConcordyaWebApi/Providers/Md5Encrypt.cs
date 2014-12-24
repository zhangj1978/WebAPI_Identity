using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ConcordyaPayee.Web.Api.Providers
{
    public class Md5Encrypt
    {
        public static string Md5EncryptPassword(string data)
        {
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(data);
            var hashed = MD5.Create().ComputeHash(bytes);
            return Encoding.UTF8.GetString(hashed);
        }
    }
}