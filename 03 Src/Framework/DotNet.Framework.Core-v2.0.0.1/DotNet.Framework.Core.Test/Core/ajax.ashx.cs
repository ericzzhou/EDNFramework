using DotNet.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Core.Test.Core
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request["ajax"];
            switch (ajax)
            {
                case "Success":
                    Success(context);
                    break;
                case "Exception":
                    Exception(context);
                    break;
                case "BusinessException":
                    BusinessException(context);
                    break;
                case "AlertException":
                    AlertException(context);
                    break;
                case "OperationException":
                    OperationException(context);
                    break;
                case "AuthorizationException":
                    AuthorizationException(context);
                    break;
                default:
                    Default(context);
                    break;
            }
        }

        private void AuthorizationException(HttpContext context)
        {
            throw new AuthorizationException("授权异常 AuthorizationException");
        }

        private void OperationException(HttpContext context)
        {
            throw new OperationException("操作异常 OperationException");
        }

        private void Default(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void AlertException(HttpContext context)
        {
            throw new Exception("AlertException功能开发中...");
        }

        private void BusinessException(HttpContext context)
        {
            throw new BusinessException("业务异常BusinessException");
        }

        private void Exception(HttpContext context)
        {
            throw new Exception("异常Exception");
        }

        private void Success(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}