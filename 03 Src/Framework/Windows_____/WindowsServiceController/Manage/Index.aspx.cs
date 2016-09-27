using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsServiceController.Entities;

namespace WindowsServiceController.Manage
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || Session["userName"] == "")
            {
                Response.Redirect("~/Index.aspx");
                Response.Clear();
            }
            //List<ServiceEntity> services = GetServices();
            //gvServices.DataSource = null;
            //gvServices.DataSource = services;
        }

        public static List<ServiceEntity> GetServices(string displayName)
        {
            List<ServiceEntity> list = new List<ServiceEntity>();
            //ServiceController sc = new ServiceController();// 建立服务控制类对象
            ServiceController[] services = ServiceController.GetServices();
            foreach (var item in services)
            {
                ServiceEntity entity = new ServiceEntity();
                entity.CanStop = item.CanStop;
                entity.DisplayName = item.DisplayName;
                entity.ServiceName = item.ServiceName;
                entity.ServiceStatus = item.Status;
                entity.CanStart = item.Status == ServiceControllerStatus.Paused || item.Status == ServiceControllerStatus.Stopped;
                entity.ShowLoading = item.Status == ServiceControllerStatus.ContinuePending || item.Status == ServiceControllerStatus.PausePending || item.Status == ServiceControllerStatus.StartPending || item.Status == ServiceControllerStatus.StopPending;
                list.Add(entity);
            }
            list = list.OrderByDescending(x => x.DisplayName).ToList();
            if (string.IsNullOrWhiteSpace(displayName))
            {
                return list;
            }
            else
            {
                return list.Where(x => x.DisplayName.Contains(displayName)).ToList();
            }
        }

        protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            string commandArg = e.CommandArgument.ToString();
            if (commandName == "OperationStop")
            {
                StopService(commandArg);
            }
            if (commandName == "OperationStart")
            {
                StartService(commandArg);
            }
        }

        private void StartService(string ServiceName)
        {
            ServiceController sc = new ServiceController(ServiceName);
            sc.Start();
            Bind();
        }



        private void StopService(string ServiceName)
        {
            ServiceController sc = new ServiceController(ServiceName);
            sc.Stop();
            Bind();
        }

        private void Bind()
        {
            //gvServices.DataSource = null;
            //gvServices.DataSource = GetServices(txtDisplayName.Text.Trim());
            //gvServices.DataBind();
            gvServices.DataSourceID = "ServicesDataSource";
        }

        protected void timerReferee_Tick(object sender, EventArgs e)
        {
            Bind();
        }
    }
}