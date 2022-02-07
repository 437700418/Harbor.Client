using Harbor.Client.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Harbor.Client
{
    public static class HarborUtil
    {
        /// <summary>
        /// 参数拼接Url
        /// </summary>
        /// <param name="source">要拼接的实体</param>
        /// <returns>Url,</returns>
        public static string ToPaeameter(this object source)
        {
            var buff = new StringBuilder(string.Empty);
            if (source == null)
                throw new ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");

            if (source.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (var item in (source as Dictionary<string, string>))
                {
                    buff.Append(WebUtility.UrlEncode(item.Key + "") + "=" + WebUtility.UrlEncode(item.Value + "") + "&");
                }
            }
            else
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                {
                    object value = property.GetValue(source);
                    if (value != null)
                    {

                        buff.Append(WebUtility.UrlEncode(property.Name + "") + "=" + WebUtility.UrlEncode(value + "") + "&");
                    }
                }
            }
            return buff.ToString().Trim('&');
        }

        /// <summary>
        /// 对象转换为字典
        /// </summary>
        /// <param name="obj">待转化的对象</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToMap(this object obj)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            if (obj == null)
            {
                return map;
            }

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();
                if (p.GetCustomAttribute(typeof(MarkNotQueryStringAttribute)) == null && m != null && m.IsPublic)
                {
                    // 进行判NULL处理
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                    }
                }
            }
            return map;
        }
    }
}
