using Eric.Framework.CMS.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.CMS.SQLServerDAL
{
    public class CMS_ArticleCategory : ICMS_ArticleCategory
    {
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CMS_ArticleCategory");
        }

        public bool Exists(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_ArticleCategory");
            strSql.Append(" where Name=@Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = Name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int Add(Model.CMS_ArticleCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_ArticleCategory(");
            strSql.Append("Name,C_Index,Deleted,AllowComment,Img)");
            strSql.Append(" values (");
            strSql.Append("@Name,@C_Index,@Deleted,@AllowComment,@Img)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Index", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@AllowComment", SqlDbType.Bit,1),
					new SqlParameter("@Img", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.C_Index;
            parameters[2].Value = model.Deleted;
            parameters[3].Value = model.AllowComment;
            parameters[4].Value = model.Img;

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

        public bool Update(Model.CMS_ArticleCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ArticleCategory set ");
            strSql.Append("C_Index=@C_Index,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("AllowComment=@AllowComment,");
            strSql.Append("Img=@Img");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Index", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@AllowComment", SqlDbType.Bit,1),
					new SqlParameter("@Img", SqlDbType.NVarChar,300),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.C_Index;
            parameters[1].Value = model.Deleted;
            parameters[2].Value = model.AllowComment;
            parameters[3].Value = model.Img;
            parameters[4].Value = model.ID;
            parameters[5].Value = model.Name;

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
            strSql.Append("delete from CMS_ArticleCategory ");
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
            strSql.Append("delete from CMS_ArticleCategory ");
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

        public Model.CMS_ArticleCategory GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,C_Index,Deleted,AllowComment,Img from CMS_ArticleCategory ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Eric.Framework.CMS.Model.CMS_ArticleCategory model = new Eric.Framework.CMS.Model.CMS_ArticleCategory();
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

        public Model.CMS_ArticleCategory DataRowToModel(System.Data.DataRow row)
        {
            Eric.Framework.CMS.Model.CMS_ArticleCategory model = new Eric.Framework.CMS.Model.CMS_ArticleCategory();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["C_Index"] != null && row["C_Index"].ToString() != "")
                {
                    model.C_Index = int.Parse(row["C_Index"].ToString());
                }
                if (row["Deleted"] != null && row["Deleted"].ToString() != "")
                {
                    if ((row["Deleted"].ToString() == "1") || (row["Deleted"].ToString().ToLower() == "true"))
                    {
                        model.Deleted = true;
                    }
                    else
                    {
                        model.Deleted = false;
                    }
                }
                if (row["AllowComment"] != null && row["AllowComment"].ToString() != "")
                {
                    if ((row["AllowComment"].ToString() == "1") || (row["AllowComment"].ToString().ToLower() == "true"))
                    {
                        model.AllowComment = true;
                    }
                    else
                    {
                        model.AllowComment = false;
                    }
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
            strSql.Append("select ID,Name,C_Index,Deleted,AllowComment,Img ");
            strSql.Append(" FROM CMS_ArticleCategory ");
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
            strSql.Append(" ID,Name,C_Index,Deleted,AllowComment,Img ");
            strSql.Append(" FROM CMS_ArticleCategory ");
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
            strSql.Append("select count(1) FROM CMS_ArticleCategory ");
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
            strSql.Append(")AS Row, T.*  from CMS_ArticleCategory T ");
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
