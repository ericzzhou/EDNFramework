<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Articles.Category.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="文章 > 类别维护" />

   <%-- <div class="widget">
        <div class="widget-header">
            <i class="icon-user"></i>
            <h3>类别修改</h3>
        </div>--%>

        <div class="widget-content">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#info" data-toggle="tab">类别信息</a></li>
                <li><a href="#seo" data-toggle="tab">SEO设置</a></li>
            </ul>
            <br />
            <div class="tab-content">
                <div class="tab-pane active form-horizontal" id="info">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="lastname">类别类型</label>
                            <div class="controls">
                                <select id="ClassTypeID">
                                    <option value="0">根级别</option>
                                </select>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="ClassName">类别名称</label>
                            <div class="controls">
                                <input type="hidden" id="ClassID" name="ClassID" value="<%=Request["ClassID"] %>" />
                                <input type="text" class="input-medium" id="ClassName" name="ClassName" value="" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="Sequence">类别权重</label>
                            <div class="controls">
                                <input type="text" class="input-medium" placeholder="请输入正确的数字" id="Sequence" name="Sequence" value="0" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="email">状态</label>
                            <div class="controls">
                                <label class="checkbox inline">
                                    <input value="是" type="checkbox" id="State" name="State" />显示
                                </label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="email">发布文章</label>
                            <div class="controls">
                                <label class="checkbox inline">
                                    <input value="是" type="checkbox" id="AllowAddContent" name="AllowAddContent" checked="checked" />允许
                                </label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">类别描述</label>
                            <div class="controls">
                                <div class="textarea">
                                    <textarea class="" id="Description" name="Description"> </textarea>
                                    <p class="help-block">类别描述250字符以内</p>
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
                                <input type="text" class="input-medium" id="Meta_Title" name="Meta_Title" value="" />
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
                                <input type="text" class="input-medium" id="Meta_Keywords" name="Meta_Keywords" value="" />
                            </div>
                        </div>

                        <div class="control-group">

                            <!-- Textarea -->
                            <label class="control-label">描述</label>
                            <div class="controls">
                                <div class="textarea">
                                    <textarea class="" id="Meta_Description" name="Meta_Description"> </textarea>

                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

                <div class="form-actions taab-pane">
                    <input type="button" id="btn_Update" class="btn btn-primary btn-loading " value="保存" />
                    <input type="reset" class="btn" value="取消" />
                </div>
            </div>
     </div>
     <%--  </div>--%>
</asp:Content>
