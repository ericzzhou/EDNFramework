<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Product.Item.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="产品 > 产品维护" />

    <div class="tools_bar-inner form-inline">
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Insert()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.RowClick()">
            <i class="icon-pencil"></i>
            <span>编辑</span>
        </a>

        <a href="javascript:void(0);" class="btn" onclick="PageModel.RowDelete()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
        <input type="text" placeholder="输入产品标题" id="search_title" />
        <select id="search_type">
            <option value="0">全部产品</option>
        </select>
        <a href="javascript:void(0);" class="btn" id="btn_serach">
            <i class="icon-search"></i>
            <span>查询</span>
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
            PageModel.BindClass();
            PageModel.Bind();
            $("#btn_serach").click(function () {
                PageModel.Bind();
            });
        });

        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Product/Item.ashx?ajax='
            , ajaxUrlCategory: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Product/Category.ashx?ajax='
        };
        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getPagerData',
            data: {},
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ID");
                    _self = this;
                    window.location.href = 'edit.aspx?id=' + id;
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowDelete: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    if ($.Confirm("确定删除编号[" + id + "]的商品吗？")) {
                        $.AjaxPostCall(url.ajaxUrl + 'delete', false, { ClassID: id }, function (data) {
                            _self.RefreshGrid();
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            Delete: function (id) {
                _self = this;
                if (id && Number(id) > 0) {
                    if ($.Confirm("确定删除编号[" + id + "]的商品吗？")) {
                        $.AjaxPostCall(url.ajaxUrl + 'delete', false, { ClassID: id }, function (data) {
                            _self.RefreshGrid();
                        });
                    }
                }
            },
            Recycle: function (id) {
                _self = this;
                if (id && Number(id) > 0) {
                    if ($.Confirm("确定回收编号[" + id + "]的商品吗？")) {
                        $.AjaxPostCall(url.ajaxUrl + 'recycle', false, { ClassID: id }, function (data) {
                            _self.RefreshGrid();
                        });
                    }
                }
            },
            BindClass: function () {
                $.AjaxGet(url.ajaxUrlCategory + "getclass", false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    var helper = new bind("#search_type", data);
                    helper.bindselect("ClassName", "ClassID", "0", "全部分类", "0");
                });
            },
            Bind: function () {
                var searchCondition = {
                    ClassID: $.trim($("#search_type").val()),
                    Name: $.trim($("#search_title").val())
                };
                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    {
                        title: "操作", width: 75, dataIndx: "I.ID",
                        render: function (ui) {
                            var rowData = ui.rowData;

                            var edit = '<a class="label label-warning" href="edit.aspx?id=' + rowData["ID"] + '">编辑</a>';
                            var del = '<a class="label label-important"  href="javascript:void(0);" onclick="PageModel.Delete(' + rowData["ID"] + ')">删除</a>';
                            var recycle = '<a class="label label-success"  href="javascript:void(0);" onclick="PageModel.Recycle(' + rowData["ID"] + ')">回收</a>';
                            var html = edit + "|";
                            if (rowData["Deleted"] == true) {
                                html += recycle;
                            }
                            else {
                                html += del;
                            }
                            return html;
                        }
                    },
                    { title: "名称", width: 200, dataIndx: "PName" },
                    {
                        title: "价格", width: 70, dataIndx: "I.Price",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return "￥" + rowData["Price"];
                        }
                    },
                    {
                        title: "折扣价", width: 80, dataIndx: "I.DiscountPrice",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return "￥" + rowData["DiscountPrice"];
                        }
                    },
                    {
                        title: "创建时间", width: 130, dataIndx: "I.CreatedDate",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["CreatedDate"]
                        }
                    },
                    {
                        title: "所属类别", width: 100, dataIndx: "I.ClassID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ClassName"]
                        }

                    },
                    {
                        title: "属性", width: 200, dataIndx: "I.IsTop",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var html = "";
                            if (rowData["Deleted"] == true) {
                                html += '<span class="label label-warning">已删除</span> ';
                            }
                            if (rowData["IsHot"] == true) {
                                html += '<span class="label">热点</span> ';
                            }
                            if (rowData["IsRecomend"] == true) {
                                html += '<span class="label">推荐</span> ';
                            }
                            if (rowData["IsTop"] == true) {
                                html += '<span class="label">置顶</span> ';
                            }
                            return html;
                        }
                    }
                ];

                PQLoadGrid("I.ID", this.GridID, url, colM, 20, false, searchCondition);
                $(this.GridID).pqGrid({
                    freezeCols: 3,
                    title: "<i class=\"icon-cog\"></i>&nbsp;产品管理"
                })

            },
            Insert: function () {
                window.location.href = 'add.aspx';

            },
            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
