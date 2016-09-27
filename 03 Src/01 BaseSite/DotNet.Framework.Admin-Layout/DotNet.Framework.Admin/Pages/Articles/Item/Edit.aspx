<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Articles.Item.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="文章 > 文章维护" />
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
        <div class="tab-content bind-valid " id="tb_form">
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
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">正文</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea name="Description1" style="height: 300px;" id="Description"></textarea>
                            </div>
                            <div id="destest"></div>
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
             <div id="test_description"></div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

            <div class="form-actions taab-pane">
                <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />
                <input type="reset" class="btn" value="取消" />
            </div>
        </div>
    </div>
    <%--        </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/ckeditor/ckeditor.js"></script>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/ckeditor/adapters/jquery.js"></script>
    <script defer="defer">
        var editor = CKEDITOR.replace("Description");
        //var editor = CKEDITOR.replace("Description");
        var json = <%=json_Model%>
        var helper = new bind("#tb_form",json );
        

        var PageModel = {
            ApplyEvent: function () {
                _self = this;
                $("#btn_save").click(function () {
                    var data = helper.getformdata();
                    data.Description =editor.getData();;
                    $.AjaxPost('?ajax=update', true, JSON.stringify(data));

                });
            },
            LoadContentClass: function () {
                $.AjaxGet("../Category/Ajax.ashx?ajax=getclass", false, {}, function (data) {
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
                    helper.bindform();
                    editor.setData(json.Description);
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
