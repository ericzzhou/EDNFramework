﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.HttpModule.WebRuntime
{
    class Browser
    {
        private System.Web.HttpContext m_httpContext;

        public Browser(System.Web.HttpContext m_httpContext)
        {
            // TODO: Complete member initialization
            this.m_httpContext = m_httpContext;
        }
    }
}
