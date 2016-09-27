
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Eric.Framework.Account.SQLServerDAL
{
    public partial class Account_Permission : IDAL.IAccount_Permission
    {
        public int Create(Model.Account_Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account_Permission(");
            strSql.Append("Code,Name,Description,Url)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Name,@Description,@Url)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Url", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Url;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool Delete(int PermissionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_Permission ");
            strSql.Append(" where PermissionID=@PermissionID");
            SqlParameter[] parameters = {
					new SqlParameter("@PermissionID", SqlDbType.Int,4)
			};
            parameters[0].Value = PermissionID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Code, int PermissionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_Permission ");
            strSql.Append(" where Code=@Code and PermissionID=@PermissionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20),
					new SqlParameter("@PermissionID", SqlDbType.Int,4)			};
            parameters[0].Value = Code;
            parameters[1].Value = PermissionID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PermissionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_Permission ");
            strSql.Append(" where PermissionID in (" + PermissionIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Model.Account_Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Account_Permission set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Description=@Description,");
            strSql.Append("Url=@Url");
            strSql.Append(" where PermissionID=@PermissionID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Url", SqlDbType.NVarChar,500),
					new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.PermissionID;
            parameters[4].Value = model.Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Code, int PermissionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Account_Permission");
            strSql.Append(" where Code=@Code and PermissionID=@PermissionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20),
					new SqlParameter("@PermissionID", SqlDbType.Int,4)			};
            parameters[0].Value = Code;
            parameters[1].Value = PermissionID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public Model.Account_Permission DataRowToModel(System.Data.DataRow row)
        {
            Model.Account_Permission model = new Model.Account_Permission();
            if (row != null)
            {
                if (row["PermissionID"] != null && row["PermissionID"].ToString() != "")
                {
                    model.PermissionID = int.Parse(row["PermissionID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
            }
            return model;
        }

        public Model.Account_Permission GetPermission(int PermissionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PermissionID,Code,Name,Description,Url from Account_Permission ");
            strSql.Append(" where PermissionID=@PermissionID");
            SqlParameter[] parameters = {
					new SqlParameter("@PermissionID", SqlDbType.Int,4)
			};
            parameters[0].Value = PermissionID;

            Model.Account_Permission model = new Model.Account_Permission();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataSet GetPermissionList()
        {
            return GetPermissionList(0, "", "");
        }

        public System.Data.DataSet GetPermissionList(int top)
        {
            return GetPermissionList(top, "", "");
        }

        public System.Data.DataSet GetPermissionList(string strWhere)
        {
            return GetPermissionList(0, strWhere, "");
        }

        public System.Data.DataSet GetPermissionList(int Top, string strWhere)
        {
            return GetPermissionList(Top, strWhere, "");
        }

        public System.Data.DataSet GetPermissionList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PermissionID,Code,Name,Description,Url ");
            strSql.Append(" FROM Account_Permission ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public System.Data.DataSet GetPermissionList(string strWhere, string filedOrder, Model.PagedInfo pageInfo)
        {
            throw new System.NotImplementedException();
        }

        public System.Data.DataSet GetNoPermissionList(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ap.[PermissionID] ,                                   ");
            strSql.Append("        ap.[code] ,                                           ");
            strSql.Append("        ap.[name] ,                                           ");
            strSql.Append("        ap.[Description] ,                                    ");
            strSql.Append("        ap.[Url]                                              ");
            strSql.Append("FROM    dbo.Account_Permission ap                             ");
            strSql.Append("WHERE   ap.[PermissionID] NOT ( SELECT DISTINCT               ");
            strSql.Append("                                    PermissionID              ");
            strSql.Append("                             FROM   dbo.Account_RolePermission");
            strSql.Append("                             WHERE  RoleID = @RoleID )        ");

            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = roleId;

            return DbHelperSQL.Query(strSql.ToString());
        }

        public System.Data.DataSet GetPermissionListByRoleID(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ap.[PermissionID] ,                                   ");
            strSql.Append("        ap.[code] ,                                           ");
            strSql.Append("        ap.[name] ,                                           ");
            strSql.Append("        ap.[Description] ,                                    ");
            strSql.Append("        ap.[Url]                                              ");
            strSql.Append("FROM    dbo.Account_Permission ap                             ");
            strSql.Append("WHERE   ap.[PermissionID] IN ( SELECT DISTINCT                ");
            strSql.Append("                                    PermissionID              ");
            strSql.Append("                             FROM   dbo.Account_RolePermission");
            strSql.Append("                             WHERE  RoleID = @RoleID )        ");

            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = roleId;

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Account_Permission ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
