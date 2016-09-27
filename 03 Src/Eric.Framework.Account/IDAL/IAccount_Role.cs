using System.Data;

namespace Eric.Framework.Account.IDAL
{
    public interface IAccount_Role
    {
        int Create(Model.Account_Role role);
        int GetRecordCount(string strWhere);
        bool Update(Model.Account_Role role);
        bool Delete(int RoleID);
        bool AddPermission(Model.Account_RolePermission RolePermission);
        bool RemovePermission(Model.Account_RolePermission RolePermission);
        bool ClearPermissions(int roleId);
        Model.Account_Role DataRowToModel(DataRow row);
        Model.Account_Role GetAccount_Role(int roleId);
        //DataSet GetRoleList();
        DataSet GetRoleList(int top);
        DataSet GetRoleList(string strWhere);
        DataSet GetRoleList(int top, string strWhere);
        DataSet GetRoleList(string strWhere, string filedOrder);
        DataSet GetRoleList(int Top, string strWhere, string filedOrder);
        DataSet GetRoleList(string strWhere, string filedOrder, Model.PagedInfo page);
    }
}
