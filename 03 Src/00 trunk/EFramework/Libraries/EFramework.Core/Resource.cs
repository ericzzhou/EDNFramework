using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Core
{
    public class Resource
    {
        /// <summary>
        /// 创建\"{0}策略对象\"失败，可能存在的原因：未将\"{0}策略程序集\"添加到bin目录中；未在\"Web.Config appSettings\"配置 {1} 策略程序集类型\"
        /// </summary>
        /// <param name="Name">日志/缓存/邮件...</param>
        /// <param name="Setting">Web.Config 配置的策略类型 Setting 名</param>
        /// <returns></returns>
        public static string FormatStrategyError(string Name, string Setting)
        {
            return string.Format("创建\"{0}策略对象\"失败，可能存在的原因：未将\"{0}策略程序集\"添加到bin目录中；未在\"Web.Config appSettings\"配置 {1} 策略程序集类型\"", Name, Setting);
        }
    }
}
