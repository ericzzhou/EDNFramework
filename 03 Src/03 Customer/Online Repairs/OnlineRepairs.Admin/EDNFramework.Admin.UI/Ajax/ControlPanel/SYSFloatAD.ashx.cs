using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Framework.Admin.UI.Ajax.ControlPanel
{
    /// <summary>
    /// SYSFloatAD 的摘要说明
    /// </summary>
    public class SYSFloatAD : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "save":
                    SaveAd(context);
                    break;
                case "loadjumpad":
                    LoadJumpAD(context);
                    break;
                case "savejumpad":
                    SaveJumpAD(context);
                    break;
               
            }
        }

        private void LoadJumpAD(HttpContext context)
        {
            Entity_SingleJumpAD model = Business_SingleJumpAD.GetNormal() ?? new Entity_SingleJumpAD()
            {
                Content = "",
                ContentType = "font",
                Enable = true,
                Height = 10,
                Name = "",
                Width = 10
            };

            context.Response.Write(ObjectJsonSerializer.Serialize<Entity_SingleJumpAD>(model));
        }

        private void SaveJumpAD(HttpContext context)
        {
            Entity_SingleJumpAD entity =
                 DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                 .Json2EntityFromAjaxRequest<Entity_SingleJumpAD>(context.Request);

            if (Business_SingleJumpAD.Save(entity) <= 0)
            {
                throw new BusinessException("保存失败，请重试");
            }
        }

        private void SaveAd(HttpContext context)
        {
            Entity_FloatAD entity =
                DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_FloatAD>(context.Request);

            if (Business_FloatAD.Save(entity) <= 0)
            {
                throw new BusinessException("保存失败，请重试");
            }
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