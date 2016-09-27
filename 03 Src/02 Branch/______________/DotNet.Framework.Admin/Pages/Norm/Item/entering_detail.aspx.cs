using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.Core.Exceptions;
using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Pages.Norm.Item
{
    public partial class entering_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request["ajax"];

            if (!string.IsNullOrWhiteSpace(ajax))
            {
                switch (ajax.ToLower())
                {
                    case "addnormvalue":
                        AddNormValue();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNormValue()
        {
            var OccurrenceTime = Request["OccurrenceTime"];
            if (OccurrenceTime.IsNull())
            {
                 throw new BusinessException("请选择指标发生时间");
            }
            List<Entity_Hospital_NormValue> entities =
                  DotNet.Framework.Utils.Serialization.ObjectJsonSerializer
                  .Json2EntityFromAjaxRequest<List<Entity_Hospital_NormValue>>(Request);

            if (entities != null)
            {
                int result = Business_Hospital_NormValue.Create(entities, BusEntity_LoginUser.Sys_LoginUser.UserID, OccurrenceTime);
                if (result <= 0)
                {
                    throw new BusinessException("指标数据录入失败，请重试");
                }
            }
            else
                throw new BusinessException("指标数据解析失败，请刷新页面重试");

            Response.Write("{}");
            Response.End();
        }
    }
}