using DotNet.Framework.WinXin.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace DotNet.Framework.WinXin.Core.Interactive
{
    public class Authentication
    {
        /// <summary>
        /// 开发者通过检验signature对请求进行校验（下面有校验方式）。
        /// 若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，成为开发者成功，否则接入失败。
        /// 
        /// 加密/校验流程如下：
        /// 1. 将token、timestamp、nonce三个参数进行字典序排序
        /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
        /// 3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Validate(ValidateEntity entity)
        {
            List<string> list = new List<string>();
            list.Add(entity.Token);
            list.Add(entity.Timestamp);
            list.Add(entity.Nonce);
            list.Sort();

            string encryptionKey = string.Join("", list);

            //C# 的 sha1 加密后是大写
            string SHA1 = FormsAuthentication.HashPasswordForStoringInConfigFile(encryptionKey, "sha1");
            //if (entity.Signature.Equals(SHA1, StringComparison.OrdinalIgnoreCase))
            if (entity.Signature == SHA1.ToLower())
            {
                return true;
            }
            return false;
        }
    }
}
