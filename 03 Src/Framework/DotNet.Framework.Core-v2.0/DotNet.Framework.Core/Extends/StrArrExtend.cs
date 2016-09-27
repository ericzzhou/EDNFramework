using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Core.Extends
{
    public static class StrArrExtend
    {
        /// <summary>
        /// 将字符串数组以指定分隔符组合成字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString(this string[] val, char separator)
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
                if (!item.IsNull())
                {
                    if (index > 0)
                    {
                        sbr.Append(separator.ToString());
                    }
                    sbr.Append(item);
                    index++;
                }
            }
            return sbr.ToString();
        }
    }
}
