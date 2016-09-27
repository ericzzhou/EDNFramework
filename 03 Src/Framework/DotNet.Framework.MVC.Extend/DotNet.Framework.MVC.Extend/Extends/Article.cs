using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.MVC.Extend.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class Article
    {
        /// <summary>
        /// 读取文章信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Entity_Content EDNFHelper_Article(this HtmlHelper helper, int ID)
        {
            return Business.Business_Content.GetModel(ID) ?? new Entity_Content();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Entity_Content EDNFHelper_Article(this HtmlHelper helper, int ID, string where)
        {
            return Business.Business_Content.GetModel(ID, where) ?? new Entity_Content();
        }

        /// <summary>
        /// 根据指定列读取可以显示的文章信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_Content EDNFHelper_Article(this HtmlHelper helper, int ID, string[] columns)
        {
            return Business.Business_Content.GetModel(ID, columns) ?? new Entity_Content();
        }

        /// <summary>
        /// 根据指定列读取可以显示的文章信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        ///  <param name="where"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_Content EDNFHelper_Article(this HtmlHelper helper, int ID, string where, string[] columns)
        {
            return Business.Business_Content.GetModel(ID, where, columns) ?? new Entity_Content();
        }

        /// <summary>
        /// 根据条件(可拼order by)读取top 条文章信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IList<Entity_Content> EDNFHelper_Articles(this HtmlHelper helper, int top, string where)
        {
            return Business.Business_Content.GetContents(top, where) ?? new List<Entity_Content>();
        }

        /// <summary>
        /// 根据条件(可拼order by)和指定的字段数组，读取top 条文章信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="columns">要读取的字段数组，以“,”分割</param>
        /// <returns></returns>
        public static IList<Entity_Content> EDNFHelper_Articles(this HtmlHelper helper, int top, string where, string[] columns)
        {
            return Business.Business_Content.GetContents(top, where, columns) ?? new List<Entity_Content>();
        }

        /// <summary>
        /// 分页读取文章
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="query">查询条件，不能带 where 关键词</param>
        /// <returns></returns>
        public static PagingResult<IList<Entity_Content>> EDNFHelper_ArticlePagingResult(this HtmlHelper helper, ViewQueryCondition<string> query)
        {
            return Business.Business_Content.GetPagingResult(query);
        }
    }
}
