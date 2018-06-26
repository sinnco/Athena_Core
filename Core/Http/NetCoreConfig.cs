using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ViCore.Http
{
    public static class NetCoreConfig
    {
        public static IHostingEnvironment Environment {get;set;}
        public static void SetEnvironment(IHostingEnvironment env)
        {
            Environment = env;
        }

        /// <summary>
        /// 环境名称
        /// </summary>
        /// <returns></returns>
        public static string EnvironmentName
        {
            get
            {
                return Environment.EnvironmentName;
            }
        }

        /// <summary>
        /// 网站根目录
        /// </summary>
        /// <returns></returns>
        public static string WebRootPath
        {
            get
            {
                return Environment.WebRootPath;
            }
        }
        /// <summary>
        /// 系统根目录
        /// </summary>
        /// <returns></returns>
        public static string ContentRootPath
        {
            get
            {
                return Environment.ContentRootPath;
            }
        }

        static IConfiguration appConfig;

        /// <summary>
        /// 获取appsettings的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSettings(string key)
        {
            string str = "";
            if (appConfig.GetSection(key) != null)
            {
                str = appConfig.GetSection(key).Value;
            }
            return str;
        }

        public static void SetAppSettings(IConfiguration section)
        {
            appConfig = section;
        }
    }
}