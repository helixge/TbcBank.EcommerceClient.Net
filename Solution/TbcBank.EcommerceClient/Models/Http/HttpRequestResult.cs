using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class HttpRequestResult
    {
        public bool Success { get; set; }
        public string RawResponse { get; set; }
        public HttpStatusCode HttpStatsCode { get; set; }
    }
}
