using DotNet.Framework.Core.Exceptions;
using System;

namespace DotNet.Framework.Core.Extends
{
    /// <summary>
    /// 对字符串的扩展方法
    /// </summary>
    public static class StringExtend
    {
        /// <summary>
        /// 将字符串以指定分隔符分割成字符串数组，并忽略掉分割后的空字符串
        /// </summary>
        /// <param name="val">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string[] ToStringArr(this string val, char separator)
        {
            if (!string.IsNullOrWhiteSpace(val) && !separator.Equals(null) && !string.IsNullOrEmpty(separator.ToString()))
            {
                string[] strArr = val.Split(separator);
                string[] strArrResult = new string[strArr.Length];

                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (!strArr[i].IsNull())
                        {
                            strArrResult[i] = strArr[i].Trim();
                        }
                    }
                    return strArrResult;
                }

            }
            return new string[0];
        }

        /// <summary>
        /// 将字符串以指定分隔符分割成数字型数组，并忽略掉分割后的空字符串和非数字字符串
        /// </summary>
        /// <param name="val">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static int[] ToIntArr(this string val, char separator)
        {
            if (!string.IsNullOrWhiteSpace(val) && !separator.Equals(null) && !string.IsNullOrEmpty(separator.ToString()))
            {
                string[] strArr = val.Split(separator);
                int[] intArr = new int[strArr.Length];
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (!strArr[i].IsNull() && strArr[i].IsInt())
                        {
                            intArr[i] = strArr[i].ToInt();
                        }
                    }
                    return intArr;
                }

            }
            return new int[0];
        }

        private static void ThrowErrorWhenNull(string val, string error)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new BusinessException(error);
            }
        }

        /// <summary>
        /// 判断字符串是否为数字字符串，非数字字符串或者为空返回false
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsInt(this string val)
        {
            if (!string.IsNullOrWhiteSpace(val))
            {
                int res;
                if (int.TryParse(val, out res))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断字符串是否为正确的事件类型，非时间字符串或者为空返回false
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string val)
        {
            if (!val.IsNull())
            {
                DateTime dt;
                if (DateTime.TryParse(val, out dt))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsNull(this string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将字符串转换为Int类型，转换失败或者字符串为空会抛出异常
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt(this string val)
        {
            ThrowErrorWhenNull(val, "空字符不能转换为整数类型");

            int res;
            if (int.TryParse(val, out res))
            {
                return res;
            }
            else
            {
                throw new BusinessException(string.Format("将{0}转换为整数类型时失败", val));
            }
        }


        /// <summary>
        /// 将字符串转换为Boolean类型，转换失败或者字符串为空会抛出异常
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string val)
        {
            ThrowErrorWhenNull(val, "空字符不能转换为布尔类型");

            bool flg;
            if (bool.TryParse(val, out flg))
            {
                return flg;
            }
            else
            {
                throw new BusinessException(string.Format("将{0}转换为布尔类型时失败", val));
            }
        }

        /// <summary>
        /// 将字符串转换为DateTime?类型，转换失败会返回null
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime2(this string val)
        {
            if (!val.IsNull())
            {
                DateTime dt;
                if (DateTime.TryParse(val, out dt))
                {
                    return dt;
                }
            }
            return null;
        }

        /// <summary>
        /// 将字符串转换为DateTime类型，转换失败或者字符串为空会抛出异常
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string val)
        {
            ThrowErrorWhenNull(val, "空字符不能转换为时间类型");

            DateTime dt;
            if (DateTime.TryParse(val, out dt))
            {
                return dt;
            }
            throw new BusinessException(string.Format("将{0}转换为时间类型时出错", val));

        }

        /// <summary>
        /// 截取指定长度字符串
        /// </summary>
        /// <param name="val">要处理的字符串</param>
        /// <param name="len">指定长度</param>
        /// <param name="endChar">结尾字符，比如...</param>
        /// <returns>返回处理后的字符串</returns>
        public static string ClipString(this string val, int len, string endChar)
        {
            bool isShowFix = false;
            if (len % 2 == 1)
            {
                isShowFix = true;
                len--;
            }
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(val);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;

                try
                {
                    tempString += val.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }

            byte[] mybyte = System.Text.Encoding.Default.GetBytes(val);
            if (isShowFix && mybyte.Length > len)
                tempString += endChar;
            return tempString;
        }
    }
}
