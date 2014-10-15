using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace ZhongYi.WuSe.WebApi.Api.Formatters
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ZhongYi.WuSe.WebApi.Logic.Response;

    /// <summary>
    /// Jsonp数据格式
    /// </summary>
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        /// CallBack
        /// </summary>
        private string callback = string.Empty;

        /// <summary>
        /// JsonpMediaTypeFormatter
        /// </summary>
        /// <param name="callback"></param>
        public JsonpMediaTypeFormatter(string callback = "")
        {
            this.callback = callback;
        }

        /// <summary>
        /// 异步写入数据到流
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        /// <param name="transportContext"></param>
        /// <returns></returns>
        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext)
        {
            if (string.IsNullOrEmpty(this.callback))
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
            try
            {
                this.WriteToStream(value, writeStream, content);
                return Task.FromResult(new AsyncVoid());
            }
            catch (Exception exception)
            {
                TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
                source.SetException(exception);
                return source.Task;
            }
        }

        /// <summary>
        /// 写入数据到流
        /// </summary>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        private void WriteToStream(object value,
            Stream writeStream,
            HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter streamWriter = new StreamWriter(writeStream, this.SupportedEncodings.First()))
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
            {
                var response = new CommonRsponse
                {
                    Status = 200,
                    Data = value,
                    Description = "成功"
                };

                jsonTextWriter.WriteRaw(this.callback + "(");
                serializer.Serialize(jsonTextWriter, response);
                jsonTextWriter.WriteRaw(")");
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        {
        }

    }
}