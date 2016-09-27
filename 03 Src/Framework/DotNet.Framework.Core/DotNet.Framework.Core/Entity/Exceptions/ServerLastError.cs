using DotNet.Framework.Core.Exceptions;
using System;
using System.Web;

namespace DotNet.Framework.Core.Entity.Exceptions
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
                else if (lastError.Exception is ServiceException)
                    ErrorType = "ServiceException";
                else if (lastError.Exception is HttpException)
                    ErrorType = "HttpException";
                else
                    ErrorType = "UnknowException";

                Entity_SysErrorLog log = new Entity_SysErrorLog();
                log.Domain = "";
                log.ErrorType = ErrorType;
                log.Loginfo = lastError.Exception.Message;
                log.OPTime = DateTime.Now;
                log.StackTrace = lastError.Exception.StackTrace;
                log.Url = lastError.RequestUri;

                Entity_SysErrorLog.InsertLog(log); 
                #endregion
            }

            return lastError;
        }

    }
}
