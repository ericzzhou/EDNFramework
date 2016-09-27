using Eric.Framework.Account.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.Account.SQLServerDAL
{
    public partial class Account_Permission_Action : IAccount_Permission_Action
    {

        public int Create(Model.Account_Permission_Action Action)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account_Permission_Action(");
            strSql.Append("Code,PermissionID,Name)");
            strSql.Append(" values (");
            strSql.Append("@Code,@PermissionID,@Name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20),
					new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,20)};
            parameters[0].Value = Action.Code;
            parameters[1].Value = Action.PermissionID;
            parameters[2].Value = Action.Name;

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

        public bool Delete(int ActionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_Permission_Action ");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActionID;

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

        public bool Update(Model.Account_Permission_Action Action)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Account_Permission_Action set ");
            strSql.Append("Code=@Code,");
            strSql.Append("PermissionID=@PermissionID,");
            strSql.Append("Name=@Name");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20),
					new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@ActionID", SqlDbType.Int,4)};
            parameters[0].Value = Action.Code;
            parameters[1].Value = Action.PermissionID;
            parameters[2].Value = Action.Name;
            parameters[3].Value = Action.ActionID;

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

        public bool HasPermissionAction(int roleID, int PermissionID, int ActionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(1)                         ");
            strSql.Append("FROM    Account_RolePermission           ");
            strSql.Append("WHERE   RoleID = @RoleID                 ");
            strSql.Append("        AND PermissionID = @PermissionID ");
            strSql.Append("        AND ActionID = @ActionID         ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4)};
            parameters[0].Value = roleID;
            parameters[1].Value = PermissionID;
            parameters[2].Value = ActionID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj) > 0;
        }

        public bool HasPermissionAction(int roleID, int PermissionID, string ActionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(1)                                                                                 ");
            strSql.Append("FROM    Account_RolePermission arp                                                               ");
            strSql.Append("        INNER JOIN Account_Permission_Action apa ON apa.ActionID = arp.ActionID                  ");
            strSql.Append("                                                        AND apa.PermissionID = arp.PermissionID  ");
            strSql.Append("WHERE   arp.RoleID = @RoleID                                                                     ");
            strSql.Append("        AND arp.PermissionID = @PermissionID                                                     ");
            strSql.Append("        AND apa.Code = @Code                                                                     ");

            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@PermissionID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,20)};
            parameters[0].Value = roleID;
            parameters[1].Value = PermissionID;
            parameters[2].Value = ActionCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj) > 0;
        }

        public bool HasPermissionAction(int roleID, string PermissionCode, string ActionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(1)                                                                      ");
            strSql.Append("FROM    Account_RolePermission arp                                                    ");
            strSql.Append("        INNER JOIN Account_Permission_Action apa ON apa.ActionID = arp.ActionID       ");
            strSql.Append("        INNER JOIN Account_Permission ap ON ap.PermissionID = apa.PermissionID        ");
            strSql.Append("WHERE   arp.RoleID = @RoleID                                                          ");
            strSql.Append("        AND ap.Code = @PermissionCode                                                 ");
            strSql.Append("        AND apa.Code = @ActionCode                                                    ");

            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@PermissionCode", SqlDbType.VarChar,20),
					new SqlParameter("@ActionCode", SqlDbType.VarChar,20)};
            parameters[0].Value = roleID;
            parameters[1].Value = PermissionCode;
            parameters[2].Value = ActionCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj) > 0;
        }

        public Model.Account_Permission_Action GetAccount_Permission_Action(int ActionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ActionID,Code,PermissionID,Name from Account_Permission_Action ");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActionID;

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

        public Model.Account_Permission_Action GetAccount_Permission_Action(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ActionID,Code,PermissionID,Name from Account_Permission_Action ");
            strSql.Append(" where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,20)
			};
            parameters[0].Value = Code;

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

        public System.Data.DataSet GetAccount_Permission_Actions(int PermissionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ActionID,Code,PermissionID,Name from Account_Permission_Action ");
            strSql.Append(" where PermissionID=@PermissionID");
            SqlParameter[] parameters = {
					new SqlParameter("@PermissionID", SqlDbType.Int,4)
			};
            parameters[0].Value = PermissionID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        public Model.Account_Permission_Action DataRowToModel(System.Data.DataRow row)
        {
            Model.Account_Permission_Action model = new Model.Account_Permission_Action();
            if (row != null)
            {
                if (row["ActionID"] != null && row["ActionID"].ToString() != "")
                {
                    model.ActionID = int.Parse(row["ActionID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["PermissionID"] != null && row["PermissionID"].ToString() != "")
                {
                    model.PermissionID = int.Parse(row["PermissionID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
            }
            return model;
        }
    }
}
