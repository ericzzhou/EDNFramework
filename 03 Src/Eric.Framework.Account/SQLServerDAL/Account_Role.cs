using Eric.Framework.Account.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.Account.SQLServerDAL
{
    public partial class Account_Role : IAccount_Role
    {

        public int Create(Model.Account_Role role)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account_Role(");
            strSql.Append("Name,Description)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,255)};
            parameters[0].Value = role.Name;
            parameters[1].Value = role.Description;

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

        public bool Update(Model.Account_Role role)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Account_Role set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Description=@Description");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = role.Name;
            parameters[1].Value = role.Description;
            parameters[2].Value = role.RoleID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows > 0;
        }

        public bool Delete(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public bool AddPermission(Model.Account_RolePermission RolePermission)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [Account_RolePermission] ");
            strSql.Append("([RoleID],[PermissionID],[ActionID])");
            strSql.Append(" values ");
            strSql.Append("@RoleID,@PermissionID,@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4)};
            parameters[0].Value = RolePermission.RoleID;
            parameters[1].Value = RolePermission.PermissionID;
            parameters[1].Value = RolePermission.ActionID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows > 0;
        }

        public bool RemovePermission(Model.Account_RolePermission RolePermission)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [Account_RolePermission]");
            strSql.Append(" WHERE ");
            strSql.Append("[RoleID]= @RoleID ");
            strSql.Append(" AND [PermissionID]= @PermissionID");
            strSql.Append(" AND [ActionID]=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4)};
            parameters[0].Value = RolePermission.RoleID;
            parameters[1].Value = RolePermission.PermissionID;
            parameters[1].Value = RolePermission.ActionID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows > 0;
        }

        public bool ClearPermissions(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [Account_RolePermission]");
            strSql.Append(" WHERE ");
            strSql.Append("[RoleID]= @RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = roleId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows > 0;
        }

        public Model.Account_Role DataRowToModel(System.Data.DataRow row)
        {
            Model.Account_Role model = new Model.Account_Role();
            if (row != null)
            {
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
            }
            return model;
        }

        public Model.Account_Role GetAccount_Role(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,Name,Description from Account_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = roleId;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataSet GetRoleList(int top)
        {
            return GetRoleList(top, "", "");
        }

        public System.Data.DataSet GetRoleList(string strWhere)
        {
            return GetRoleList(0, strWhere, "");
        }

        public System.Data.DataSet GetRoleList(int top, string strWhere)
        {
            return GetRoleList(top, strWhere, "");
        }

        public System.Data.DataSet GetRoleList(string strWhere, string filedOrder)
        {
            return GetRoleList(0, strWhere, filedOrder);
        }

        public System.Data.DataSet GetRoleList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RoleID,Name,Description ");
            strSql.Append(" FROM Account_Role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public System.Data.DataSet GetRoleList(string strWhere, string filedOrder, Model.PagedInfo page)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Account_Role ");
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
