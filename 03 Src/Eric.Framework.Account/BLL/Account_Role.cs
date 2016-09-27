using Eric.Framework.Account.IDAL;
using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.Account.BLL
{
    public partial class Account_Role
    {
        private readonly IAccount_Role dal = DALFactory.DataAccess.CreateAccount_Role();
        public Account_Role() { }

        public int Create(Model.Account_Role role)
        {
            return dal.Create(role);
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public bool Update(Model.Account_Role role)
        {
            return dal.Update(role);
        }

        public bool Delete(int RoleID)
        {
            return dal.Delete(RoleID);
        }

        public bool AddPermission(Model.Account_RolePermission RolePermission)
        {
            return dal.AddPermission(RolePermission);
        }

        public bool RemovePermission(Model.Account_RolePermission RolePermission)
        {
            return dal.RemovePermission(RolePermission);
        }

        public bool ClearPermissions(int roleId)
        {
            return dal.ClearPermissions(roleId);
        }

        public Model.Account_Role DataRowToModel(System.Data.DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        public Model.Account_Role GetAccount_Role(int roleId)
        {
            return dal.GetAccount_Role(roleId);
        }

        public IList<Model.Account_Role> GetRoleList(int top)
        {
            return DataTableToList(dal.GetRoleList(top).Tables[0]);
        }

        public IList<Model.Account_Role> GetRoleList(string strWhere)
        {
            return DataTableToList(dal.GetRoleList(strWhere).Tables[0]);
        }

        public IList<Model.Account_Role> GetRoleList(int top, string strWhere)
        {
            return DataTableToList(dal.GetRoleList(top, strWhere).Tables[0]);
        }

        public IList<Model.Account_Role> GetRoleList(string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetRoleList(strWhere, filedOrder).Tables[0]);
        }

        public IList<Model.Account_Role> GetRoleList(int top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetRoleList(top, strWhere, filedOrder).Tables[0]);
        }

        public IList<Model.Account_Role> GetRoleList(string strWhere, string filedOrder, Model.PagedInfo page)
        {
            return DataTableToList(dal.GetRoleList(strWhere, filedOrder, page).Tables[0]);
        }

        private IList<Model.Account_Role> DataTableToList(DataTable dataTable)
        {
            IList<Model.Account_Role> modelList = new List<Model.Account_Role>();
            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Account_Role model;
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
    }
}
