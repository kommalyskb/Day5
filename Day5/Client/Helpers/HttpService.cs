using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Day5.Client.Helpers
{
    public class HttpService: IHttpService
    {
        private readonly HttpClient httpClient;
        private JsonSerializerOptions defaultOptions => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public HttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var resHttp = await httpClient.GetAsync(url);

            var response = await Deserialize<T>(resHttp, defaultOptions);

            var result = new HttpResponseWrapper<T>(response, resHttp.IsSuccessStatusCode, resHttp);

            return result;
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var resHttp = await httpClient.PostAsync(url, stringContent);

            var response = await Deserialize<TResponse>(resHttp, defaultOptions);

            var result = new HttpResponseWrapper<TResponse>(response, resHttp.IsSuccessStatusCode, resHttp);

            return result;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
