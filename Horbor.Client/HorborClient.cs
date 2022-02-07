using Horbor.Client.Group;
using Horbor.Client.ResponseModel;
using Horbor.Client.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
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
        public IRepository Repository { get; }

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
        private async Task<HttpResponseMessage> SendAsync(string requestUri, HttpMethod httpMethod, Dictionary<string, string> keyValues)
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

            return response;

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
            return await (await SendAsync(requestUri, httpMethod, dataObj.ToMap())).Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 给Horbor发生请求的泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">请求地址</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="dataObj">请求数据</param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public async Task<ApiResponse<T>> SendAsync<T>(string requestUri, HttpMethod httpMethod, object dataObj)
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();
            var response = await SendAsync(requestUri, httpMethod, dataObj.ToMap());

            apiResponse.statusCode = response.StatusCode;

            var responseStr = await response.Content.ReadAsStringAsync();
            var settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    apiResponse.data = JsonConvert.DeserializeObject<T>(responseStr, settings);
                }
                catch (Exception ex)
                {
                    apiResponse.errors.Add(new ErrorInfo()
                    {
                        message = $"将Harbor Api接口返回结果转换为{typeof(T)} 时出现异常。状态号：{ System.Net.HttpStatusCode.OK.ToString()},数据：{responseStr}",
                        code = "1"
                    });
                }
            }
            else
            {
                ErrorResponse errorObj = null;
                try
                {
                    errorObj = JsonConvert.DeserializeObject<ErrorResponse>(responseStr, settings);
                }
                catch (Exception ex)
                {
                    apiResponse.errors.Add(new ErrorInfo()
                    {
                        message = $"将Harbor Api接口返回结果转换为{typeof(ErrorResponse)} 时出现异常。状态号：{ response.StatusCode.ToString()},数据：{responseStr}",
                        code = "1"
                    });
                }

                if (errorObj != null)
                    apiResponse.errors.AddRange(errorObj.errors);
            }
            return apiResponse;
        }

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string requestUri, object dataObj)
        {
            return await SendAsync(requestUri, HttpMethod.Get, dataObj);
        }

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<ApiResponse<T>> GetAsync<T>(string requestUri, object dataObj)
        {
            return await SendAsync<T>(requestUri, HttpMethod.Get, dataObj);
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
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<ApiResponse<T>> PostAsync<T>(string requestUri, object dataObj)
        {
            return await SendAsync<T>(requestUri, HttpMethod.Post, dataObj);
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
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<ApiResponse<T>> PutAsync<T>(string requestUri, object dataObj)
        {
            return await SendAsync<T>(requestUri, HttpMethod.Put, dataObj);
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

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public async Task<ApiResponse<T>> DeleteAsync<T>(string requestUri, object dataObj)
        {
            return await SendAsync<T>(requestUri, HttpMethod.Delete, dataObj);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
