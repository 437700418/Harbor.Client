using Horbor.Client.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horbor.Client
{
    public interface IHorborClient : IDisposable
    {

        /// <summary>
        /// 给Horbor发生请求的基础方法
        /// </summary>
        /// <param name="requestUri">请求地址</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="dataObj">请求数据</param>
        /// <returns></returns>
        Task<string> SendAsync(string requestUri, HttpMethod httpMethod, object dataObj);

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<string> GetAsync(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> GetAsync<T>(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Post请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<string> PostAsync(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Post请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> PostAsync<T>(string requestUri, object dataObj);


        /// <summary>
        /// 给Horbor发送Put请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<string> PutAsync(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Put请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> PutAsync<T>(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Delete请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<string> DeleteAsync(string requestUri, object dataObj);

        /// <summary>
        /// 给Horbor发送Delete请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> DeleteAsync<T>(string requestUri, object dataObj);

    }
}
