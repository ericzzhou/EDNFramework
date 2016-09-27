<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_FontIcons.ascx.cs" Inherits="DotNet.Framework.Admin.WebUI.Controls.Control_FontIcons" %>
<select class="form-control" id="<%=ControlID %>">
    <option value=""></option>
</select>
<script>
    $(function () {
        $("#<%=ControlID %>").change(function () {
            var select = $("#<%=ControlID %>").val();
            $("#<%=TargetID %>").val(select);
            $("#<%=ShowControlID %>").removeClass();
            $("#<%=ShowControlID %>").addClass(select);
        });
    });
</script>
