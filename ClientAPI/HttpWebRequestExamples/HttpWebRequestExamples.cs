using System.IO;
using System.Net;

namespace ClientAPI.HttpWebRequestExamples
{
    public class HttpWebRequestExamples
    {
        private static string uri = "https://localhost:44314/";

        public static string CallAction1(string action)
        {
            WebRequest request = WebRequest.Create(uri + action);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using(Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    return reader.ReadToEnd();
                }
            }
        }

        //public static string CallAction2(string action)
        //{
        //    var query = new System.Collections.Generic.Dictionary<string, string>()
        //    {
        //        ["par1"] = "Web Request1",
        //        ["par2"] = "Web Request2"
        //    };

        //    WebRequest request = WebRequest.Create(QueryHelpers);

            
        //}
    }
}
