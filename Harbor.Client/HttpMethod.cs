using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harbor.Client
{
    /// <summary>
    /// 表示标准的检索和比较 HTTP 方法的基础结构。
    /// </summary>
    public struct HttpMethod : IEquatable<HttpMethod>
    {
        /// <summary>
        /// 表示一个 HTTP DELETE 协议方法。
        /// </summary>
        public static readonly HttpMethod Delete = new HttpMethod("DELETE");

        /// <summary>
        /// 表示一个 HTTP GET 协议方法。
        /// </summary>
        public static readonly HttpMethod Get = new HttpMethod("GET");

        /// <summary>
        /// 表示一个 HTTP HEAD 协议方法。 
        /// 除了服务器在响应中只返回消息头不返回消息体以外，HEAD 方法和 GET 是一样的。
        /// </summary>
        public static readonly HttpMethod Head = new HttpMethod("HEAD");

        /// <summary>
        /// 表示一个 HTTP OPTIONS 协议方法。
        /// </summary>
        public static readonly HttpMethod Options = new HttpMethod("OPTIONS");

        /// <summary>
        /// 表示一个 HTTP POST 协议方法，该方法用于将新实体作为补充发送到某个 URI。
        /// </summary>
        public static readonly HttpMethod Post = new HttpMethod("POST");

        /// <summary>
        /// 表示一个 HTTP PUT 协议方法，该方法用于替换 URI 标识的实体。
        /// </summary>
        public static readonly HttpMethod Put = new HttpMethod("PUT");

        /// <summary>
        /// 表示一个 HTTP TRACE 协议方法。
        /// </summary>
        public static readonly HttpMethod Trace = new HttpMethod("TRACE");

        string _method;
        /// <summary>
        /// 获取 HTTP 方法。
        /// </summary>
        public string Method { get { return _method; } }

        /// <summary>
        /// 使用指定的 HTTP 方法初始化 <see cref="HttpMethod"/> 类的新实例。
        /// </summary>
        /// <param name="method">HTTP 方法。</param>
        public HttpMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
                throw new ArgumentException("参数不能为 null 或空字符串。", "method");

            _method = method.Trim();
        }

        /// <summary>
        /// 确定指定的 <see cref="System.Object"/> 是否等于当前实例。
        /// </summary>
        /// <param name="obj">要与当前实例进行比较的对象。</param>
        /// <returns>如果指定的对象等于当前实例，则为 true；否则为 false。</returns>
        public override bool Equals(object obj)
        {
            if (obj is HttpMethod)
                return Equals((HttpMethod)obj);

            return false;
        }

        /// <summary>
        /// 确定指定的 <see cref="HttpMethod"/> 是否等于当前实例。
        /// </summary>
        /// <param name="other">要与当前实例进行比较的 <see cref="HttpMethod"/>。</param>
        /// <returns>>如果指定的 <see cref="HttpMethod"/> 等于当前实例，
        /// 则为 true；否则为 false。</returns>
        public bool Equals(HttpMethod other)
        {
            return string.Equals(other.Method, Method, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 返回用作此类型的哈希函数。
        /// </summary>
        /// <returns>当前实例的哈希代码。</returns>
        public override int GetHashCode()
        {
            return Method.GetHashCode();
        }

        /// <summary>
        /// 返回表示当前实例的字符串。
        /// </summary>
        /// <returns>表示当前实例的字符串。</returns>
        public override string ToString()
        {
            return Method;
        }

        public static bool operator ==(HttpMethod left, HttpMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HttpMethod left, HttpMethod right)
        {
            return !left.Equals(right);
        }

        public static implicit operator string(HttpMethod method)
        {
            return method.Method;
        }

    }
}
