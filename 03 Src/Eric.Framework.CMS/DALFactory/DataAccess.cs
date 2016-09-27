using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eric.Framework.CMS.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了
    /// <add key="DAL_CMS" value="Eric.Framework.CMS.SQLServerDAL" />
    /// <add key="DLL_CMS" value="Eric.Framework.CMS" />
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL_CMS"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DotNet.Framework.Utils.Web.WebDataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DotNet.Framework.Utils.Web.WebDataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        /// <summary>
        /// 创建CMS_Article数据层接口。
        /// </summary>
        public static Eric.Framework.CMS.IDAL.ICMS_Article CreateCMS_Article()
        {

            string ClassNamespace = AssemblyPath + ".CMS_Article";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.CMS.IDAL.ICMS_Article)objType;
        }


        /// <summary>
        /// 创建CMS_ArticleCategory数据层接口。
        /// </summary>
        public static Eric.Framework.CMS.IDAL.ICMS_ArticleCategory CreateCMS_ArticleCategory()
        {

            string ClassNamespace = AssemblyPath + ".CMS_ArticleCategory";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.CMS.IDAL.ICMS_ArticleCategory)objType;
        }


        /// <summary>
        /// 创建CMS_ArticleComment数据层接口。
        /// </summary>
        public static Eric.Framework.CMS.IDAL.ICMS_ArticleComment CreateCMS_ArticleComment()
        {

            string ClassNamespace = AssemblyPath + ".CMS_ArticleComment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.CMS.IDAL.ICMS_ArticleComment)objType;
        }

    }
}
