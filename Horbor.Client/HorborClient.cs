using Horbor.Client.Group;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Horbor.Client
{
    public sealed class HorborClient : IHorborClient
    {
        private readonly HorborClientConfiguratio _horborConfig;

        private readonly HttpClient _httpClient;

        /// <summary>
        /// 
        /// </summary>
        public  IRepository Repository { get; }

        internal HorborClient(HorborClientConfiguratio horborConfig)
        {
            _horborConfig = horborConfig;
            _httpClient = new HttpClient();

            Repository = new Repository(this);
        }
        /// <summary>
        /// 给Horbor发生请求的基础方法
        /// </summary>
        /// <param name="requestUri">请求地址</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="keyValues">请求数据</param>
        /// <returns></returns>
        private async Task<string> SendAsync(string requestUri, HttpMethod httpMethod, Dictionary<string, string> keyValues)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{_horborConfig.UserName}:{_horborConfig.Password}")));

            httpClient.BaseAddress = new Uri(_horborConfig.BaseUri);
            HttpResponseMessage response = null;
            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
            {
                var formUrlEncodedContent = new FormUrlEncodedContent(keyValues);
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync(requestUri, formUrlEncodedContent);
                }
                else
                {
                    response = await httpClient.PutAsync(requestUri, formUrlEncodedContent);
                }
            }
            else if (httpMethod == HttpMethod.Delete || httpMethod == HttpMethod.Get)
            {
                string url = _horborConfig.BaseUri + requestUri + "?" + keyValues.ToPaeameter();

                if (httpMethod == HttpMethod.Get)
                {
                    response = await httpClient.GetAsync(url);
                }
                else
                {
                    response = await httpClient.DeleteAsync(url);
                }
            }
            else
            {
                throw new NotSupportedException($"{nameof(HorborClient)}不支持的操作。");
            }

            return await response.Content.ReadAsStringAsync();

        }

        /// <summary>
        /// 给Horbor发生请求的基础方法
        /// </summary>
        /// <param name="requestUri">请求地址</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="dataObj">请求数据</param>
        /// <returns></returns>
        public async Task<string> SendAsync(string requestUri, HttpMethod httpMethod, object dataObj)
        {
            return await SendAsync(requestUri, httpMethod, dataObj.ToMap());
        }

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string requestUri, object dataObj) {

            return await SendAsync(requestUri,HttpMethod.Get, dataObj);
        }

        /// <summary>
        /// 给Horbor发送Post请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string requestUri, object dataObj)
        {
            return await SendAsync(requestUri, HttpMethod.Post, dataObj);
        }

        /// <summary>
        /// 给Horbor发送Put请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<string> PutAsync(string requestUri, object dataObj)
        {
            return await SendAsync(requestUri, HttpMethod.Put, dataObj);
        }

        /// <summary>
        /// 给Horbor发送Delete请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(string requestUri, object dataObj)
        {
            return await SendAsync(requestUri, HttpMethod.Delete, dataObj);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
