namespace ZhongYi.WuSe.WebApi.Logic.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// MD5
    /// </summary>
    public class MD5
    {
        private byte[] _md5;

        public MD5(string input) :
            this(input, false)
        {
        }

        public MD5(string input, bool igonreCase)
        {
            Update(input, igonreCase);
        }

        public byte[] Digest
        {
            get
            {
                return _md5;
            }
        }

        public string HexDigest
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToString(_md5).Replace("-", "").ToLower();
                }
                return string.Empty;
            }
        }

        public UInt16 UInt16
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToUInt16(_md5, 0);
                }
                return 0;
            }
        }

        public UInt32 UInt32
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToUInt32(_md5, 0);
                }
                return 0;
            }
        }

        public string HexUInt32
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToUInt32(_md5, 0).ToString("x");
                }
                return string.Empty;
            }
        }

        public UInt64 UInt64
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToUInt64(_md5, 0);
                }
                return 0;
            }
        }

        public string HexUInt64
        {
            get
            {
                if (_md5 != null)
                {
                    return BitConverter.ToUInt64(_md5, 0).ToString("x");
                }
                return string.Empty;
            }
        }

        public MD5 Update(string input)
        {
            return Update(input, false);
        }

        public MD5 Update(string input, bool igonreCase)
        {
            if (string.IsNullOrEmpty(input))
            {
                input = string.Empty;
            }

            if (igonreCase)
            {
                input = input.ToUpper();
            }

            try
            {
                _md5 = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            catch (ArgumentNullException ex)
            {
            }
            catch (ObjectDisposedException ex)
            {
            }

            return this;
        }
    }
}
