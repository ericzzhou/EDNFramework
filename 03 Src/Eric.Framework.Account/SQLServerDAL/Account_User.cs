using Eric.Framework.Account.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.Account.SQLServerDAL
{
    public partial class Account_User : IAccount_User
    {

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Account_User ");
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

        public int ValidateLogin(string userName, string Password)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT TOP 1 UserID           ");
            strSql.Append("FROM  Account_User            ");
            strSql.Append("WHERE UserName = @UserName    ");
            strSql.Append("      AND Password = @Password");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,200)};
            parameters[0].Value = userName;
            parameters[1].Value = Password;
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

        public int Create(Model.Account_User user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account_User(");
            strSql.Append("UserName,Password,TrueName,Sex,Birthday,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,RegisterDate,RegisterIP)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@TrueName,@Sex,@Birthday,@Phone,@Email,@EmployeeID,@DepartmentID,@Activity,@UserType,@RegisterDate,@RegisterIP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,200),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Char,1),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.VarChar,10),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@RegisterIP", SqlDbType.VarChar,50)};
            parameters[0].Value = user.UserName;
            parameters[1].Value = user.Password;
            parameters[2].Value = user.TrueName;
            parameters[3].Value = user.Sex;
            parameters[4].Value = user.Birthday;
            parameters[5].Value = user.Phone;
            parameters[6].Value = user.Email;
            parameters[7].Value = user.EmployeeID;
            parameters[8].Value = user.DepartmentID;
            parameters[9].Value = user.Activity;
            parameters[10].Value = user.UserType;
            parameters[11].Value = user.RegisterDate;
            parameters[12].Value = user.RegisterIP;

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

        public bool Update(Model.Account_User user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Account_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("EmployeeID=@EmployeeID,");
            strSql.Append("DepartmentID=@DepartmentID,");
            strSql.Append("Activity=@Activity,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("RegisterDate=@RegisterDate,");
            strSql.Append("RegisterIP=@RegisterIP");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,200),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Char,1),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.VarChar,10),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@RegisterIP", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = user.UserName;
            parameters[1].Value = user.Password;
            parameters[2].Value = user.TrueName;
            parameters[3].Value = user.Sex;
            parameters[4].Value = user.Birthday;
            parameters[5].Value = user.Phone;
            parameters[6].Value = user.Email;
            parameters[7].Value = user.EmployeeID;
            parameters[8].Value = user.DepartmentID;
            parameters[9].Value = user.Activity;
            parameters[10].Value = user.UserType;
            parameters[11].Value = user.RegisterDate;
            parameters[12].Value = user.RegisterIP;
            parameters[13].Value = user.UserID;

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

        public bool Delete(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account_User ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userID;

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

        public bool AddRole(Model.Account_UserRole userRole)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [Account_UserRole] ");
            strSql.Append("           ([UserID],[RoleID]) ");
            strSql.Append("     VALUES                    ");
            strSql.Append("           (@UserID,@RoleID)   ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = userRole.UserID;
            parameters[1].Value = userRole.RoleID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public bool RemoveRole(Model.Account_UserRole userRole)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [Account_UserRole] ");
            strSql.Append("WHERE [UserID] = @UserID AND [RoleID] = @RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = userRole.UserID;
            parameters[1].Value = userRole.RoleID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public bool HasUser(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Account_User WHERE UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = userName;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            return Convert.ToInt32(obj) > 0;
        }

        public bool SetPassword(int userID, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TOP (1) [Account_User] ");
            strSql.Append("   SET [Password] = @Password ");
            strSql.Append(" WHERE UserID=@UserID         ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Password", SqlDbType.VarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = Password;
            parameters[1].Value = userID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public bool SetPassword(string userName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TOP (1) [Account_User] ");
            strSql.Append("   SET [Password] = @Password ");
            strSql.Append(" WHERE UserName=@UserName         ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Password", SqlDbType.VarChar,200),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = Password;
            parameters[1].Value = userName;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public Model.Account_User DataRowToModel(System.Data.DataRow row)
        {
            Model.Account_User model = new Model.Account_User();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["EmployeeID"] != null)
                {
                    model.EmployeeID = row["EmployeeID"].ToString();
                }
                if (row["DepartmentID"] != null)
                {
                    model.DepartmentID = row["DepartmentID"].ToString();
                }
                if (row["Activity"] != null && row["Activity"].ToString() != "")
                {
                    if ((row["Activity"].ToString() == "1") || (row["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (row["UserType"] != null)
                {
                    model.UserType = row["UserType"].ToString();
                }
                if (row["RegisterDate"] != null && row["RegisterDate"].ToString() != "")
                {
                    model.RegisterDate = DateTime.Parse(row["RegisterDate"].ToString());
                }
                if (row["RegisterIP"] != null)
                {
                    model.RegisterIP = row["RegisterIP"].ToString();
                }
            }
            return model;
        }

        public Model.Account_User GetUserByUserID(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1             ");
            strSql.Append("        UserID ,         ");
            strSql.Append("        UserName ,       ");
            strSql.Append("        Password ,       ");
            strSql.Append("        TrueName ,       ");
            strSql.Append("        Sex ,            ");
            strSql.Append("        Birthday ,       ");
            strSql.Append("        Phone ,          ");
            strSql.Append("        Email ,          ");
            strSql.Append("        EmployeeID ,     ");
            strSql.Append("        DepartmentID ,   ");
            strSql.Append("        Activity ,       ");
            strSql.Append("        UserType ,       ");
            strSql.Append("        RegisterDate ,   ");
            strSql.Append("        RegisterIP       ");
            strSql.Append("FROM    Account_User     ");
            strSql.Append("WHERE   UserID = @UserID ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userID;

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

        public Model.Account_User GetUserByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1             ");
            strSql.Append("        UserID ,         ");
            strSql.Append("        UserName ,       ");
            strSql.Append("        Password ,       ");
            strSql.Append("        TrueName ,       ");
            strSql.Append("        Sex ,            ");
            strSql.Append("        Birthday ,       ");
            strSql.Append("        Phone ,          ");
            strSql.Append("        Email ,          ");
            strSql.Append("        EmployeeID ,     ");
            strSql.Append("        DepartmentID ,   ");
            strSql.Append("        Activity ,       ");
            strSql.Append("        UserType ,       ");
            strSql.Append("        RegisterDate ,   ");
            strSql.Append("        RegisterIP       ");
            strSql.Append("FROM    Account_User     ");
            strSql.Append("WHERE   UserName = @UserName ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = userName;

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

        public Model.Account_User GetUserByEmployeeID(string employeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1             ");
            strSql.Append("        UserID ,         ");
            strSql.Append("        UserName ,       ");
            strSql.Append("        Password ,       ");
            strSql.Append("        TrueName ,       ");
            strSql.Append("        Sex ,            ");
            strSql.Append("        Birthday ,       ");
            strSql.Append("        Phone ,          ");
            strSql.Append("        Email ,          ");
            strSql.Append("        EmployeeID ,     ");
            strSql.Append("        DepartmentID ,   ");
            strSql.Append("        Activity ,       ");
            strSql.Append("        UserType ,       ");
            strSql.Append("        RegisterDate ,   ");
            strSql.Append("        RegisterIP       ");
            strSql.Append("FROM    Account_User     ");
            strSql.Append("WHERE   EmployeeID = @EmployeeID ");

            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.VarChar,50)
			};
            parameters[0].Value = employeeID;

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

        public System.Data.DataSet GetUserList()
        {
            return GetUserList(0, "", "");
        }

        public System.Data.DataSet GetUserList(int top)
        {
            return GetUserList(top, "", "");
        }

        public System.Data.DataSet GetUserList(string strWhere)
        {
            return GetUserList(0, strWhere, "");
        }

        public System.Data.DataSet GetUserList(int top, string strWhere)
        {
            return GetUserList(top, strWhere, "");
        }

        public System.Data.DataSet GetUserList(string strWhere, string filedOrder)
        {
            return GetUserList(0, strWhere, filedOrder);
        }

        public System.Data.DataSet GetUserList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT           ");
            if (Top > 0)
            {
                strSql.AppendFormat("TOP {0}", Top);
            }
            strSql.Append("        UserID ,      ");
            strSql.Append("        UserName ,    ");
            strSql.Append("        Password ,    ");
            strSql.Append("        TrueName ,    ");
            strSql.Append("        Sex ,         ");
            strSql.Append("        Birthday ,    ");
            strSql.Append("        Phone ,       ");
            strSql.Append("        Email ,       ");
            strSql.Append("        EmployeeID ,  ");
            strSql.Append("        DepartmentID ,");
            strSql.Append("        Activity ,    ");
            strSql.Append("        UserType ,    ");
            strSql.Append("        RegisterDate ,");
            strSql.Append("        RegisterIP    ");
            strSql.Append("FROM    Account_User  ");
            if (strWhere.Trim() != "")
            {
                strSql.AppendFormat("WHERE {0} ", strWhere);
            }

            if (filedOrder.Trim() != "")
            {
                strSql.AppendFormat("ORDER BY {0} ", filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        public System.Data.DataSet GetUserList(string strWhere, string filedOrder, Model.PagedInfo page)
        {
            throw new NotImplementedException();
        }

        public Model.Account_Role GetUserRole(Model.Account_UserRole userRole)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" SELECT TOP 1                                                       ");
            strSql.Append("         r.RoleID ,                                                 ");
            strSql.Append("         r.Name ,                                                   ");
            strSql.Append("         r.Description                                              ");
            strSql.Append(" FROM    Account_Role r                                             ");
            strSql.Append("         INNER JOIN Account_UserRole ur ON ur.RoleID = r.RoleID     ");
            strSql.Append(" WHERE   ur.UserID = @UserID AND ur.RoleID = @RoleID                ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = userRole.UserID;
            parameters[1].Value = userRole.RoleID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Account_Role ar_dal = new Account_Role();
                return ar_dal.DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public IList<Model.Account_Role> GetUserRole(int userID)
        {
            List<Model.Account_Role> modelList = new List<Model.Account_Role>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" SELECT TOP 1                                                       ");
            strSql.Append("         r.RoleID ,                                                 ");
            strSql.Append("         r.Name ,                                                   ");
            strSql.Append("         r.Description                                              ");
            strSql.Append(" FROM    Account_Role r                                             ");
            strSql.Append("         INNER JOIN Account_UserRole ur ON ur.RoleID = r.RoleID     ");
            strSql.Append(" WHERE   ur.UserID = @UserID                                        ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
			};
            parameters[0].Value = userID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Account_Role ar_dal = new Account_Role();
                int rowsCount = ds.Tables[0].Rows.Count;
                Model.Account_Role model;
                for (int i = 0; i < rowsCount; i++)
                {
                    model = ar_dal.DataRowToModel(ds.Tables[0].Rows[i]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public System.Data.DataSet GetUserByDepartmentID(string departmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT                               ");
            strSql.Append("        UserID ,                     ");
            strSql.Append("        UserName ,                   ");
            strSql.Append("        Password ,                   ");
            strSql.Append("        TrueName ,                   ");
            strSql.Append("        Sex ,                        ");
            strSql.Append("        Birthday ,                   ");
            strSql.Append("        Phone ,                      ");
            strSql.Append("        Email ,                      ");
            strSql.Append("        EmployeeID ,                 ");
            strSql.Append("        DepartmentID ,               ");
            strSql.Append("        Activity ,                   ");
            strSql.Append("        UserType ,                   ");
            strSql.Append("        RegisterDate ,               ");
            strSql.Append("        RegisterIP                   ");
            strSql.Append("FROM    Account_User                 ");
            strSql.Append("WHERE   DepartmentID = @DepartmentID ");

            SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50)
			};
            parameters[0].Value = departmentID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        public System.Data.DataSet GetUserByUserType(string userType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT                       ");
            strSql.Append("        UserID ,             ");
            strSql.Append("        UserName ,           ");
            strSql.Append("        Password ,           ");
            strSql.Append("        TrueName ,           ");
            strSql.Append("        Sex ,                ");
            strSql.Append("        Birthday ,           ");
            strSql.Append("        Phone ,              ");
            strSql.Append("        Email ,              ");
            strSql.Append("        EmployeeID ,         ");
            strSql.Append("        DepartmentID ,       ");
            strSql.Append("        Activity ,           ");
            strSql.Append("        UserType ,           ");
            strSql.Append("        RegisterDate ,       ");
            strSql.Append("        RegisterIP           ");
            strSql.Append("FROM    Account_User         ");
            strSql.Append("WHERE   UserType = @UserType ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.VarChar,10)
			};
            parameters[0].Value = userType;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
    }
}
