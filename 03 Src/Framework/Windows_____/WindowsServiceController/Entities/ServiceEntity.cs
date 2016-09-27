using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace WindowsServiceController.Entities
{
    public class ServiceEntity
    {
        public string ServiceName { get; set; }
        public string DisplayName { get; set; }
        public ServiceControllerStatus ServiceStatus { get; set; }
        public bool CanStop { get; set; }
        public bool CanStart { get; set; }
        public bool ShowLoading { get; set; }
    }
}