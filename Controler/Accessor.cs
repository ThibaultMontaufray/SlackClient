using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace SlackClient
{
    public class Accessor
    {
        #region Attributes
        public static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];
        public static readonly string TOKENHEADER = ConfigurationManager.AppSettings["TOKENHEADER"];
        #endregion

        #region Constructor
        public Accessor()
        {

        }
        #endregion

        #region Methods public
        public static string JsonGet(string url, Dictionary<string, string> headers = null)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.Headers.Add(TOKENHEADER, TOKEN);
            if (headers != null) { foreach (var item in headers) { webRequest.Headers.Add(item.Key, item.Value); } }
            WebResponse response = webRequest.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return reader.ReadToEnd();
            }
        }
        public static string JsonPost(string url, string data = "", Dictionary<string, string> headers = null)
        {
            try
            {
                byte[] dataStream = Encoding.UTF8.GetBytes(data);
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = dataStream.Length;
                webRequest.Headers.Add(TOKENHEADER, TOKEN);
                if (headers != null) { foreach (var item in headers) { webRequest.Headers.Add(item.Key, item.Value); } }

                Stream newStream = webRequest.GetRequestStream();

                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
                WebResponse response = webRequest.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    return reader.ReadToEnd();
                }
            }
            catch (WebException exp)
            {
                using (var reader = new StreamReader(exp.Response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string ret = reader.ReadToEnd();
                    return string.IsNullOrEmpty(ret) ? exp.Message : ret;
                }
            }
        }
        public static string JsonPostFormData(string url, Dictionary<string, string> data = null)
        {
            try
            {
                NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        outgoingQueryString.Add(item.Key, item.Value);
                    }
                }
                outgoingQueryString.Add(TOKENHEADER, TOKEN);
                string postdata = outgoingQueryString.ToString();

                url += "?" + postdata;
                byte[] dataStream = Encoding.UTF8.GetBytes(string.Empty);
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = dataStream.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
                WebResponse response = webRequest.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException exp)
            {
                using (var reader = new StreamReader(exp.Response.GetResponseStream()))
                {
                    string ret = reader.ReadToEnd();
                    return string.IsNullOrEmpty(ret) ? exp.Message : ret;
                }
            }
        }

        public static T Deserialize<T>(string input)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return (T)js.Deserialize(input, typeof(T));
        }
        public static string Serialize(object input)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(input);
        }
        #endregion
    }
}
