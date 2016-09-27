using Eric.Framework.CMS.IDAL;
using Eric.Framework.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Eric.Framework.CMS.SQLServerDAL
{
    public class CMS_Article : ICMS_Article
    {
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CMS_Article");
        }

        public bool Exists(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_Article");
            strSql.Append(" where Code=@Code and ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,200)};
            parameters[0].Value = Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int Add(Model.CMS_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Article(");
            strSql.Append("Code,Keyword,Description,Title,Body,Tag,Deleted,CategoryID,AllowComment,CreateTime,AuthorID,AuthorName,Img)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Keyword,@Description,@Title,@Body,@Tag,@Deleted,@CategoryID,@AllowComment,@CreateTime,@AuthorID,@AuthorName,@Img)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,200),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Title", SqlDbType.NVarChar,300),
					new SqlParameter("@Body", SqlDbType.VarChar,-1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,50),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@AllowComment", SqlDbType.Bit,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@AuthorID", SqlDbType.Int,4),
					new SqlParameter("@AuthorName", SqlDbType.NVarChar,20),
					new SqlParameter("@Img", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Keyword;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Body;
            parameters[5].Value = model.Tag;
            parameters[6].Value = model.Deleted;
            parameters[7].Value = model.CategoryID;
            parameters[8].Value = model.AllowComment;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.AuthorID;
            parameters[11].Value = model.AuthorName;
            parameters[12].Value = model.Img;

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

        public bool Update(Model.CMS_Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Article set ");
            strSql.Append("Keyword=@Keyword,");
            strSql.Append("Description=@Description,");
            strSql.Append("Title=@Title,");
            strSql.Append("Body=@Body,");
            strSql.Append("Tag=@Tag,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("AllowComment=@AllowComment,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("AuthorID=@AuthorID,");
            strSql.Append("AuthorName=@AuthorName,");
            strSql.Append("Img=@Img");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Keyword", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Title", SqlDbType.NVarChar,300),
					new SqlParameter("@Body", SqlDbType.VarChar,-1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,50),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@AllowComment", SqlDbType.Bit,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@AuthorID", SqlDbType.Int,4),
					new SqlParameter("@AuthorName", SqlDbType.NVarChar,20),
					new SqlParameter("@Img", SqlDbType.NVarChar,300),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,200)};
            parameters[0].Value = model.Keyword;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Body;
            parameters[4].Value = model.Tag;
            parameters[5].Value = model.Deleted;
            parameters[6].Value = model.CategoryID;
            parameters[7].Value = model.AllowComment;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.AuthorID;
            parameters[10].Value = model.AuthorName;
            parameters[11].Value = model.Img;
            parameters[12].Value = model.ID;
            parameters[13].Value = model.Code;

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
            strSql.Append("delete from CMS_Article ");
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
            strSql.Append("delete from CMS_Article ");
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

        public Model.CMS_Article GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Code,Keyword,Description,Title,Body,Tag,Deleted,CategoryID,AllowComment,CreateTime,AuthorID,AuthorName,Img from CMS_Article ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Eric.Framework.CMS.Model.CMS_Article model = new Eric.Framework.CMS.Model.CMS_Article();
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

        public Model.CMS_Article DataRowToModel(System.Data.DataRow row)
        {
            Eric.Framework.CMS.Model.CMS_Article model = new Eric.Framework.CMS.Model.CMS_Article();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Keyword"] != null)
                {
                    model.Keyword = row["Keyword"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Body"] != null)
                {
                    model.Body = row["Body"].ToString();
                }
                if (row["Tag"] != null)
                {
                    model.Tag = row["Tag"].ToString();
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
                if (row["CategoryID"] != null && row["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(row["CategoryID"].ToString());
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
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["AuthorID"] != null && row["AuthorID"].ToString() != "")
                {
                    model.AuthorID = int.Parse(row["AuthorID"].ToString());
                }
                if (row["AuthorName"] != null)
                {
                    model.AuthorName = row["AuthorName"].ToString();
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
            strSql.Append("select ID,Code,Keyword,Description,Title,Body,Tag,Deleted,CategoryID,AllowComment,CreateTime,AuthorID,AuthorName,Img ");
            strSql.Append(" FROM CMS_Article ");
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
            strSql.Append(" ID,Code,Keyword,Description,Title,Body,Tag,Deleted,CategoryID,AllowComment,CreateTime,AuthorID,AuthorName,Img ");
            strSql.Append(" FROM CMS_Article ");
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
            strSql.Append("select count(1) FROM CMS_Article ");
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
            strSql.Append(")AS Row, T.*  from CMS_Article T ");
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
