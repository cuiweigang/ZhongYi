namespace ZhongYi.WuSe.WebApi.Api.Formatters
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Json工厂
    /// </summary>
    public class JsonFactoryMediaTypeFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        /// 通过参数决定调用哪种格式工厂
        /// </summary>
        /// <param name="type"></param>
        /// <param name="request"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public override MediaTypeFormatter GetPerRequestFormatterInstance(
            Type type,
            HttpRequestMessage request,
            MediaTypeHeaderValue mediaType)
        {
            // 当有callback参数时调用 JsonpMediaTypeFormatter
            // 否则调用ApiJsonMediaTypeFormatter
            string callback;
            if (request.GetQueryNameValuePairs()
                    .ToDictionary(pair => pair.Key, pair => pair.Value)
                    .TryGetValue("callback", out callback))
            {
                return new JsonpMediaTypeFormatter(callback);
            }

            return new ApiJsonMediaTypeFormatter();
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        {
        }

    }
}