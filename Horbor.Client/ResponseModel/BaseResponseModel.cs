using System;
using System.Collections.Generic;
using System.Text;

namespace Horbor.Client.ResponseModel
{
    public class BaseResponseModel
    {
        /// <summary>
        /// 错误消息列表
        /// </summary>
        public List<ErrorModel> errors { get; set; }
    }

    public class ErrorModel
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
