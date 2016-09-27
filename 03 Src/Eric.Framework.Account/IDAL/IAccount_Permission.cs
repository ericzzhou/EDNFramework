using System.Data;

namespace Eric.Framework.Account.IDAL
{
    public interface IAccount_Permission
    {
        int Create(Model.Account_Permission model);
        int GetRecordCount(string strWhere);
        bool Delete(int PermissionID);
        bool Delete(string Code, int PermissionID);
        bool DeleteList(string PermissionIDlist);
        bool Update(Model.Account_Permission model);
        bool Exists(string Code, int PermissionID);
        Model.Account_Permission DataRowToModel(DataRow row);
        Model.Account_Permission GetPermission(int PermissionID);
        DataSet GetPermissionList();
        DataSet GetPermissionList(int top);
        DataSet GetPermissionList(string strWhere);
        DataSet GetPermissionList(int Top, string strWhere);
        DataSet GetPermissionList(int Top, string strWhere, string filedOrder);
        DataSet GetPermissionList(string strWhere, string filedOrder, Model.PagedInfo pageInfo);
        DataSet GetNoPermissionList(int roleId);
        DataSet GetPermissionListByRoleID(int roleId);
    }
}
