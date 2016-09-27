<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Articles.Item.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%=DotNet.Framework.WebTools.Editor.CreateCss()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="文章 > 文章维护" />

    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <%--  <div class="widget">
            <div class="widget-header">
                <i class="icon-book"></i>
                <h3>编辑文章</h3>
            </div>--%>

    <div class="widget-content">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#info" data-toggle="tab">基本信息</a></li>
            <li><a href="#seo" data-toggle="tab">SEO设置</a></li>
        </ul>
        <br />
        <div class="tab-content  bind-valid " id="tb_form">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="ClassID">类别</label>
                        <div class="controls">
                            <select id="ClassID" name="ClassID">
                                <option value="0">请选择</option>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">属性</label>
                        <div class="controls">
                            <label class="checkbox inline">
                                <input type="checkbox" id="State" name="State" checked="checked" />发布
                            </label>
                            <label class="checkbox inline">
                                <input type="checkbox" id="IsHot" name="IsHot" />热点
                            </label>
                            <label class="checkbox inline">
                                <input type="checkbox" id="IsRecomend" name="IsRecomend" />推荐
                            </label>
                            <label class="checkbox inline">
                                <input type="checkbox" id="IsTop" name="IsTop" />置顶
                            </label>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Sequence">权重</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="Sequence" name="Sequence" value="1" />
                            <span>输入1-99999的正整数</span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Title">标题</label>
                        <div class="controls">
                            <input type="hidden" id="ContentID" name="ContentID" value="<%=Request["id"] %>" />
                            <input type="text" class="input-medium" id="Title" name="Title" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Summary">概要</label>
                        <div class="controls">
                            <textarea id="Summary" name="Summary"></textarea>
                            <span>概要500字符以内</span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">正文</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea name="Description" style="height: 300px; width: 100%;" id="Description"></textarea>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="tab-pane form-horizontal" id="seo">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="Meta_Title">标题</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="Meta_Title" name="Meta_Title" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="SeoUrl">友好路径</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="SeoUrl" name="SeoUrl" value="" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Meta_Keywords">关键词</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="Meta_Keywords" name="Meta_Keywords" />
                        </div>
                    </div>

                    <div class="control-group">

                        <!-- Textarea -->
                        <label class="control-label">描述</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea id="Meta_Description" name="Meta_Description"> </textarea>

                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
            <div class="footer-actions taab-pane">
                <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />
                <%-- <input type="reset" class="btn" value="取消" />--%>
            </div>

        </div>
    </div>
    <%--        </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <%=DotNet.Framework.WebTools.Editor.CreateJs()%>
    <script>
        <%=DotNet.Framework.WebTools.Editor.CreateEditor("edit_Description","#Description")%>

        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Articles/Item.ashx?ajax='
            , ajaxUrlCategory: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Articles/Category.ashx?ajax='
        };

        var PageModel = {
            data: {},
            Bind: function () {
                var id = $("#ContentID").val();
                if (Number(id) > 0) {
                    $.AjaxGet(url.ajaxUrl + 'getmodel', false, { id: id }, function (d) {

                        $.RemoveButtonLoading();
                        $.RemoveBodyLoading();
                        if (id == d.ContentID) {

                            var helper = new bind("#tb_form", d);
                            helper.bindform();
                            edit_Description.html(d.Description);
                        }
                        else {
                            $.Alert("数据读取异常");
                        }
                    });
                }
                else {
                    $.Alert("数据读取异常");
                }
            },

            ApplyEvent: function () {
                _self = this;
                $("#btn_save").click(function () {
                    edit_Description.sync();
                    var helper = new bind("#tb_form");
                    var data = helper.getformdata();
                    data.Description = edit_Description.html();
                    $.AjaxPost(url.ajaxUrl + 'update', false, JSON.stringify(data));

                });
            },
            LoadContentClass: function () {
                $.AjaxGet(url.ajaxUrlCategory + "getclass", false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    for (var i = 0; i < data.length; i++) {
                        var item = eval(data[i]);
                        if (item.AllowAddContent && item.AllowAddContent == true) {
                            $("#ClassID").append("<option value=\"" + item.ClassID + "\">" + item.ClassName + "</option>")
                        }
                        else {
                            $("#ClassID").append("<optgroup label=\"" + item.ClassName + "\"></optgroup>")
                        }
                    }
                    PageModel.Bind();
                });
            },
            Init: function () {

                this.LoadContentClass();

                this.ApplyEvent();


            }
        };
        $(function () {
            //$('#Description').ckeditor();
            PageModel.Init();
        });
    </script>
</asp:Content>
