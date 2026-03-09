using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace _260303_hw_Json
{
    public static class JsonRetrieval
    {

        private static CookieContainer cookieContainer = new CookieContainer();
        private static readonly HttpClientHandler handler = new HttpClientHandler 
        { 
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            CookieContainer = cookieContainer
        };
        private static HttpClient client = new HttpClient(handler);
      
        public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static string GetJsonContent(string url)
        {
            try
            {
                var targetUrl = url;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetUrl);
                request.Headers.Clear();
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36";
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";
                request.CookieContainer = new CookieContainer();
                


                var response = request.GetResponse();
                string text;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch(Exception ex)
            {
                return $"Request error: {ex.Message}";
            }
            
        }

        

        public static async Task<string> GetJsonContentAsync(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                //client.DefaultRequestHeaders.Add("accept-language", "zh,zh-TW;q=0.9,en-US;q=0.8,en;q=0.7");
                client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");               
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                



                var request = new HttpRequestMessage(HttpMethod.Get, url);
                

                request.Headers.ConnectionClose = false;
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36");
                

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                using(var stream = await response.Content.ReadAsStreamAsync())
                {
                    using(var reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }

            }
            catch(HttpRequestException ex)
            {
                return $"Request error: {ex.Message}";
            }
        }

        public static string GetWebContent(string Url)
        {
            var uri = new Uri(Url);
            var request = WebRequest.Create(Url) as HttpWebRequest;
            WebClient wc = new WebClient();
            //REF: https://stackoverflow.com/a/39534068/288936
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string res = wc.DownloadString(Url);
            // If required by the server, set the credentials.
            request.UserAgent = "PostmanRuntime/7.26.5";
            request.Accept = "/";
            request.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            // 重點是修改這行
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        ////Gemini suggestion
        //public static string testJsonContent(string url)
        //{
        //    using(WebClient wc = new WebClient())
        //    {
        //        wc.Encoding = System.Text.Encoding.UTF8;
        //        wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
        //        try
        //        {
        //            return wc.DownloadString(url);
        //        }
        //        catch(WebException ex)
        //        {
        //            return $"Request error: {ex.Message}";
        //        }
        //    }
        //}
    }
        
}