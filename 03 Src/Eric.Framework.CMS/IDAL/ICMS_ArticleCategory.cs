using System.Data;

namespace Eric.Framework.CMS.IDAL
{
    public interface ICMS_ArticleCategory
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string Name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Eric.Framework.CMS.Model.CMS_ArticleCategory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Eric.Framework.CMS.Model.CMS_ArticleCategory model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Eric.Framework.CMS.Model.CMS_ArticleCategory GetModel(int ID);
        Eric.Framework.CMS.Model.CMS_ArticleCategory DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
