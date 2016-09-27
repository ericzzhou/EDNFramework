<%@ Page Title="" Language="C#" MasterPageFile="../../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.Slide.Item.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="其他 > 轮播幻灯片" />
    <div class="tools_bar-inner  form-inline">
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Insert()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Edit()">
            <i class="icon-pencil"></i>
            <span>编辑</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Delete()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
        <select id="group" name="group">
        </select>
        <a href="javascript:void(0);" class="btn" id="btn_search">
            <i class="icon-search"></i>
            <span>查询</span>
        </a>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table "></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var  requestGroup = '<%=Request["groupid"]%>';
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Other/Slide.ashx?ajax='
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/Slide/Item/Edit.aspx?id='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/Slide/item/Add.aspx'
        };
        $(document).ready(function () {
            PageModel.Init();
        });
        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl+ 'getitempagerdata',
            Init: function () {
                var helper = new bind("#group",<%=json_group%>);
               
                helper.bindselect("Name","ID",requestGroup,"查看全部","0");
               
                PageModel.Bind();
                $("#btn_search").click(function(){
                    PageModel.Bind();
                });
                
            },
            Insert:function(){
                _self = this;
                $.RemoteDialog("添加幻灯片",url.addUrl, {
                    height: 550,
                    width: 500,
                    close: function () {
                        //alert("关闭了")
                        _self.RefreshGrid();
                    }
                });
            },
            Edit:function(){
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    $.RemoteDialog("编辑幻灯片", url.editUrl + id, {
                        height: 550,
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
            Delete:function(){
                var  _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    if ($.confirm("删除后不可恢复，确定继续吗？")) {
                        //删除
                        $.AjaxPost(url.ajaxUrl+ 'deleteitem&id='+id, false,null);
                        _self.RefreshGrid();
                        
                    }
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
                    { title: "编号", width: 60, dataIndx: "SI.ID",
                        render:function(ui)
                        {
                            var row = ui.rowData;
                            return row["ID"];
                        }
                    },
                    { title: "名称", width: 200, dataIndx: "SI.Name",
                        render:function(ui){
                            var row = ui.rowData;
                            return row["Name"];
                        }
                    },
                    { title: "组", width: 200, dataIndx: "SI.SlideID",
                        render:function(ui)
                        {
                            var row = ui.rowData;
                            if (!row["GroupName"] ||row["GroupName"] == "") {
                                return "[未知]";
                            }
                            else
                                return row["GroupName"];
                        }
                    },
                    { title: "链接", width: 250, dataIndx: "Href" },
                    { title: "文件", width: 250, dataIndx: "FilePath" },
                    { title: "启用", width: 60, dataIndx: "Enable" },
                    { title: "排序", width: 60, dataIndx: "sequence" }
                ];
                var Condition = {
                    GroupID: $("#group").val()
                };
                PQLoadGrid("SI.ID", this.GridID, url, colM, 20, false, Condition);
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
