using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Harbor.Client.ResponseModel
{
    public class ErrorResponse
    {
        /// <summary>
        /// 错误消息列表
        /// </summary>
        public List<ErrorInfo> errors { get; set; }=new List<ErrorInfo>(){ };

    }
    public class BaseResponse: ErrorResponse
    {
        /// <summary>
        /// 请求状态编号
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
    }


    public class ApiResponse<T> : BaseResponse
    {
        public T data { get; set; }
    }

    public class ErrorInfo
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; }
    }
}
