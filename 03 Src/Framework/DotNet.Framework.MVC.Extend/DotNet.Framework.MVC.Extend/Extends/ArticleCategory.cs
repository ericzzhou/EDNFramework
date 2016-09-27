using DotNet.Framework.MVC.Extend.Business;
using DotNet.Framework.MVC.Extend.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class ArticleCategory
    {
        public static Entity_ContentCategory EDNFHelper_ArticleCategory(this HtmlHelper helper, int ID)
        {
            return Business_ContentCategory.GetModel(ID);
        }

        public static Entity_ContentCategory EDNFHelper_ArticleCategory(this HtmlHelper helper, int ID, string where)
        {
            return Business.Business_ContentCategory.GetModel(ID, where) ?? new Entity_ContentCategory();
        }

        /// <summary>
        /// 根据指定列读取可以显示的文章类别信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_ContentCategory EDNFHelper_ArticleCategory(this HtmlHelper helper, int ID, string[] columns)
        {
            return Business.Business_ContentCategory.GetModel(ID, columns) ?? new Entity_ContentCategory();
        }

        /// <summary>
        /// 根据指定列读取可以显示的文章类别信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        ///  <param name="where"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_ContentCategory EDNFHelper_ArticleCategory(this HtmlHelper helper, int ID, string where, string[] columns)
        {
            return Business.Business_ContentCategory.GetModel(ID, where, columns) ?? new Entity_ContentCategory();
        }

        /// <summary>
        /// 根据条件(可拼order by)读取top 条文章类别信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IList<Entity_ContentCategory> EDNFHelper_ArticleCategories(this HtmlHelper helper, int top, string where)
        {
            return Business.Business_ContentCategory.GetContentCategories(top, where) ?? new List<Entity_ContentCategory>();
        }

        /// <summary>
        /// 根据条件(可拼order by)和指定的字段数组，读取top 条文章类别信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="columns">要读取的字段数组，以“,”分割</param>
        /// <returns></returns>
        public static IList<Entity_ContentCategory> EDNFHelper_ArticleCategories(this HtmlHelper helper, int top, string where, string[] columns)
        {
            return Business.Business_ContentCategory.GetContentCategories(top, where, columns) ?? new List<Entity_ContentCategory>();
        }
    }
}
