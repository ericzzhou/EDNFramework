<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Repairs.Brand.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="报修系统 > 品牌添加" />
    <div class="" id="tb_form">
        <br />
        <div class="tab-content">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>

                    <div class="control-group">
                        <label class="control-label" for="Name">品牌名称</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="Name" name="Name" value="" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label">品牌描述</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea class="" id="Descriptino" name="Descriptino"></textarea>
                                <p class="help-block">描述250字符以内</p>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
        </div>
    </div>
    <div class="footer-actions taab-pane">
        <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="新增" />
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Repairs/Brand.ashx?ajax='
        };
        $(function () {
            PageModel.Init();
        });

        var PageModel = {
            Init: function () {
                _self = this;
                $("#btn_Insert").click(function () {
                    var form = new bind("#tb_form");
                    $.AjaxPost(url.ajaxUrl + 'add', false, JSON.stringify(form.getformdata()));

                });
            }
        };
    </script>
</asp:Content>
