using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DotNet.Framework.MVC.Extend.Extends
{
    public static class Product
    {
        /// <summary>
        /// 读取产品信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Entity_Product EDNFHelper_Product(this HtmlHelper helper, int ID)
        {
            return Business.Business_Product.GetModel(ID) ?? new Entity_Product();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static Entity_Product EDNFHelper_Product(this HtmlHelper helper, int ID, string where)
        {
            return Business.Business_Product.GetModel(ID, where) ?? new Entity_Product();
        }

        /// <summary>
        /// 根据指定列读取可以显示的产品信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_Product EDNFHelper_Product(this HtmlHelper helper, int ID, string[] columns)
        {
            return Business.Business_Product.GetModel(ID, columns) ?? new Entity_Product();
        }

        /// <summary>
        /// 根据指定列读取可以显示的产品信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ID"></param>
        ///  <param name="where"></param>
        /// <param name="columns">列名，以“,”分割</param>
        /// <returns></returns>
        public static Entity_Product EDNFHelper_Product(this HtmlHelper helper, int ID, string where, string[] columns)
        {
            return Business.Business_Product.GetModel(ID, where, columns) ?? new Entity_Product();
        }

        /// <summary>
        /// 根据条件(可拼order by)读取top 条产品信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IList<Entity_Product> EDNFHelper_Products(this HtmlHelper helper, int top, string where)
        {
            return Business.Business_Product.GetProducts(top, where) ?? new List<Entity_Product>();
        }

        /// <summary>
        /// 根据条件(可拼order by)和指定的字段数组，读取top 条产品信息，top =0 则取全部
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="columns">要读取的字段数组，以“,”分割</param>
        /// <returns></returns>
        public static IList<Entity_Product> EDNFHelper_Products(this HtmlHelper helper, int top, string where, string[] columns)
        {
            return Business.Business_Product.GetProducts(top, where, columns) ?? new List<Entity_Product>();
        }

        /// <summary>
        /// 分页读取产品
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="query">查询条件，不能带 where 关键词</param>
        /// <returns></returns>
        public static PagingResult<IList<Entity_Product>> EDNFHelper_ProductPagingResult(this HtmlHelper helper, ViewQueryCondition<string> query)
        {
            return Business.Business_Product.GetPagingResult(query);
        }
    }
}
