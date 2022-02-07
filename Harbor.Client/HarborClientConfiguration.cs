using Harbor.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harbor.Client
{
    /// <summary>
    /// Harbor访问配置
    /// </summary>
    public class HarborClientConfiguration
    {
        /// <summary>
        /// Api服务的基础路径
        /// </summary>
        public string BaseUri { get; }

        /// <summary>
        /// Harbor用户名
        /// </summary>

        public string UserName { get; }

        /// <summary>
        /// Harbor密码
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="harborConfig"></param>
        public HarborClientConfiguration(HarborConfig harborConfig) : this(harborConfig.ServerAddress, harborConfig.Username, harborConfig.Password)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseurl">HarborAPi基础地址</param>
        /// <param name="username">Harbor用户名</param>
        /// <param name="password">Harbor密码</param>
        public HarborClientConfiguration(string baseurl, string username, string password)
        {
            BaseUri = baseurl == null ? "" : (baseurl.StartsWith("http://") ? baseurl : "http://" + baseurl);
            UserName = username ?? "";
            Password = password ?? "";
        }

        /// <summary>
        /// 创建Harbor请求客户端
        /// </summary>
        /// <returns></returns>
        public HarborClient CreatHarborClient()
        {
            return new HarborClient(this);
        }
    }
}
