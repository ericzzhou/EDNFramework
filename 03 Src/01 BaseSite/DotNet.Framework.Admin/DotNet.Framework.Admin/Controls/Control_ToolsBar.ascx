<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_ToolsBar.ascx.cs" Inherits="DotNet.Framework.Admin.Controls.Control_ToolsBar" %>
<div class="tools_bar">
    <div class="tools_bar-inner">
        <%--<div class="container">--%>
            <ul class="tools_bar-container">
                <li>
                    <%--<a href="javascript:void(0);" onclick="<%=Refresh_Fun %>">
                        <i class="icon-refresh"></i>
                        <span>刷新</span>
                    </a>--%>

                    <%--<div class="tools_separator"></div>--%>
                    <a href="javascript:void(0);" style="display: <%=disable_Insert==true?"none":"" %>" onclick="<%=Insert_Fun %>">
                        <i class="icon-plus-sign"></i>
                        <span>新增</span>
                    </a>
                    <a href="javascript:void(0);" style="display: <%=disable_Modify==true?"none":"" %>" onclick="<%=Modify_Fun %>">
                        <i class="icon-pencil"></i>
                        <span>编辑</span>
                    </a>

                    <a href="javascript:void(0);" style="display: <%=disable_Delete==true?"none":"" %>" onclick="<%=Delete_Fun %>">
                        <i class="icon-minus-sign"></i>
                        <span>删除</span>
                    </a>

                    <a href="javascript:void(0);" style="display: <%=disable_Clear==true?"none":"" %>" onclick="<%=Clear_Fun %>">
                        <i class="icon-minus-sign"></i>
                        <span>清除</span>
                    </a>
                    <%-- <div class="tools_separator"></div>--%>

                    <a href="javascript:void(0);" style="display: <%=disable_Detail==true?"none":"" %>" onclick="<%=Detail_Fun %>">
                        <i class="icon-eye-open"></i>
                        <span>查看详细</span>
                    </a>
                    <a href="javascript:void(0);" onclick="<%=Leave_Fun %>">
                        <i class="icon-arrow-left"></i><%--icon-share-alt--%>
                        <span>返回</span>
                    </a>
                </li>
            </ul>
       <%-- </div>--%>
    </div>
</div>
<script>
    function ToolsBar_Fun_Leave() {
        history.go(-1);
    }
    function ToolsBar_Fun_Unrealized() {
        alert("建设中，该操作暂未实现...")
    }
</script>

