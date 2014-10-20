using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZhongYi.WuSe.WebApi.Api.Helpers
{
    using System.Web.Http;

    using ZhongYi.WuSe.WebApi.Logic.Exceptions;
    using ZhongYi.WuSe.WebApi.Logic.Response;

    /// <summary>
    /// ApiJsonFormatterHelper
    /// </summary>
    public static class ApiJsonFormatterHelper
    {
        /// <summary>
        /// 转换成结果对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Object ConvertResult(object value)
        {
            var response = new CommonResponse()
            {
                Status = 200,
            };

            if (value is BaseException)
            {
                var exception = value as BaseException;
                response.Status = (int)exception.StatusCode;
                response.Description = exception.Message;
            }
            else if (value is HttpError || value is Exception)
            {
                var exception = new InternalServerException();
                response.Status = (int)exception.StatusCode;
                response.Description = exception.Message;
            }
            else
            {
                response.Data = value;
            }

            return response;
        }

        /// <summary>
        /// ToJson对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(object value)
        {
            var obj = ConvertResult(value);
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}