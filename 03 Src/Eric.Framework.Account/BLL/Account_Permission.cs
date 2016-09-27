using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.Account.BLL
{
    public partial class Account_Permission
    {
        private readonly IDAL.IAccount_Permission dal = DALFactory.DataAccess.CreateAccount_Permission();
        public Account_Permission()
        {
        }

        private List<Model.Account_Permission> DataTableToList(DataTable dataTable)
        {
            List<Model.Account_Permission> modelList = new List<Model.Account_Permission>();
            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Account_Permission model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dataTable.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public int Create(Model.Account_Permission model)
        {
            return dal.Create(model);
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public bool Delete(int PermissionID)
        {
            return dal.Delete(PermissionID);
        }

        public bool Delete(string Code, int PermissionID)
        {
            return dal.Delete(Code, PermissionID);
        }

        public bool DeleteList(string PermissionIDlist)
        {
            return dal.DeleteList(PermissionIDlist);
        }

        public bool Update(Model.Account_Permission model)
        {
            return dal.Update(model);
        }

        public bool Exists(string Code, int PermissionID)
        {
            return dal.Exists(Code, PermissionID);
        }

        public Model.Account_Permission DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        public Model.Account_Permission GetPermission(int PermissionID)
        {
            return dal.GetPermission(PermissionID);
        }

        public List<Model.Account_Permission> GetPermissionList()
        {
            return DataTableToList(dal.GetPermissionList().Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionList(int top)
        {
            return DataTableToList(dal.GetPermissionList(top).Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionList(string strWhere)
        {
            return DataTableToList(dal.GetPermissionList(strWhere).Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionList(int top, string strWhere)
        {
            return DataTableToList(dal.GetPermissionList(top, strWhere).Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionList(int top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetPermissionList(top, strWhere, filedOrder).Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionList(string strWhere, string filedOrder, Model.PagedInfo pageInfo)
        {
            return DataTableToList(dal.GetPermissionList(strWhere, filedOrder, pageInfo).Tables[0]);
        }

        public List<Model.Account_Permission> GetNoPermissionList(int roleId)
        {
            return DataTableToList(dal.GetNoPermissionList(roleId).Tables[0]);
        }

        public List<Model.Account_Permission> GetPermissionListByRoleID(int roleId)
        {
            return DataTableToList(dal.GetPermissionListByRoleID(roleId).Tables[0]);
        }
    }
}
