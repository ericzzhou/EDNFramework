﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineRepairs.Library.SMSServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://entinfo.cn/", ConfigurationName="SMSServiceReference.WebServiceSoap")]
    public interface WebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://entinfo.cn/mdsmssend", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string mdsmssend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string msgfmt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://entinfo.cn/mdgxsend", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string mdgxsend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string msgfmt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://entinfo.cn/mdgetSninfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string mdgetSninfo(string sn, string pwd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : OnlineRepairs.Library.SMSServiceReference.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<OnlineRepairs.Library.SMSServiceReference.WebServiceSoap>, OnlineRepairs.Library.SMSServiceReference.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string mdsmssend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string msgfmt) {
            return base.Channel.mdsmssend(sn, pwd, mobile, content, ext, stime, rrid, msgfmt);
        }
        
        public string mdgxsend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string msgfmt) {
            return base.Channel.mdgxsend(sn, pwd, mobile, content, ext, stime, rrid, msgfmt);
        }
        
        public string mdgetSninfo(string sn, string pwd) {
            return base.Channel.mdgetSninfo(sn, pwd);
        }
    }
}
