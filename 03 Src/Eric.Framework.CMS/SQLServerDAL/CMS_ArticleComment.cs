using Eric.Framework.CMS.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.CMS.SQLServerDAL
{
    public class CMS_ArticleComment : ICMS_ArticleComment
    {
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CMS_ArticleComment"); 
        }

        public int Add(Model.CMS_ArticleComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_ArticleComment(");
            strSql.Append("ArticleID,Title,Body,CreateTime,UserID,UserName,UserEmail,UserIP,Img)");
            strSql.Append(" values (");
            strSql.Append("@ArticleID,@Title,@Body,@CreateTime,@UserID,@UserName,@UserEmail,@UserIP,@Img)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Body", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserEmail", SqlDbType.VarChar,200),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20),
					new SqlParameter("@Img", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ArticleID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Body;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.UserEmail;
            parameters[7].Value = model.UserIP;
            parameters[8].Value = model.Img;

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

        public bool Update(Model.CMS_ArticleComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ArticleComment set ");
            strSql.Append("ArticleID=@ArticleID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Body=@Body,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserIP=@UserIP,");
            strSql.Append("Img=@Img");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Body", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserEmail", SqlDbType.VarChar,200),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20),
					new SqlParameter("@Img", SqlDbType.NVarChar,300),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ArticleID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Body;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.UserEmail;
            parameters[7].Value = model.UserIP;
            parameters[8].Value = model.Img;
            parameters[9].Value = model.ID;

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

        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ArticleComment ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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

        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ArticleComment ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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

        public Model.CMS_ArticleComment GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ArticleID,Title,Body,CreateTime,UserID,UserName,UserEmail,UserIP,Img from CMS_ArticleComment ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Eric.Framework.CMS.Model.CMS_ArticleComment model = new Eric.Framework.CMS.Model.CMS_ArticleComment();
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

        public Model.CMS_ArticleComment DataRowToModel(System.Data.DataRow row)
        {
            Eric.Framework.CMS.Model.CMS_ArticleComment model = new Eric.Framework.CMS.Model.CMS_ArticleComment();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ArticleID"] != null && row["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(row["ArticleID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Body"] != null)
                {
                    model.Body = row["Body"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["UserIP"] != null)
                {
                    model.UserIP = row["UserIP"].ToString();
                }
                if (row["Img"] != null)
                {
                    model.Img = row["Img"].ToString();
                }
            }
            return model;
        }

        public System.Data.DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ArticleID,Title,Body,CreateTime,UserID,UserName,UserEmail,UserIP,Img ");
            strSql.Append(" FROM CMS_ArticleComment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public System.Data.DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ArticleID,Title,Body,CreateTime,UserID,UserName,UserEmail,UserIP,Img ");
            strSql.Append(" FROM CMS_ArticleComment ");
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

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CMS_ArticleComment ");
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

        public System.Data.DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CMS_ArticleComment T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
