using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConcordyaPayee.Thirdparty.Core
{
    public class EmaySmsResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public class SmsServiceProvider
    {
        private static string emayServiceUri = @"http://sdk4report.eucp.b2m.cn:8080/sdkproxy/sendsms.action";
        private static string emaycdKey = "0SDK-EBB-6688-KFUPT";
        private static string emaypassword = "428935";
        /// <summary>
        /// Different service provider may have prerequirement before calling this function
        /// Some needs to register a license first.
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSms(string phone, string message)
        {

#if DEBUG
            //var r = new Random().Next(10);
            //return r<=8 ;
#endif

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                Dictionary<string, string> content = new Dictionary<string, string>();
                content.Add("cdkey", emaycdKey);
                content.Add("password", emaypassword);
                content.Add("phone", phone);
                content.Add("message", message);
                //content.Add("seqid", emaycdKey);
                HttpResponseMessage response = client.PostAsync(emayServiceUri, new FormUrlEncodedContent(content)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var stringResult = response.Content.ReadAsStringAsync().Result;
                    if (stringResult.Contains("<error>0</error>"))
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException(stringResult);
                        //return false;
                    }
                    //XmlSerializer xmlSerializer = new XmlSerializer(typeof(EmaySmsResponse));
                    //EmaySmsResponse result = xmlSerializer.Deserialize(stream) as EmaySmsResponse;
                    //if (result != null && result.Error == "0") return true;
                    //else throw new Exception(result.Message);
                }
            }
            return false;
        }
    }
}
