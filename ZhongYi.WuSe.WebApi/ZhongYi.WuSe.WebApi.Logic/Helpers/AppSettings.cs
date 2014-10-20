namespace ZhongYi.WuSe.WebApi.Logic.Helpers
{
    /// <summary>
    /// AppSettings
    /// </summary>
    public static class AppSettings
    {
        private static bool? cancelSign;

        /// <summary>
        /// 是否取消验签
        ///  true: 取消验签功能 
        ///  false:使用验签功能
        /// </summary>
        public static bool CancelSign
        {
            get
            {
                if (!cancelSign.HasValue)
                {
                    var value = System.Configuration.ConfigurationManager.AppSettings["CancelSign"];
                    bool result;
                    bool.TryParse(value, out result);
                    cancelSign = result;
                }

                return cancelSign.Value;
            }
        }
    }
}
