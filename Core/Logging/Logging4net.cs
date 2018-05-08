using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;

namespace ViCore.Logging
{
    public class Logging4net
    {
        private static ILog _log;
        protected static ILog Log
        {
            get
            {                
                if (_log == null)
                {
                    log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository("NETCoreRepository");
                    FileInfo fileInfo = new FileInfo("config/log4net.config");
                    log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
                    log4net.Config.BasicConfigurator.Configure(repository);
                    _log= LogManager.GetLogger(repository.Name, "NETCorelog4net");
                }
                return _log;
            }
        }

        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void WriteInfo(object message)
        {
            if (Log.IsInfoEnabled && message != null)
            {
                Log.Info(message+"\r\n ----------------------------");
            }
        }

        /// <summary>
        /// 写系统错误日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void WriteError(Exception ex, object message = null)
        {
            if (message == null)
            {
                message = ex.Message;
            }
            if (Log.IsErrorEnabled)
            {
                Log.Error(message+"\r\n ----------------------------", ex);
            }
        }
    }
}
