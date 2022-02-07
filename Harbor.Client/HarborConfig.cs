using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Client
{
    /// <summary>
    /// Harbor配置
    /// </summary>
    public class HarborConfig
    {
        public HarborConfig()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Harbor用户名</param>
        /// <param name="password">Harbor密码</param>
        /// <param name="serveraddress">Harbor地址</param>
        public HarborConfig(string username,string password,string serveraddress)
        {
            this.Username = username;
            this.Password = password;
            this.ServerAddress = serveraddress;
        }
        /// <summary>
        /// Harbor用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Harbor密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Harbor服务地址
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
    }
}
