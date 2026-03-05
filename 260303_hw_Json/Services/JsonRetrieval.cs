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

        private static readonly HttpClientHandler handler = new HttpClientHandler { UseProxy = false };
        private static HttpClient client = new HttpClient();
      
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetUrl);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36";
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";
                request.CookieContainer = new CookieContainer();
                request.Referer = "http://www.google.com";
                


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
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/145.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Referer", "http://www.google.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }


            }
            catch(HttpRequestException ex)
            {
                return $"Request error: {ex.Message}";
            }
        }
    }
        
}