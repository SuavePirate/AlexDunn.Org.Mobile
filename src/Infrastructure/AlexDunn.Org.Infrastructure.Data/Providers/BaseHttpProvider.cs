using AlexDunn.Org.Definitions.Models.Data;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Infrastructure.Data.Providers
{
    public class BaseHttpProvider
    {
        /// <summary>
        /// Makes an HTTP GET request for rss xml
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetRssXmlStringAsync(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/rss+xml"));
                var result = await client.GetAsync(url);
                var stringResult = await result.Content.ReadAsStringAsync();
                return stringResult;
            }
        }

        /// <summary>
        /// Makes an HTTP POST request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        protected async Task<T> PostJsonAsync<T>(string url, string json)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                return await HandleResponseAsync<T>(result);
            }
        }

        /// <summary>
        /// Makes an HTTP POST request with no return data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        protected async Task PostJsonAsync(string url, string json)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        /// <summary>
        /// Makes an HTTP GET Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<T> GetJsonAsync<T>(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync(url);
                return await HandleResponseAsync<T>(result);
            }
        }

        /// <summary>
        /// Makes an HTTP PUT request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        protected async Task<T> PutJsonAsync<T>(string url, string json)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                return await HandleResponseAsync<T>(result);
            }
        }

        /// <summary>
        /// Makes an HTTP PUT request with no return data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        protected async Task PutJsonAsync(string url, string json)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<T> DeleteAsync<T>(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var result = await client.DeleteAsync(url);
                return await HandleResponseAsync<T>(result);
            }
        }

        /// <summary>
        /// Handles the response from an HTTP request and parses the data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(content);

            }
            catch
            {
                throw new HttpRequestException(content);
            }
        }

    }
}
