using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class FLink
    {
        /// <summary>
        /// 读取FLinks信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Entity_FLink EDNFHelper_FLink(this HtmlHelper helper, int ID)
        {
            return Business.Business_FLink.GetModel(ID) ?? new Entity_FLink();
        }

        /// <summary>
        /// FLinks
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Entity_FLink EDNFHelper_FLink(this HtmlHelper helper, int ID, string where)
        {
            return Business.Business_FLink.GetModel(ID, where) ?? new Entity_FLink();
        }

        /// <summary>
        /// 根据指定列读取可以显示的FLinks
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_FLink EDNFHelper_FLink(this HtmlHelper helper, int ID, string[] columns)
        {
            return Business.Business_FLink.GetModel(ID, columns) ?? new Entity_FLink();
        }

        /// <summary>
        /// 根据指定列读取可以显示的FLinks
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        ///  <param name="where"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_FLink EDNFHelper_FLink(this HtmlHelper helper, int ID, string where, string[] columns)
        {
            return Business.Business_FLink.GetModel(ID, where, columns) ?? new Entity_FLink();
        }

        /// <summary>
        /// 根据条件(可拼order by)读取top 条FLinks，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IList<Entity_FLink> EDNFHelper_FLinks(this HtmlHelper helper, int top, string where)
        {
            return Business.Business_FLink.GetList(top, where) ?? new List<Entity_FLink>();
        }

        /// <summary>
        /// 根据条件(可拼order by)和指定的字段数组，读取top 条FLinks，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="columns">要读取的字段数组，以“,”分割</param>
        /// <returns></returns>
        public static IList<Entity_FLink> EDNFHelper_FLinks(this HtmlHelper helper, int top, string where, string[] columns)
        {
            return Business.Business_FLink.GetList(top, where, columns) ?? new List<Entity_FLink>();
        }
    }
}
