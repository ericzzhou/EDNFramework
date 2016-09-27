using EFramework.Core;
using EFramework.HttpModule.Entities;
using EFramework.HttpModule.WebRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EFramework.HttpModule.Processor
{
    internal static class ExceptionProcessor
    {
        public static string ExceptionType_System = "ServiceException";
        public static string ExceptionType_Business = "BusinessException";
        public static string ExceptionType_Operation = "OperationException";
        public static string ExceptionType_Authorization = "AuthorizationException";


        public static void ProcessError(ServerLastError lastError)
        {
            if (BubbleToAspnetRuntime(lastError))
            {
                return;
            }

            try
            {
                if (lastError != null)
                {
                    if (EFrameworkContext.IsAjaxRequest)
                    {
                        OnAjaxError(lastError);
                    }
                    else
                    {
                        OnNormalError(lastError);
                    }
                }
            }
            catch (Exception ex)
            {
                if (lastError != null && lastError.Exception != null)
                {
                    throw lastError.Exception;
                }
                else
                {
                    throw;
                }
            }
        }

        private static void OnNormalError(ServerLastError lastError)
        {
            Exception ex;
            if (lastError != null)
            {
                HttpContext context = HttpContext.Current;

                context.Server.ClearError();
                ex = lastError.Exception;
                string error = string.Empty;
                string errorLogPath = string.Empty;
                if (ex is BusinessException)
                {
                    //errorLogPath = context.Server.MapPath("~/Logs/BusinessException");
                    error = ex.Message;
                }
                else
                {
                    //errorLogPath = context.Server.MapPath("~/Logs/ApplicatoinException");

                    //string ErrorHtml = ReadTemplate(context.Server.MapPath("~/bin/Resource/DotNet.Framework.Core/Templates/ErrorPage.html"));
                    //ErrorHtml = ErrorHtml.Replace("#Message#", ex.Message);
                    //ErrorHtml = ErrorHtml.Replace("#StackTrace#", ex.StackTrace);
                    //error = ErrorHtml;

                    //todo 对于常规异常 应该怎么处理？？
                }
                //if (!string.IsNullOrWhiteSpace(errorLogPath))
                //{
                //    WriteLog(errorLogPath, ex);
                //}
                context.Response.Write(error);
                context.Response.End();
            }


        }

        private static void OnAjaxError(ServerLastError lastError)
        {
            HttpContext context = HttpContext.Current;
            string contentType = EFrameworkContext.AcceptType;
            string contentData = String.Empty;

            try
            {
                ServerErrorInfo errorInfo = ProcessErrorInternal(lastError);

                GlobalErrorEntity result = new GlobalErrorEntity()
                {
                    Type = errorInfo.ExceptionType,
                    IsBizException = errorInfo.IsBizException,
                    Message = errorInfo.ErrorDescription,
                    Detail = errorInfo.ErrorDetail
                    //Detail = ""
                };

                switch (contentType.ToLower().Trim())
                {
                    case HttpConst.AcceptTypes.Xml:
                        contentData = Helper.Serialization.XmlSerializer.Serialize<GlobalErrorEntity>(result);
                        //contentData = contentData.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        contentData = contentData.Replace("utf-16", "utf-8");
                        break;
                    case HttpConst.AcceptTypes.Json:
                    default:
                        contentData = Helper.Serialization.JsonSerializer.Serialize<GlobalErrorEntity>(result);
                        contentData = "{\"error\":" + contentData + "}";
                        break;
                }
            }
            catch
            {
                contentData = String.Format("{{ \"error\":{{ \"Type\":{0}, \"Message\":{1} }}, \"Detail\":{2} }}",
                    "UnknowError",
                    "未知异常，请联系管理员",
                    "如果您是管理员，请查阅系统日志");

                throw;
            }
            finally
            {
                //Ensure ajax response, otherwise the client will deadlock until timeout.

                context.Response.Charset = "utf-8";
                context.Response.ContentEncoding = context.Request.ContentEncoding;
                context.Response.Cache.SetNoServerCaching();
                context.Response.Expires = 0;
                context.Response.StatusCode = 500;
                context.Response.ClearContent();
                context.Response.ContentType = contentType;
                context.Response.Write(contentData);
                context.Response.End();
            }
        }

        private static ServerErrorInfo ProcessErrorInternal(ServerLastError lastError)
        {
            ServerErrorInfo errorInfo = new ServerErrorInfo();
            bool isDebugEnabled = HttpContext.Current.IsDebuggingEnabled;
            bool isProcessed = false;
            if (lastError.Exception is BusinessException)
            {
                BusinessException bizException = lastError.Exception as BusinessException;

                //errorInfo.ExceptionType = isDebugEnabled ? bizException.GetType().FullName : ExceptionType_Business;
                errorInfo.ExceptionType = ExceptionType_Business;
                errorInfo.IsBizException = true;
                errorInfo.ErrorDescription = bizException.Message;
                errorInfo.ErrorDetail = isDebugEnabled ? bizException.ToString() : String.Empty;

                isProcessed = true;
            }
            
            else if (lastError.Exception is HttpException)
            {
                HttpException httpException = lastError.Exception as HttpException;
                int statusCode = httpException.GetHttpCode();

                switch (statusCode)
                {
                    case 403:
                    case 405:
                        //errorInfo.ExceptionType = isDebugEnabled ? httpException.GetType().FullName : ExceptionType_System;
                        errorInfo.ExceptionType = ExceptionType_System;
                        errorInfo.IsBizException = false;
                        //errorInfo.ErrorCode = statusCode.ToString();
                        errorInfo.ErrorDescription = "您无权访问该权限或者页面，请联系管理员。";
                        errorInfo.ErrorDetail = isDebugEnabled ? httpException.ToString() : String.Empty;

                        isProcessed = true;
                        break;
                    default:
                        isProcessed = false;
                        break;
                }
            }

            if (false == isProcessed)
            {
                Exception exception = lastError.Exception;

                //errorInfo.ExceptionType = isDebugEnabled ? exception.GetType().FullName : ExceptionType_System;
                errorInfo.ExceptionType = ExceptionType_System;
                errorInfo.IsBizException = false;
                //errorInfo.ErrorDescription = isDebugEnabled ? lastError.Exception.Message : "未知异常，请联系管理员";
                errorInfo.ErrorDescription =  lastError.Exception.Message ;
                errorInfo.ErrorDetail = isDebugEnabled ? lastError.Exception.ToString() : String.Empty;
            }

            errorInfo.RequestUri = lastError.RequestUri;
            errorInfo.RefererUri = lastError.RefererUri;

            HttpContext.Current.Server.ClearError();

            return errorInfo;
        }

        private static bool BubbleToAspnetRuntime(ServerLastError lastError)
        {
            if (lastError == null)
            {
                return false;
            }

            bool bubble = false;
            if (!EFrameworkContext.IsAjaxRequest)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    bubble = true;
                }
                else
                {
                    HttpException httpEx = lastError.Exception as HttpException;
                    if (httpEx != null)
                    {
                        int statusCode = httpEx.GetHttpCode();
                        if (statusCode == 403 || statusCode == 404 || statusCode == 405)
                        {
                            bubble = true;
                        }
                    }
                }
            }
            else
            {
                if (EFrameworkContext.AjaxRequestType == "aspnetAjax")
                {
                    bubble = true;
                }
            }

            return bubble;
        }

        //private static string ReadTemplate(string errorPageHtml)
        //{
        //    string str = string.Empty;
        //    using (FileStream fs = new FileStream(errorPageHtml, FileMode.Open, FileAccess.Read))
        //    {
        //        using (StreamReader sr = new StreamReader(fs, Encoding.Default))
        //        {
        //            str = sr.ReadToEnd();
        //            sr.Close();
        //            fs.Close();
        //        }
        //    }
        //    return str;
        //}



    }
}
