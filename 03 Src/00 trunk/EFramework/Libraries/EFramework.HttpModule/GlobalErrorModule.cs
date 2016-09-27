using EFramework.HttpModule.Entities;
using EFramework.HttpModule.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EFramework.HttpModule
{
    public class GlobalErrorModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.Error += context_Error;
        }

        void context_Error(object sender, EventArgs e)
        {
            ExceptionProcessor.ProcessError(ServerLastError.GetLastError());
        }
    }
}
