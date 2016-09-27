using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.Hospital;
using System.Collections.Generic;
using DotNet.Framework.Admin.Business.Hospital;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;
namespace DotNet.Framework.Admin.Pages.Norm.Item
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "getpagerdata":
                    GetPagerData();
                    break;

                case "add":
                    AddNormItem();
                    break;
                case "deletemodel":
                    DeleteNormItem();
                    break;
                case "stopmodel":
                    StopModel();
                    break;
                case "startmodel":
                    StartModel();
                    break;
                case "edit":
                    EditNormItem();
                    break;
                case "getmodel":
                    GetModel();
                    break;

            }
        }

        private void GetModel()
        {
            var id = Request["ID"].ToInt();
            if (id > 0)
            {
                Entity_Hospital_NormItem model = Business_Hospital_NormItem.GetModel(id);
                var json = ObjectJsonSerializer.Serialize<Entity_Hospital_NormItem>(model);
                Response.Write(json);
            }
            else
            {
                throw new Exception("指标选择错误，请刷新重试");
            }
            Response.End();
        }



        private void StartModel()
        {
            var id = Request["ID"].ToInt();
            if (id > 0)
            {
                if (!Business_Hospital_NormItem.Stop(id, "N"))
                {
                    throw new Exception("指标启用错误，请刷新重试");
                }
                else
                {
                    Response.Write("{}");
                }
            }
            else
            {
                throw new Exception("指标选择错误，请刷新重试");
            }
            Response.End();
        }

        private void StopModel()
        {
            var id = Request["ID"].ToInt();
            if (id > 0)
            {
                if (!Business_Hospital_NormItem.Stop(id, "Y"))
                {
                    throw new Exception("指标停用错误，请刷新重试");
                }
                else
                {
                    Response.Write("{}");
                }
            }
            else
            {
                throw new Exception("指标选择错误，请刷新重试");
            }
            Response.End();
        }

        private void DeleteNormItem()
        {
            var id = Request["ID"].ToInt();
            if (id > 0)
            {
                if (!Business_Hospital_NormItem.Delete(id))
                {
                    throw new Exception("指标删除错误，请刷新重试");
                }
                else
                {
                    Response.Write("{}");
                }
            }
            else
            {
                throw new Exception("指标选择错误，请刷新重试");
            }
            Response.End();
        }
        private void EditNormItem()
        {
            Entity_Hospital_NormItem entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Hospital_NormItem>(Request);
            if (entity.ItemStatus == "True")
            {
                entity.ItemStatus = "Y";
                entity.ItemStopTime = DateTime.Now.ToString();
            }
            else
            {
                entity.ItemStatus = "N";
            }
            if (string.IsNullOrWhiteSpace(entity.ItremName))
            {
                throw new BusinessException("指标名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.ItemCode))
            {
                throw new BusinessException("指标简码不能为空");
            }
            if (entity.ItemCategory <= 0)
            {
                throw new BusinessException("请选择指标分类");
            }

            if (!Business_Hospital_NormItem.Edit(entity))
            {
                throw new BusinessException("编辑指标目录失败，请重试。");
            }
            else
            {
                Response.Write("{}");
            }
            Response.End();
        }
        private void AddNormItem()
        {
            Entity_Hospital_NormItem entity = ObjectJsonSerializer.Json2EntityFromAjaxRequest<Entity_Hospital_NormItem>(Request);
            if (entity.ItemStatus == "True")
            {
                entity.ItemStatus = "Y";
                entity.ItemStopTime = DateTime.Now.ToString();
            }
            else
            {
                entity.ItemStatus = "N";
            }
            if (string.IsNullOrWhiteSpace(entity.ItremName))
            {
                throw new BusinessException("指标名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(entity.ItemCode))
            {
                throw new BusinessException("指标简码不能为空");
            }
            if (entity.ItemCategory <= 0)
            {
                throw new BusinessException("请选择指标分类");
            }

            if (!Business_Hospital_NormItem.Add(entity))
            {
                throw new BusinessException("新增指标目录失败，请重试。");
            }
            else
            {
                Response.Write("{}");
            }
            Response.End();
        }

        private void GetPagerData()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();

            string orderField = Request["orderField"];
            string dir = Request["sortDir"];

            int categoryid = Request["categoryid"].ToInt();
            if (categoryid <= 0)
            {
                Response.Write("{\"totalRecords\": 0, \"curPage\": " + pageindex + ",\"data\":{} }");
                Response.End();
                return;
            }
            int totolCount = 0;
            IList<Entity_Hospital_NormItem> pageResult = Business_Hospital_NormItem.GetListByPager(categoryid, pageindex, pagesize, orderField, dir, out totolCount);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<IList<Entity_Hospital_NormItem>>(pageResult);

            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();

        }
    }
}