<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.Slide.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="其他 > 轮播幻灯片" />
    <div class="tools_bar-inner">
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Insert()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Edit()">
            <i class="icon-pencil"></i>
            <span>编辑</span>
        </a>
        <%--<a href="javascript:void(0);" class="btn" onclick="PageModel.Delete()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>--%>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Files()">
            <i class="icon-minus-sign"></i>
            <span>维护文件</span>
        </a>



    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table "></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
            PageModel.Bind();
        });
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Other/Slide.ashx?ajax='
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/Slide/Group/Edit.aspx?id='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/Slide/Group/Add.aspx'
         };
        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getgrouppagerdata',
            Insert: function () {
                _self = this;
                $.RemoteDialog("添加幻灯片组", url.addUrl, {
                    height: 390,
                    width: 500,
                    close: function () {
                        //alert("关闭了")
                        _self.RefreshGrid();
                    }
                });
            },
            Edit: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    $.RemoteDialog("编辑幻灯片组", url.editUrl + id, {
                        height: 390,
                        width: 500,
                        close: function () {
                            //alert("关闭了")
                            _self.RefreshGrid();
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            Files: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    window.location.href = "item/default.aspx?groupid=" + id;
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            Bind: function () {
                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "组编号", width: 100, dataIndx: "ID" },
                    { title: "组名称", width: 200, dataIndx: "Name" },
                    { title: "轮播间隔(ms)", width: 100, dataIndx: "delay" },
                    { title: "类型", width: 80, dataIndx: "ItemType" },
                    { title: "宽度", width: 60, dataIndx: "Width" },
                    { title: "高度", width: 100, dataIndx: "Height" },
                    {
                        title: "总数量", width: 100, dataIndx: "ID",
                        render: function (ui)
                        {
                            var data = ui.rowData;
                            return data["ItemCount"];
                        }
                    },
                    {
                        title: "启用数量", width: 100, dataIndx: "ID",
                        render: function (ui) {
                            var data = ui.rowData;
                            return data["EnableCount"];
                        }
                    }
                ];
                var Condition = {


                };
                PQLoadGrid("ID", this.GridID, url, colM, 20, false, Condition);
                $(this.GridID).pqGrid({
                    freezeCols: 2
                })

            },

            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
