namespace ZhongYi.WuSe.WebApi.Api.Formatters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ZhongYi.WuSe.WebApi.Logic.Response;

    /// <summary>
    /// Api数据返回结果
    /// </summary>
    public class ApiJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
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
            try
            {
                this.WriteToStream(type, value, writeStream, content);
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
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        private void WriteToStream(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter streamWriter = new StreamWriter(writeStream, this.SupportedEncodings.First()))
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
            {
                var response = new CommonResponse
                {
                    Status = 200,
                    Data = value,
                    Description = "成功"
                };

                serializer.Serialize(jsonTextWriter, response);
            }
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(
            Type type,
            HttpRequestMessage request,
            MediaTypeHeaderValue mediaType)
        {
            return this;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        {
        }

    }
}