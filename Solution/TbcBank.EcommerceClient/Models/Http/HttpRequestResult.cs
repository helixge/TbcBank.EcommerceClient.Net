using System;
using System.Net;

namespace TbcBank.EcommerceClient
{
    public class HttpRequestResult
    {
        public bool Success { get; set; }
        public string RawResponse { get; set; }
        public HttpStatusCode HttpStatsCode { get; set; }
        public Exception Exception { get; set; }
        public string RequestUrl { get; set; }
        public string RequestQuery { get; set; }
    }
}
