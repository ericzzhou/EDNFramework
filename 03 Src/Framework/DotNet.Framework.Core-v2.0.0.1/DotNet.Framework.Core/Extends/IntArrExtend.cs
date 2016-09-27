using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Core.Extends
{
    /// <summary>
    /// 对Int数组串的扩展方法
    /// </summary>
    public static class IntArrExtend
    {
        /// <summary>
        /// 将Int数组以指定分隔符组合成字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString(this int[] val, char separator)
        {
            if (val == null || val.Count() == 0)
            {
                return "";
            }

            if (separator.Equals(null) || string.IsNullOrEmpty(separator.ToString()))
            {
                throw new Exception("分隔符不能为空");
            }

            StringBuilder sbr = new StringBuilder();

            int index = 0;
            foreach (var item in val)
            {
                if (index > 0)
                {
                    sbr.Append(separator.ToString());
                }
                sbr.Append(item);
                index++;
            }
            return sbr.ToString();
        }
    }
}
