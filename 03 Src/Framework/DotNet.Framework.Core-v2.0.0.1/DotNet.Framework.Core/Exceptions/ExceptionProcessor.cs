using DotNet.Framework.Core.Entity.Exceptions;
using DotNet.Framework.Core.Entity.Runtime;
using DotNet.Framework.Core.WebRuntime;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace DotNet.Framework.Core.Exceptions
{
    internal static class ExceptionProcessor
    {
        public static string ExceptionType_System = "ServiceException";
        public static string ExceptionType_Business = "BusinessException";
        public static string ExceptionType_Operation = "OperationException";
        public static string ExceptionType_Authorization = "AuthorizationException";


        public static void ProcessError(Entity.Exceptions.ServerLastError lastError)
        {
            if (BubbleToAspnetRuntime(lastError))
            {
                return;
            }

            try
            {
                if (lastError != null)
                {
                    if (DotNetFrameworkContext.IsAjaxRequest)
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

        private static void OnNormalError(Entity.Exceptions.ServerLastError lastError)
        {
            Exception ex;
            if (lastError != null)
            {
                HttpContext context = HttpContext.Current;

                context.Server.ClearError();
                ex = lastError.Exception;
                string error = string.Empty;
                string errorLogPath = string.Empty;
                if (ex is Exceptions.BusinessException)
                {
                    errorLogPath = context.Server.MapPath("~/Logs/BusinessException");
                    error = ex.Message;
                }
                else if (ex is Exceptions.AuthorizationException)
                {
                    errorLogPath = context.Server.MapPath("~/Logs/AuthorizationException");
                    error = ex.Message;
                }
                else if (ex is Exceptions.OperationException)
                {
                    errorLogPath = context.Server.MapPath("~/Logs/OperationException");
                    error = ex.Message;
                }
                else
                {
                    errorLogPath = context.Server.MapPath("~/Logs/ApplicatoinException");

                    string ErrorHtml = ReadTemplate(context.Server.MapPath("~/bin/Resource/DotNet.Framework.Core/Templates/ErrorPage.html"));
                    ErrorHtml = ErrorHtml.Replace("#Message#", ex.Message);
                    ErrorHtml = ErrorHtml.Replace("#StackTrace#", ex.StackTrace);
                    error = ErrorHtml;
                }
                if (!string.IsNullOrWhiteSpace(errorLogPath))
                {
                    WriteLog(errorLogPath, ex);
                }
                context.Response.Write(error);
                context.Response.End();
            }


        }

        private static void OnAjaxError(Entity.Exceptions.ServerLastError lastError)
        {
            HttpContext context = HttpContext.Current;
            string contentType = DotNetFrameworkContext.AcceptType;
            string contentData = String.Empty;

            try
            {
                ServerErrorInfo errorInfo = ProcessErrorInternal(lastError);

                Entity.Modules.DotNetGlobalErrorEntity result = new Entity.Modules.DotNetGlobalErrorEntity()
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
                        contentData = DotNet.Framework.Utils.Serialization.ObjectXmlSerializer.Serialize<Entity.Modules.DotNetGlobalErrorEntity>(result);
                        //contentData = contentData.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        contentData = contentData.Replace("utf-16", "utf-8");
                        break;
                    case HttpConst.AcceptTypes.Json:
                    default:
                        contentData = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity.Modules.DotNetGlobalErrorEntity>(result);
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
            else if (lastError.Exception is OperationException)
            {
                OperationException exception = lastError.Exception as OperationException;
                //errorInfo.ExceptionType = isDebugEnabled ? exception.GetType().FullName : ExceptionType_Operation;
                errorInfo.ExceptionType = ExceptionType_Operation;
                errorInfo.IsBizException = true;
                errorInfo.ErrorDescription = exception.Message;
                errorInfo.ErrorDetail = isDebugEnabled ? exception.ToString() : String.Empty;

                isProcessed = true;
            }
            else if (lastError.Exception is AuthorizationException)
            {
                AuthorizationException exception = lastError.Exception as AuthorizationException;
                //errorInfo.ExceptionType = isDebugEnabled ? exception.GetType().FullName : ExceptionType_Authorization;
                errorInfo.ExceptionType = ExceptionType_Authorization;
                errorInfo.IsBizException = true;
                errorInfo.ErrorDescription = exception.Message;
                errorInfo.ErrorDetail = isDebugEnabled ? exception.ToString() : String.Empty;

                isProcessed = true;
            }
            else if (lastError.Exception is ServiceException)
            {
                ServiceException serviceException = lastError.Exception as ServiceException;

                //errorInfo.ExceptionType = isDebugEnabled ? serviceException.GetType().FullName : (serviceException.IsBizException ? ExceptionType_Business : ExceptionType_System);
                errorInfo.ExceptionType = (serviceException.IsBizException ? ExceptionType_Business : ExceptionType_System);
                errorInfo.IsBizException = serviceException.IsBizException;
                //errorInfo.ErrorCode = serviceException.ErrorCode;
                errorInfo.ErrorDescription = serviceException.Message;
                errorInfo.ErrorDetail = isDebugEnabled ? serviceException.ErrorDetail : String.Empty;

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
                errorInfo.ErrorDescription = isDebugEnabled ? lastError.Exception.Message : "未知异常，请联系管理员";
                errorInfo.ErrorDetail = isDebugEnabled ? lastError.Exception.ToString() : String.Empty;
            }

            errorInfo.RequestUri = lastError.RequestUri;
            errorInfo.RefererUri = lastError.RefererUri;

            HttpContext.Current.Server.ClearError();

            return errorInfo;
        }

        private static bool BubbleToAspnetRuntime(Entity.Exceptions.ServerLastError lastError)
        {
            if (lastError == null)
            {
                return false;
            }

            bool bubble = false;
            if (!DotNetFrameworkContext.IsAjaxRequest)
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
                if (DotNetFrameworkContext.AjaxRequestType == "aspnetAjax")
                {
                    bubble = true;
                }
            }

            return bubble;
        }

        private static string ReadTemplate(string errorPageHtml)
        {
            string str = string.Empty;
            using (FileStream fs = new FileStream(errorPageHtml, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    str = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                }
            }
            return str;
        }

        private static void WriteLog(string exceptionDirectory, System.Exception ex)
        {
            if (CreateDirectory(exceptionDirectory))
            {
                string fileName = exceptionDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                        {
                            StringBuilder sbr = new StringBuilder();
                            sbr.AppendFormat("{0}-------------------------------------------", DateTime.Now.ToString());
                            sbr.AppendLine();
                            sbr.AppendLine(ex.Message);
                            sbr.AppendLine(ex.StackTrace);
                            if (ex.InnerException != null)
                            {
                                sbr.AppendLine(ex.InnerException.Message);
                                sbr.AppendLine(ex.InnerException.StackTrace);
                            }
                            sbr.AppendLine();
                            sbr.AppendLine();
                            sbr.AppendLine();
                            sw.Write(sbr.ToString());
                            sw.Flush();
                            sw.Close();
                            fs.Close();
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private static bool CreateDirectory(string logPath)
        {
            try
            {
                if (!Directory.Exists(logPath))
                {
                    //创建文件夹
                    Directory.CreateDirectory(logPath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
