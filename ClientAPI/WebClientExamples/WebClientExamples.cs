using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace ClientAPI.WebClientExamples
{
    public class WebClientExamples
    {
        private static string uri = "https://localhost:44314/"; // baseURI

        public static string CallAction1(string action)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(uri + action);
            }

        }

        public static string CallAction2and3(string action)
        {
            using(WebClient webClient = new WebClient())
            {
                webClient.QueryString.Add("par1","ABC");
                webClient.QueryString.Add("par2", "123");

                return webClient.DownloadString(uri + action);
            }
        }

        public static string CallAction4and5(string action)
        {
            using(WebClient webClinet = new WebClient())
            {
                NameValueCollection values = new NameValueCollection();

                values.Add("par1", "ABC");
                values.Add("par2", "1234");

                byte[] responseArray = webClinet.UploadValues(uri + action, values);
                return Encoding.UTF8.GetString(responseArray); 
            }
        }

        //public static string CallAction6and7(string action)
        //{
        //    User user = new User();
        //}

        public static string CallAction8(string action)
        {
            using(WebClient client = new WebClient())
            {
                client.Headers.Add("scope", "A3");
                client.Headers.Add(HttpRequestHeader.Cookie, "grandmother-cookies=WEB_CLEINT_COOKIES");
                return client.DownloadString(uri + action);
            }
        }

        public static string CallAction9(string action)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadString(uri + action);
                string headerKeyValue = client.ResponseHeaders["credentials"];

                return headerKeyValue;
            }
        }

        public static string CallDonwload(string action)
        {
            using(WebClient clinet = new WebClient())
            {
                byte[] data = clinet.DownloadData(new Uri(uri + action));
                File.WriteAllBytes(@"C:\Users\ACER\Desktop\APIProject\APIExamples\ClientAPI\WebClientExamples\1.jpg", data);

                return @"C:\Users\ACER\Desktop\APIProject\APIExamples\ClientAPI\WebClientExamples";
            }
        }
    }
}
