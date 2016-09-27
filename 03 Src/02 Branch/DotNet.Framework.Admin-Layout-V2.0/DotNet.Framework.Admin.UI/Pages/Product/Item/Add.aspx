<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Product.Item.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%=DotNet.Framework.WebTools.Editor.CreateCss()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="产品 > 添加产品" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div class="widget-content">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#info" data-toggle="tab">基本信息</a></li>
            <li><a href="#seo" data-toggle="tab">SEO设置</a></li>
        </ul>
        <br />
        <div class="tab-content bind-valid" id="tb_form">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="ClassID">类别</label>
                        <div class="controls">
                            <select id="ClassID" name="ClassID" class="require">
                                <option value="0">请选择</option>
                            </select>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">属性</label>
                        <div class="controls">
                            <label class="checkbox inline">
                                <input type="checkbox" id="Deleted" name="Deleted" />删除
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
                        <label class="control-label" for="PName">产品名称</label>
                        <div class="controls">
                            <input type="text" class="input-medium require" id="PName" name="PName" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Price">产品价格</label>
                        <div class="controls">
                            <input type="text" class="input-medium require" id="Price" name="Price" value="0" />
                            折扣价
                            <input type="text" class="input-medium decimal2" id="DiscountPrice" name="DiscountPrice" value="0" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="ImageUrl">产品图片</label>
                        <div class="controls">
                            <input type="text" class="input-medium require" id="ImageUrl" name="ImageUrl" disabled="disabled" />
                            <EDNFramework:Upload ID="upload_img" runat="server" btnId="upload_img" ResultTo="ImageUrl" />
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
                        <label class="control-label">产品描述</label>
                        <div class="controls">
                            <textarea name="Description" style="height: 300px;width:100%;" id="Description"></textarea>
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
                <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="新增" />
                <%--<input type="reset" class="btn" value="取消" />--%>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
<%=DotNet.Framework.WebTools.Editor.CreateJs()%>  
        <script>
 <%=DotNet.Framework.WebTools.Editor.CreateEditor("edit_Description","#Description")%>

        $(function () {
            PageModel.Init();
        });

        var PageModel = {
            ApplyEvent: function () {
                var form = new bind("#tb_form");
                form.form();
                $("#btn_save").click(function () {
                    edit_Description.sync();
                    var data = form.getformdata();
                    data.Description = edit_Description.html();;
                    if (form.valid()) {
                        $.AjaxPost('?ajax=add', true, JSON.stringify(data));
                    }
                    else {
                        alert("验证失败");
                    }
                });
            },
            LoadContentClass: function () {
                $.AjaxGet("../Category/Ajax.ashx?ajax=getclass", false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    var helper = new bind("#ClassID", data);
                    helper.bindselect("ClassName", "ClassID", "0", "请选择分类", "0");
                });
            },
            Init: function () {
                //

                this.LoadContentClass();
                this.ApplyEvent();

            }
        };
    </script>

</asp:Content>
