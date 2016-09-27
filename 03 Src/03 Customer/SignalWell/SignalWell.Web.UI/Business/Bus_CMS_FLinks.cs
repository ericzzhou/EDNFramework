using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Business
{
    public class Bus_CMS_FLinks
    {
        public static IList<Models.EDNF_CMS_FLinks> GetALL()
        {
            string sql = "SELECT * FROM [EDNF_CMS_FLinks] WHERE [State]= 1 AND IsDisplay = 1";
            Command cmd = CommandManager.CreateCommand(sql);
            return cmd.ExecuteEntities<Models.EDNF_CMS_FLinks>();
        }
    }
}