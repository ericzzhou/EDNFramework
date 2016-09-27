using EFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EFramework.HttpModule.Entities
{
    [Serializable]
    public class ServerLastError
    {
        public Exception Exception { get; set; }
        public string RequestUri { get; set; }
        public string RefererUri { get; set; }

        /// <summary>
        /// 获取异常信息，如果 是 恶意字符串输入异常，则转换为 业务异常
        /// </summary>
        /// <returns></returns>
        public static ServerLastError GetLastError()
        {
            ServerLastError lastError = null;

            Exception ex = HttpContext.Current.Server.GetLastError();
            if (ex != null)
            {
                lastError = new ServerLastError();

                Exception baseException = ex.GetBaseException();

                lastError.Exception = baseException is System.Web.HttpRequestValidationException ?
                                        new BusinessException("无效的输入，你刚刚提交的一些信息，可能导致安全问题") : baseException;

                lastError.RequestUri = HttpContext.Current.Request.Url.AbsoluteUri;
                lastError.RefererUri = HttpContext.Current.Request.UrlReferrer == null ? lastError.RequestUri : HttpContext.Current.Request.UrlReferrer.AbsoluteUri;


                #region Import Error To DB
                string ErrorType = string.Empty;
                if (lastError.Exception is BusinessException)
                    ErrorType = "BusinessException";
                //else if (lastError.Exception is OperationException)
                //    ErrorType = "OperationException";
                //else if (lastError.Exception is AuthorizationException)
                //    ErrorType = "AuthorizationException";
                //else if (lastError.Exception is ServiceException)
                //    ErrorType = "ServiceException";
                else if (lastError.Exception is HttpException)
                    ErrorType = "HttpException";

                else if (lastError.Exception is Exception)
                    ErrorType = "Exception";
                else
                    ErrorType = "UnknowException";

                #endregion
            }

            return lastError;
        }

    }
}
