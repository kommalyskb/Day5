using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5.Client.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
    }
}
