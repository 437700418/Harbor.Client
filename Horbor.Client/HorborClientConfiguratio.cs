using Horbor.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horbor.Client
{
    /// <summary>
    /// Horbor访问配置
    /// </summary>
    public class HorborClientConfiguratio
    {
        /// <summary>
        /// Api服务的基础路径
        /// </summary>
        public string BaseUri { get; }

        /// <summary>
        /// Horbor用户名
        /// </summary>

        public string UserName { get; }

        /// <summary>
        /// Horbor密码
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="harborConfig"></param>
        public HorborClientConfiguratio(HarborConfig harborConfig) : this(harborConfig.ServerAddress, harborConfig.Username, harborConfig.Password)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseurl">HorborAPi基础地址</param>
        /// <param name="username">Horbor用户名</param>
        /// <param name="password">Horbor密码</param>
        public HorborClientConfiguratio(string baseurl, string username, string password)
        {
            BaseUri = baseurl == null ? "" : (baseurl.StartsWith("http://") ? baseurl : "http://" + baseurl);
            UserName = username ?? "";
            Password = password ?? "";
        }

        /// <summary>
        /// 创建Horbor请求客户端
        /// </summary>
        /// <returns></returns>
        public HorborClient CreatHorborClient()
        {
            return new HorborClient(this);
        }
    }
}
