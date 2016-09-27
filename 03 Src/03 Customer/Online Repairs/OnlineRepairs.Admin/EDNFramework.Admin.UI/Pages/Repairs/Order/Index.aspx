<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Repairs.Order.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="报修系统 > 订单管理" />
    <div class="tools_bar-inner">


        <%--<a href="javascript:void(0);" class="btn">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>--%>
        <a href="javascript:void(0);" class="btn order_assignedTo">
            <i class="icon-pencil"></i>
            <span>任务分派</span>
        </a>
        <a href="javascript:void(0);" class="btn order_delete">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
        <a href="javascript:void(0);" class="btn order_detail">
            <i class="icon-eye-open"></i>
            <span>查看详细</span>
        </a>


    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div>
        <div id="grid_json" class="tab-content action-table ">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
            PageModel.Init();

        });
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Repairs/Order.ashx?ajax='
            , OrderDetail: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Repairs/Order/Detail.aspx?id='
            , AssignedTo: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Repairs/Order/AssignedTo.aspx?id='
        };

        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getpagerdata',
            data: {},
            Init: function () {
                var _self = this;
                $(".order_assignedTo").click(function () {
                    _self.AssignedTo();
                });
                $(".order_delete").click(function () {
                    _self.RowDelete();
                });
                $(".order_detail").click(function () {
                    _self.GoDetail();
                });
                _self.Bind();
            },
            GoDetail: function () {
                var _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    $.RemoteDialog("订单明细", url.OrderDetail + id, {
                        height: 650,
                        width: 900,
                        close: function () {
                            //alert("关闭了")
                            pqGridRefresh(_self.GridID);
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            AssignedTo: function () {
                var _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    $.RemoteDialog("订单指派", url.AssignedTo + id, {
                        height: 500,
                        width: 500,
                        close: function () {
                            //alert("关闭了")
                            pqGridRefresh(_self.GridID);
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ID");
                    var _self = this;
                    $.RemoteDialog("修改产品类别", url.editUrl + id, {
                        height: 650,
                        width: 900,
                        close: function () {
                            pqGridRefresh(_self.GridID);
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowDelete: function () {
                var _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("确定删除当前选中订单吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ID");
                        $.AjaxPostCall(url.ajaxUrl + 'delete', false, { id: id }, function (data) {
                            _self.RefreshGrid();
                        });
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
                    {
                        title: "编号", width: 60, dataIndx: "o.ID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ID"];
                        }
                    },
                    {
                        title: "客户", width: 100, dataIndx: "u.NickName",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["NickName"];
                        }
                    },

                    {
                        title: "类型", width: 100, dataIndx: "o.ComputerType",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ComputerType"];
                        }
                    },
                    {
                        title: "品牌", width: 150, dataIndx: "b.Name",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["BrandName"];
                        }
                    },
                    {
                        title: "型号", width: 150, dataIndx: "o.Model",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["Model"];
                        }
                    },
                    {
                        title: "订单状态", width: 100, align: "center", dataIndx: "o.Statu",
                        render: function (ui) {
                            //WHEN 0 THEN '订单创建'
                            //WHEN 1 THEN '系统确认'
                            //WHEN 2 THEN '已经分派'
                            //WHEN 3 THEN '工作完成'
                            //WHEN 4 THEN '订单完成'
                            //WHEN 5 THEN '已经关闭'
                            var rowData = ui.rowData;
                            var value = rowData["Statu"];
                            var retStr = '';
                            switch (value) {
                                case 0: retStr = '订单创建'; break;
                                case 1: retStr = '系统确认'; break;
                                case 2: retStr = '已经分派'; break;
                                case 3: retStr = '工作完成'; break;
                                case 4: retStr = '订单完成'; break;
                                case 5: retStr = '已经关闭'; break;
                                default:

                            }
                            return retStr;

                        }
                    },

                    {
                        title: "操作", width: 200, dataIndx: "o.ID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ID"];
                        }
                    }
                ];
                PQLoadGrid("o.ID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 3
                })

            },

            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
