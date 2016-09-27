using Eric.Framework.CMS.DALFactory;
using Eric.Framework.CMS.IDAL;
using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.CMS.BLL
{
    public class CMS_ArticleComment
    {
        private readonly ICMS_ArticleComment dal = DataAccess.CreateCMS_ArticleComment();
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        public int Add(Model.CMS_ArticleComment model)
        {
            return dal.Add(model);
        }

        public bool Update(Model.CMS_ArticleComment model)
        {
            return dal.Update(model);
        }

        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return DeleteList(IDlist);
        }

        public Model.CMS_ArticleComment GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eric.Framework.CMS.Model.CMS_ArticleComment> DataTableToList(DataTable dt)
        {
            List<Eric.Framework.CMS.Model.CMS_ArticleComment> modelList = new List<Eric.Framework.CMS.Model.CMS_ArticleComment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eric.Framework.CMS.Model.CMS_ArticleComment model;
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

        public List<Model.CMS_ArticleComment> GetList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Model.CMS_ArticleComment> GetList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public List<Model.CMS_ArticleComment> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
