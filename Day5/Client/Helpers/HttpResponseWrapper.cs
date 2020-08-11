using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Day5.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            this.HttpResponseMessage = httpResponseMessage;
            this.Response = response;
            this.Success = success;
        }
        public bool Success { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public T Response { get; set; }
    }
}
