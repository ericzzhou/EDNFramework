using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.Account.IDAL
{
    public interface IAccount_User
    {
        int GetRecordCount(string strWhere);
        int ValidateLogin(string userName, string Password);
        int Create(Model.Account_User user);
        bool Update(Model.Account_User user);
        bool Delete(int userID);
        bool AddRole(Model.Account_UserRole userRole);
        bool RemoveRole(Model.Account_UserRole userRole);
        bool HasUser(string userName);
        //Account_User Retrieve(int userID);
        //Account_User Retrieve(string userName);
        bool SetPassword(int userID, string Password);
        bool SetPassword(string userName, string Password);
        Model.Account_User DataRowToModel(DataRow row);
        Model.Account_User GetUserByUserID(int userID);
        Model.Account_User GetUserByUserName(string userName);
        Model.Account_User GetUserByEmployeeID(string employeeID);
        DataSet GetUserList();
        DataSet GetUserList(int top);
        DataSet GetUserList(string strWhere);
        DataSet GetUserList(int top, string strWhere);
        DataSet GetUserList(string strWhere, string filedOrder);
        DataSet GetUserList(int Top, string strWhere, string filedOrder);
        DataSet GetUserList(string strWhere, string filedOrder, Model.PagedInfo page);
        Model.Account_Role GetUserRole(Model.Account_UserRole userRole);
        IList<Model.Account_Role> GetUserRole(int userID);
        DataSet GetUserByDepartmentID(string departmentID);
        DataSet GetUserByUserType(string userType);
    }
}
