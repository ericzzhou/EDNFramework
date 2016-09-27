using System.Data;
namespace Eric.Framework.Account.IDAL
{
    public interface IAccount_Permission_Action
    {
        int Create(Model.Account_Permission_Action Action);
        bool Delete(int ActionID);
        bool Update(Model.Account_Permission_Action Action);
        bool HasPermissionAction(int roleID, int PermissionID, int ActionID);
        bool HasPermissionAction(int roleID, int PermissionID, string ActionCode);
        bool HasPermissionAction(int roleID, string PermissionCode, string ActionCode);
        Model.Account_Permission_Action GetAccount_Permission_Action(int ActionID);
        Model.Account_Permission_Action GetAccount_Permission_Action(string Code);
        DataSet GetAccount_Permission_Actions(int PermissionID);
        Model.Account_Permission_Action DataRowToModel(DataRow row);
    }
}
