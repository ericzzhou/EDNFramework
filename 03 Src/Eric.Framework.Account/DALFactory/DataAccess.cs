using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eric.Framework.Account.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了
    /// <add key="DAL_Account" value="Eric.Framework.Account.SQLServerDAL" />
    /// <add key="DLL_Account" value="Eric.Framework.Account" />
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DLL_Account"];
        private static readonly string DAL = ConfigurationManager.AppSettings["DAL_Account"];
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
                throw;
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
                    throw;
                }
            }
            return objType;
        }
        #endregion


        /// <summary>
        /// 创建Account_Permission数据层接口。
        /// </summary>
        public static Eric.Framework.Account.IDAL.IAccount_Permission CreateAccount_Permission()
        {

            string ClassNamespace = DAL + ".Account_Permission";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.Account.IDAL.IAccount_Permission)objType;
        }

        /// <summary>
        /// 创建Account_Permission_Action数据层接口。
        /// </summary>
        public static Eric.Framework.Account.IDAL.IAccount_Permission_Action CreateAccount_Permission_Action()
        {

            string ClassNamespace = DAL + ".Account_Permission_Action";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.Account.IDAL.IAccount_Permission_Action)objType;
        }

        /// <summary>
        /// 创建Account_Role数据层接口。
        /// </summary>
        public static Eric.Framework.Account.IDAL.IAccount_Role CreateAccount_Role()
        {

            string ClassNamespace = DAL + ".Account_Role";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.Account.IDAL.IAccount_Role)objType;
        }

        /// <summary>
        /// 创建Account_User数据层接口。
        /// </summary>
        public static Eric.Framework.Account.IDAL.IAccount_User CreateAccount_User()
        {

            string ClassNamespace = DAL + ".Account_User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Eric.Framework.Account.IDAL.IAccount_User)objType;
        }


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

        ///// <summary>
        ///// 创建Account_RolePermission数据层接口。
        ///// </summary>
        //public static Eric.Framework.Account.IDAL.IAccount_RolePermission CreateAccount_RolePermission()
        //{

        //    string ClassNamespace = AssemblyPath + ".Account_RolePermission";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (Eric.Framework.Account.IDAL.IAccount_RolePermission)objType;
        //}

        ///// <summary>
        ///// 创建Account_UserRole数据层接口。
        ///// </summary>
        //public static Eric.Framework.Account.IDAL.IAccount_UserRole CreateAccount_UserRole()
        //{

        //    string ClassNamespace = AssemblyPath + ".Account_UserRole";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (Eric.Framework.Account.IDAL.IAccount_UserRole)objType;
        //}
    }
}
