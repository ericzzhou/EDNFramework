using Eric.Framework.Account.IDAL;
using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.Account.BLL
{
    public partial class Account_User
    {
        private readonly IAccount_User dal = DALFactory.DataAccess.CreateAccount_User();

        public Account_User()
        { }

        private IList<Model.Account_User> DataTableToList(DataTable dataTable)
        {
            IList<Model.Account_User> modelList = new List<Model.Account_User>();
            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Account_User model;
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



        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public int ValidateLogin(string userName, string Password)
        {
            return ValidateLogin(userName, Password);
        }

        public int Create(Model.Account_User user)
        {
            return dal.Create(user);
        }

        public bool Update(Model.Account_User user)
        {
            return dal.Update(user);
        }

        public bool Delete(int userID)
        {
            return dal.Delete(userID);
        }

        public bool AddRole(Model.Account_UserRole userRole)
        {
            return AddRole(userRole);
        }

        public bool RemoveRole(Model.Account_UserRole userRole)
        {
            return dal.RemoveRole(userRole);
        }

        public bool HasUser(string userName)
        {
            return HasUser(userName);
        }

        public bool SetPassword(int userID, string Password)
        {
            return dal.SetPassword(userID, Password);
        }

        public bool SetPassword(string userName, string Password)
        {
            return dal.SetPassword(userName, Password);
        }

        public Model.Account_User DataRowToModel(System.Data.DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        public Model.Account_User GetUserByUserID(int userID)
        {
            return dal.GetUserByUserID(userID);
        }

        public Model.Account_User GetUserByUserName(string userName)
        {
            return dal.GetUserByUserName(userName);
        }

        public Model.Account_User GetUserByEmployeeID(string employeeID)
        {
            return dal.GetUserByEmployeeID(employeeID);
        }

        public IList<Model.Account_User> GetUserList()
        {
            return DataTableToList(dal.GetUserList().Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(int top)
        {
            return DataTableToList(dal.GetUserList(top).Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(string strWhere)
        {
            return DataTableToList(dal.GetUserList(strWhere).Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(int top, string strWhere)
        {
            return DataTableToList(dal.GetUserList(top, strWhere).Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetUserList(strWhere, filedOrder).Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(int top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetUserList(top, strWhere, filedOrder).Tables[0]);
        }

        public IList<Model.Account_User> GetUserList(string strWhere, string filedOrder, Model.PagedInfo page)
        {
            return DataTableToList(dal.GetUserList(strWhere, filedOrder, page).Tables[0]);
        }

        public Model.Account_Role GetUserRole(Model.Account_UserRole userRole)
        {
            return dal.GetUserRole(userRole);
        }

        public IList<Model.Account_Role> GetUserRole(int userID)
        {
            return dal.GetUserRole(userID);
        }

        public System.Data.DataSet GetUserByDepartmentID(string departmentID)
        {
            return dal.GetUserByDepartmentID(departmentID);
        }

        public IList<Model.Account_User> GetUserByUserType(string userType)
        {
            return DataTableToList(dal.GetUserByUserType(userType).Tables[0]);
        }
    }
}
