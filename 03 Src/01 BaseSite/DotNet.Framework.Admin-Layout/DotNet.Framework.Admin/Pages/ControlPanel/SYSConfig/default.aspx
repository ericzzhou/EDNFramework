<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.ControlPanel.SYSConfig._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="控制面板 > 系统设定" />
    <EDNFramework:ToolsBar ID="ToolsBar" runat="server" disable_Detail="true" Insert_Fun="PageModel.Insert()" Modify_Fun="PageModel.RowClick()" Delete_Fun="PageModel.RowDelete()" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table "></div>
    <div class="container">
        <div class="modal hide fade" id="EditModal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h3>对话框标题</h3>
            </div>
            <div class="modal-body">
                <div class="tab-content">
                    <div class="tab-pane active form-horizontal" id="info">


                        <div class="control-group">
                            <label class="control-label" for="Keyname">项目</label>
                            <div class="controls">
                                <input type="hidden" id="ID" name="ID" />
                                <input type="text" class="input-medium" id="Keyname" name="Keyname" value="" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="Value">值</label>
                            <div class="controls">
                                <input type="text" class="input-medium" id="Value" name="Value" value="0" />
                            </div>
                        </div>


                        <div class="control-group">
                            <label class="control-label">描述</label>
                            <div class="controls">
                                <div class="textarea">
                                    <textarea class="" id="Description" name="Description"> </textarea>
                                    <p class="help-block">描述250字符以内</p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

                </div>
            </div>
            <div class="modal-footer">

                <input type="button" class="btn btn-modal-close" value="关闭" />
                <input type="button" value="保存" class="btn btn-primary btn-modal-save" />

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>




        $(document).ready(function () {
            PageModel.Bind();
            PageModel.AppendEvent();

        });


        var tbl;
        var PageModel = {
            GridID: '#grid_json',
            ModalID: 'EditModal',
            pqsAjaxSource: 'default.aspx?ajax=getPagerData',
            data: {},
            SetModalTitle: function (title) {
                _self = this;
                $('#' + _self.ModalID + " h3").html(title);
            },
            RowClick: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var rowJson = GetPgGridRowData(_self.GridID);
                    $("#ID").val(rowJson.ID);
                    $("#Keyname").val(rowJson.Keyname);
                    $("#Value").val(rowJson.Value);
                    $("#Description").val(rowJson.Description);

                    $("#Keyname").attr("disabled", "disabled");
                    _self.SetModalTitle("编辑");
                    $('#' + _self.ModalID).modal('show');
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowDelete: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("删除后不可恢复，确定继续吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ID");
                        $.AjaxPostCall('?ajax=deletemodel', true, { ID: id }, function (data) {
                            if (data.result && data.result.error) {
                                $.RemoveBodyLoading();
                                $.RemoveButtonLoading();
                                $.AlertAutoClose(data.result.error);
                            }
                            else {
                                _self.RefreshGrid();
                            }
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },

            LoadData: function () {
                this.data.ID = $("#ID").val();
                this.data.Keyname = $("#Keyname").val();
                this.data.Value = $("#Value").val();
                this.data.Description = $("#Description").val();
            },
            ClearData: function () {
                this.data = {};
                $("#ID").val('');
                $("#Keyname").val('');
                $("#Value").val('');
                $("#Description").val('');
            },
            EditData: function () {
                $.AjaxPost('?ajax=editdata', true, this.data);

            },
            AddData: function () {
                $.AjaxPost('?ajax=adddata', true, this.data);

            },
            AppendEvent: function () {
                _self = this;
                $(".btn-modal-close").click(function () {
                    _self.ClearData();
                    $('#' + _self.ModalID).modal('hide');
                    _self.RefreshGrid();
                    $.HideMessage();
                });

                $("#btn_add").click(function () {
                    _self.Insert();
                });

                //保存
                $(".btn-modal-save").click(function () {
                    _self.LoadData();
                    if (_self.data.ID && _self.data.ID > 0) {
                        //编辑
                        _self.EditData();
                    }
                    else {
                        //新增
                        _self.AddData();
                    }
                });
            },
            Bind: function () {
                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "ID" },
                    { title: "项目", width: 250, dataIndx: "Keyname" },
                    { title: "值", width: 350, dataIndx: "Value" },
                    { title: "描述", width: 300, dataIndx: "Description" }
                ];
                PQLoadGrid("ID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 2,
                    title: "<i class=\"icon-cog\"></i>&nbsp;系统设定"
                })

            },
            Insert: function () {
                this.ClearData();
                this.SetModalTitle("添加");
                $("#Keyname").removeAttr("disabled");
                $('#' + this.ModalID).modal('show');
            },
            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
