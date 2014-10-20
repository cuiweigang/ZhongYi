﻿namespace ZhongYi.WuSe.WebApi.Logic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// 哈希算法Helper
    /// </summary>
    public static class HashHelper
    {
        public static MD5 MD5(string input)
        {
            return MD5(input, false);
        }

        public static MD5 MD5(string input, bool igonreCase)
        {
            return new MD5(input, igonreCase);
        }

        public static SHA SHA1(string input)
        {
            return SHA1(input, false);
        }

        public static SHA SHA1(string input, bool igonreCase)
        {
            return new SHA().SHA1(input, igonreCase);
        }

        public static SHA SHA256(string input)
        {
            return SHA256(input, false);
        }

        public static SHA SHA256(string input, bool igonreCase)
        {
            return new SHA().SHA256(input, igonreCase);
        }
    }
}
