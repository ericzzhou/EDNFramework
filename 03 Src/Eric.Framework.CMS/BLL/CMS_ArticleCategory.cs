using Eric.Framework.CMS.DALFactory;
using Eric.Framework.CMS.IDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.CMS.BLL
{
    public class CMS_ArticleCategory
    {
        private readonly ICMS_ArticleCategory dal = DataAccess.CreateCMS_ArticleCategory();
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        public bool Exists(string Name)
        {
            return dal.Exists(Name);
        }

        public int Add(Model.CMS_ArticleCategory model)
        {
            return dal.Add(model);
        }

        public bool Update(Model.CMS_ArticleCategory model)
        {
            return dal.Update(model);
        }

        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        public Model.CMS_ArticleCategory GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eric.Framework.CMS.Model.CMS_ArticleCategory GetModelByCache(int ID)
        {

            string CacheKey = "CMS_ArticleCategoryModel-" + ID;
            object objModel = DotNet.Framework.Utils.Web.WebDataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = DotNet.Framework.Utils.Web.ConfigHelper.GetConfigInt("ModelCache");
                        DotNet.Framework.Utils.Web.WebDataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eric.Framework.CMS.Model.CMS_ArticleCategory)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eric.Framework.CMS.Model.CMS_ArticleCategory> DataTableToList(DataTable dt)
        {
            List<Eric.Framework.CMS.Model.CMS_ArticleCategory> modelList = new List<Eric.Framework.CMS.Model.CMS_ArticleCategory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eric.Framework.CMS.Model.CMS_ArticleCategory model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public IList<Model.CMS_ArticleCategory> GetList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public IList<Model.CMS_ArticleCategory> GetList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public IList<Model.CMS_ArticleCategory> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
