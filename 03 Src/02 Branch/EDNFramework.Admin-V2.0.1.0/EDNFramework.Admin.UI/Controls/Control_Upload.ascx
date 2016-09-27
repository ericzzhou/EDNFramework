<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_Upload.ascx.cs" Inherits="DotNet.Framework.Admin.UI.Controls.Control_Upload" %>
<%--<input type="file" id="<%=fileId %>" name="<%=fileId %>" />--%>
<a href="javascript:void(0);" class="icon-picture" id="<%=btnId %>" title="浏览" name="<%=btnId %>">浏览</a>
<script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery-1.7.2.min.js"></script>
<script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/ckfinder/ckfinder.js"></script>
<script>
    $(function () {
        $('#<%=btnId %>').click(function () {
            var resultToId = '<%=ResultTo %>';
            var ResultImg = '<%=ResultImg %>';
            if (!resultToId || resultToId == '' || $("#" + resultToId).length == 0) { alert("请先设置上传结果回写容器ID"); return; }

            var finder = new CKFinder();
            finder.basePath = "<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/ckfinder/";  //导入CKFinder的路径
            //设置文件被选中时的函数
            finder.selectActionFunction = function (fileUrl, data) {
                $('#' + resultToId).val(fileUrl); if (ResultImg && ResultImg != '' && $("#" + ResultImg).length > 0) { $("#" + ResultImg).attr("src", fileUrl); }
            };

            finder.popup();
        });
    });
</script>
