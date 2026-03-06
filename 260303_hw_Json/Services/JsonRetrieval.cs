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
                client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
                client.DefaultRequestHeaders.Add("accept-language", "zh,zh-TW;q=0.9,en-US;q=0.8,en;q=0.7");
                client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");               
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");



                var request = new HttpRequestMessage(HttpMethod.Get, url);
                

                request.Headers.ConnectionClose = false;

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

        //Gemini suggestion
        public static string testJsonContent(string url)
        {
            using(WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                try
                {
                    return wc.DownloadString(url);
                }
                catch(WebException ex)
                {
                    return $"Request error: {ex.Message}";
                }
            }
        }
    }
        
}