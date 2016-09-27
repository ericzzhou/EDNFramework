<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Articles.Item.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%=DotNet.Framework.WebTools.Editor.CreateCss()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="文章 > 添加文章" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div class="widget-content">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#info" data-toggle="tab">基本信息</a></li>
            <li><a href="#seo" data-toggle="tab">SEO设置</a></li>
        </ul>
        <br />
        <div class="tab-content">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="ClassID">类别</label>
                        <div class="controls">
                            <select id="ClassID">
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


        </div>
        <div class="footer-actions taab-pane">
            <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="新增" />
            <%-- <input type="reset" class="btn" value="取消" />--%>
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
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Articles/Item.ashx?ajax='
            , ajaxUrlCategory: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Articles/Category.ashx?ajax='
        };

        var PageModel = {
            data: {},
            LoadData: function () {
                _self = this;

                _self.data.ClassID = $("#ClassID").val();
                _self.data.State = $("#State").is(':checked');
                _self.data.IsHot = $("#IsHot").is(':checked');
                _self.data.IsRecomend = $("#IsRecomend").is(':checked');
                _self.data.IsTop = $("#IsTop").is(':checked');
                _self.data.Sequence = $("#Sequence").val();
                _self.data.Title = $("#Title").val();
                _self.data.Summary = $("#Summary").val();
                _self.data.Description = edit_Description.html();
                _self.data.Meta_Title = $("#Meta_Title").val();
                _self.data.SeoUrl = $("#SeoUrl").val();
                _self.data.Meta_Keywords = $("#Meta_Keywords").val();
                _self.data.Meta_Description = $("#Meta_Description").val();
            },
            ApplyEvent: function () {
                _self = this;
                $("#btn_Insert").click(function () {
                    edit_Description.sync();
                    _self.LoadData();
                    $.AjaxPost(url.ajaxUrl + 'add', false, JSON.stringify(_self.data));

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
                });
            },
            Init: function () {
                this.LoadContentClass();
                this.ApplyEvent();

            }
        };
    </script>
</asp:Content>
