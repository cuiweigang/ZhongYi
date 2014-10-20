namespace ZhongYi.WuSe.WebApi.Logic.Helpers
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Web;
    using log4net;

    /// <summary>
    /// 日志组件
    /// </summary>
    public static class LoggerHelper
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        public static ILog log = LogManager.GetLogger("zhongyi.wuse");

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="value"></param>
        public static void Error(object value)
        {
            WriteLog(value, log.Error);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        public static void Error(string message, Exception value)
        {
            WriteLog(value, log.Error);
        }

        /// <summary>
        /// 消息记录
        /// </summary>
        /// <param name="value"></param>
        public static void Info(object value)
        {
            WriteLog(value, log.Info);
        }

        /// <summary>
        /// 提醒
        /// </summary>
        /// <param name="value"></param>
        public static void Warring(object value)
        {
            WriteLog(value, log.Warn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="action">Action</param>
        private static void WriteLog(object message, Action<object> action)
        {
            var serverInfo = new StringBuilder();
            serverInfo.AppendLine();
            serverInfo.AppendFormat("WHO:{0}", System.Net.Dns.GetHostName());
            serverInfo.AppendLine();

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                serverInfo.AppendLine("HTTP HEADER: ------------------------------- ");
                serverInfo.AppendLine(string.Format("  CLIENT IP: {0}", CommonHelper.GetIPAddress()));
                foreach (string key in context.Request.Headers.Keys)
                {
                    serverInfo.AppendLine(string.Format("  {0}: {1}", key, context.Request.Headers[key]));
                }
                serverInfo.AppendLine(string.Format("  URL: {0}", context.Request.RawUrl));
                serverInfo.AppendLine(string.Format("  HttpMethod: {0}", context.Request.HttpMethod));

                if (context.Request.HttpMethod != "GET")
                {
                    serverInfo.AppendLine(" Form Data:");
                    foreach (var key in context.Request.Form.AllKeys)
                    {
                        serverInfo.AppendLine(string.Format("  {0}: {1}", key, context.Request.Form[key]));
                    }
                }
                serverInfo.AppendLine("HTTP HEADER: ------------------------------- ");
                serverInfo.AppendLine();
            }

            if (message != null)
            {
                var exception = message as Exception;
                if (exception != null && string.IsNullOrEmpty(exception.StackTrace))
                {
                    serverInfo.AppendLine(string.Format("StackTrace: {0}", new StackTrace()));
                }

                serverInfo.AppendLine(message.ToString());
                serverInfo.AppendLine(string.Empty);
            }

            action(serverInfo);
        }
    }
}
