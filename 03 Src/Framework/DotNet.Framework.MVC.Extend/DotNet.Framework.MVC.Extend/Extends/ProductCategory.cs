using DotNet.Framework.MVC.Extend.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class ProductCategory
    {
        /// <summary>
        /// 读取产品类别信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Entity_ProductCategory EDNFHelper_ProductCategory(this HtmlHelper helper, int ID)
        {
            return Business.Business_ProductCategory.GetModel(ID) ?? new Entity_ProductCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Entity_ProductCategory EDNFHelper_ProductCategory(this HtmlHelper helper, int ID, string where)
        {
            return Business.Business_ProductCategory.GetModel(ID, where) ?? new Entity_ProductCategory();
        }

        /// <summary>
        /// 根据指定列读取可以显示的产品类别信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_ProductCategory EDNFHelper_ProductCategory(this HtmlHelper helper, int ID, string[] columns)
        {
            return Business.Business_ProductCategory.GetModel(ID, columns) ?? new Entity_ProductCategory();
        }

        /// <summary>
        /// 根据指定列读取可以显示的产品类别信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        ///  <param name="where"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_ProductCategory EDNFHelper_ProductCategory(this HtmlHelper helper, int ID, string where, string[] columns)
        {
            return Business.Business_ProductCategory.GetModel(ID, where, columns) ?? new Entity_ProductCategory();
        }

        /// <summary>
        /// 根据条件(可拼order by)读取top 条产品类别信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IList<Entity_ProductCategory> EDNFHelper_ProductCategories(this HtmlHelper helper, int top, string where)
        {
            return Business.Business_ProductCategory.GetProductCategories(top, where) ?? new List<Entity_ProductCategory>();
        }

        /// <summary>
        /// 根据条件(可拼order by)和指定的字段数组，读取top 条产品类别信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="columns">要读取的字段数组，以“,”分割</param>
        /// <returns></returns>
        public static IList<Entity_ProductCategory> EDNFHelper_ProductCategories(this HtmlHelper helper, int top, string where, string[] columns)
        {
            return Business.Business_ProductCategory.GetProductCategories(top, where, columns) ?? new List<Entity_ProductCategory>();
        }
    }
}
