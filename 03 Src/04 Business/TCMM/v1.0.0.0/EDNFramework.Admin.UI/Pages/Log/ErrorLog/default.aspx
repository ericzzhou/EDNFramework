<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Log.ErrorLog._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="日志 > 系统日志" />
    <EDNFramework:ToolsBar ID="ToolsBar" runat="server" disable_Insert="True" Detail_Fun="PageModel.ShowDetail()" disable_Delete="True" disable_Modify="True" />
    <div id="grid_json" class="tab-content action-table ">
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {
            PageModel.BindGrid();
        });

        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Log/ErrorLog.ashx?ajax='
            , showUrl: 'show.aspx?id='
        };

        var PageModel = {
            pqsAjaxSource: url.ajaxUrl + 'getlist',
            GridID: '#grid_json',
            BindGrid: function () {
                _self = this;

                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "ID" },
                    { title: "异常类型", width: 120, dataIndx: "ErrorType" },
                    { title: "时间", width: 140, dataIndx: "OPTime" },
                    { title: "异常信息", width: 300, dataIndx: "Loginfo" },
                    { title: "请求路径", width: 500, dataIndx: "Url" }
                ];
                PQLoadGrid("ID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 3,
                    title: "<i class=\"icon-file\"></i>&nbsp;系统日志"
                })
                //pqGridResize(this.GridID, -100, 0);

            },
            ShowDetail: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ID");
                    location.href = url.showUrl + id;
                }
                else {
                    $.Alert("很抱歉，您当前未选中任何一行！");
                }

            }
        };
    </script>
</asp:Content>
