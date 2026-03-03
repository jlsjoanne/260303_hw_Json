using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace _260303_hw_Json
{
    public static class JsonRetrieval
    {
        public static string GetJsonContent(string url)
        {
            var targetUrl = url;
            var request = WebRequest.Create(targetUrl);
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";

            var response = request.GetResponse();
            string text;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
    }
}