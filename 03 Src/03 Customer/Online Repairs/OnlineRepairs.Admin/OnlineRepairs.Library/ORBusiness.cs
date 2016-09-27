using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OnlineRepairs.Library
{
    public class ORBusiness
    {
       
        static ORBusiness()
        {
             
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns>返回自发送表示</returns>
        public static bool SendSMS(string phone, string message)
        {
            SMSServiceReference.WebServiceSoapClient client = new SMSServiceReference.WebServiceSoapClient();
            string setting_sn = ConfigurationManager.AppSettings["SMS_SN"];
            string setting_pwd = ConfigurationManager.AppSettings["SMS_Pwd"];

            string sendPwd = DotNet.Framework.Utils.Safety.DESEncrypt.MD5(setting_sn + setting_pwd);
            string content = System.Web.HttpUtility.UrlEncode(message, Encoding.UTF8);

            int smsId = Business_Repairs.SaveSmsMessage(phone, message, 0, false,false);
            if (smsId > 0)
            {
                if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(message))
                {
                    return false;
                }
                //保存DB成功后才调用发送短信接口
                string sendStatus = client.mdsmssend(setting_sn, sendPwd, phone, content, "", "", smsId.ToString(), "");

                int status = 0;
                string codeDescriptoin = string.Empty;
                if (sendStatus == smsId.ToString())
                {
                    status = 1;
                }
                else
                {
                    status = Convert.ToInt32(sendStatus);
                    codeDescriptoin = GetCodeDescription(status);
                }

                //更新状态和 状态说明
                Business_Repairs.ModifySmsStatus(smsId, status, codeDescriptoin);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool SendSMSList(List<string> phones, List<string> messages)
        {
            SMSServiceReference.WebServiceSoapClient client = new SMSServiceReference.WebServiceSoapClient();
            string setting_sn = ConfigurationManager.AppSettings["SMS_SN"];
            string setting_pwd = ConfigurationManager.AppSettings["SMS_Pwd"];

            string sendPwd = DotNet.Framework.Utils.Safety.DESEncrypt.MD5(setting_sn + setting_pwd);
            List<string> smsContent = new List<string>();
            foreach (var item in messages)
            {
                smsContent.Add(System.Web.HttpUtility.UrlEncode(item, Encoding.UTF8));
            }

            string[] smsg = messages.ToArray();
            string[] sphone = phones.ToArray();
            if (smsg.Length <= 0 || sphone.Length <= 0)
            {
                return false;
            }

            List<int> smsIds = new List<int>();
            for (int i = 0; i < smsg.Length; i++)
            {
                smsIds.Add(Business_Repairs.SaveSmsMessage(sphone[i], smsg[i], 0,false,true));
            }

            if (smsIds.Count <= 0)
            {
                return false;
            }
            ///string sendStatus = client.mdsmssend(setting_sn, sendPwd, phone, content, "", "", smsId.ToString(), "");
            client.mdsmssend(setting_sn, sendPwd
                , string.Join(",", sphone)
                , string.Join(",", smsContent)
                , ""
                , ""
                , string.Join(",", smsIds)
                , "");
            return false;
        }

        private static string GetCodeDescription(int code)
        {
            string ret = string.Empty;
            switch (code)
            {
                case -2: ret = "帐号/密码不正确"; break;
                case -4: ret = "余额不足支持本次发送"; break;
                case -5: ret = "数据格式错误"; break;
                case -6: ret = "参数有误"; break;
                case -7: ret = "权限受限"; break;
                case -8: ret = "流量控制错误"; break;
                case -9: ret = "扩展码权限错误"; break;
                case -10: ret = "内容长度长"; break;
                case -11: ret = "内部数据库错误"; break;
                case -12: ret = "序列号状态错误"; break;
                case -14: ret = "服务器写文件失败"; break;
                case -17: ret = "没有权限"; break;
                case -19: ret = "禁止同时使用多个接口地址"; break;
                case -20: ret = "相同手机号，相同内容重复提交"; break;
                case -22: ret = "Ip鉴权失败"; break;
                case -23: ret = "缓存无此序列号信息"; break;
                case -601: ret = "序列号为空，参数错误"; break;
                case -602: ret = "序列号格式错误，参数错误"; break;
                case -603: ret = "密码为空，参数错误"; break;
                case -604: ret = "手机号码为空，参数错误"; break;
                case -605: ret = "内容为空，参数错误"; break;
                case -606: ret = "ext长度大于9，参数错误"; break;
                case -607: ret = "参数错误 扩展码非数字 "; break;
                case -608: ret = "参数错误 定时时间非日期格式"; break;
                case -609: ret = "rrid长度大于18,参数错误 "; break;
                case -610: ret = "参数错误 rrid非数字"; break;
                case -611: ret = "参数错误 内容编码不符合规范"; break;
                case -623: ret = "手机个数与内容个数不匹配"; break;
                case -624: ret = "扩展个数与手机个数数"; break;

                default:
                    break;
            }
            return ret;
        }
    }
}
