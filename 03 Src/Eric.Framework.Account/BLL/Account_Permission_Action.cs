using Eric.Framework.Account.IDAL;
using System.Collections.Generic;
using System.Data;

namespace Eric.Framework.Account.BLL
{
    public partial class Account_Permission_Action
    {
        private readonly IAccount_Permission_Action dal = DALFactory.DataAccess.CreateAccount_Permission_Action();
        public Account_Permission_Action() { }

        public int Create(Model.Account_Permission_Action Action)
        {
            return dal.Create(Action);
        }

        public bool Delete(int ActionID)
        {
            return dal.Delete(ActionID);
        }

        public bool Update(Model.Account_Permission_Action Action)
        {
            return dal.Update(Action);
        }

        public bool HasPermissionAction(int roleID, int PermissionID, int ActionID)
        {
            return dal.HasPermissionAction(roleID, PermissionID, ActionID);
        }

        public bool HasPermissionAction(int roleID, int PermissionID, string ActionCode)
        {
            return dal.HasPermissionAction(roleID, PermissionID, ActionCode);
        }

        public bool HasPermissionAction(int roleID, string PermissionCode, string ActionCode)
        {
            return HasPermissionAction(roleID, PermissionCode, ActionCode);
        }

        public Model.Account_Permission_Action GetAccount_Permission_Action(int ActionID)
        {
            return dal.GetAccount_Permission_Action(ActionID);
        }

        public Model.Account_Permission_Action GetAccount_Permission_Action(string Code)
        {
            return dal.GetAccount_Permission_Action(Code);
        }

        public IList<Model.Account_Permission_Action> GetAccount_Permission_Actions(int PermissionID)
        {
            return DataTableToList(dal.GetAccount_Permission_Actions(PermissionID).Tables[0]);
        }

        private List<Model.Account_Permission_Action> DataTableToList(DataTable dataTable)
        {
            List<Model.Account_Permission_Action> modelList = new List<Model.Account_Permission_Action>();
            int rowsCount = dataTable.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Account_Permission_Action model;
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

        public Model.Account_Permission_Action DataRowToModel(System.Data.DataRow row)
        {
            return dal.DataRowToModel(row);
        }
    }
}
