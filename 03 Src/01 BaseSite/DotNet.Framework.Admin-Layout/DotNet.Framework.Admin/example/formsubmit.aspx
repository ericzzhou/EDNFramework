<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="formsubmit.aspx.cs" Inherits="DotNet.Framework.Admin.example.formsubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <table id="tb_form" class="bind-valid ">
        <tr>
            <td>姓名：</td>
            <td>
                <input type="hidden" name="Id" id="Id" />
                <input type="text" name="Name" class="require" id="Name" /></td>
        </tr>
        <tr>
            <td>性别：</td>
            <td>
                <label class="radio inline">
                    <input type="radio" value="男" name="Sex" id="man" />男
                </label>
                <label class="radio inline">
                    <input type="radio" value="女" name="Sex" id="woman" />女
                </label>
            </td>
        </tr>
        <tr>
            <td>年龄：</td>
            <td>
                <input type="text" name="Age" class="require number" id="Age" /></td>
        </tr>
        <tr>
            <td>薪水：</td>
            <td>
                <input type="text" name="salary" class="decimal2" id="salary" /></td>
        </tr>
        <tr>
            <td>状态：</td>
            <td>
                <label class="checkbox inline">
                    <input type="checkbox" name="Activity" id="Activity" />激活
                                   
                </label>
            </td>
        </tr>
        <tr>
            <td>邮箱：</td>
            <td>
                <input type="text" name="email" id="email" class="require email" />
            </td>
        </tr>
        <tr>
            <td>角色：</td>
            <td>
                <select name="Role" id="Role">
                    <option value="AA">系统管理员</option>
                    <option value="BB">账号管理员</option>
                    <option value="CC">普通用户</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>头像：</td>
            <td>
                <img id="img_Photo" />
                <br /> <input type="text" name="Photo" id="Photo" />
                 <EDNFramework:Upload ID="Upload_Photo" runat="server" btnId="upload_phot" ResultTo="Photo" ResultImg="img_Photo" />
               
            </td>
        </tr>
        <tr>
            <td>备注：</td>
            <td>
                <textarea id="Remark" class="require" name="Remark"></textarea>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <input type="button" id="tb_bind" value="绑定" />
                <input type="button" id="tb_get" value="获取" />
                <input type="button" id="tb_valid" value="验证" />
            </td>
        </tr>
        <tr>
            <td>表单数据：</td>
            <td>
                <div id="formdata"></div>
            </td>
        </tr>
        <tr>
            <td>Select绑定</td>
            <td>
                <select id="SelectBind">
                </select>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <input type="button" id="bind_select" value="绑定" />
            </td>
        </tr>
        <tr>
            <td>上传控件</td>
            <td> 
                <EDNFramework:Upload ID="Upload" runat="server"  ResultTo="result1"  btnId="btn_upload1" fileId="file_upload1" />
                <input type="text" id="result1" />
                <br />
                <EDNFramework:Upload ID="Upload1" runat="server" ResultTo="result2" />
                <input type="text" id="result2" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        
        $(function(){
            var form = new bind("#tb_form");
            form.form();
            $("#tb_bind").click(function(){
                var helper = new bind("#tb_form",<%=Json_UserModel%>);
                helper.bindform(); 
            });
            $("#tb_get").click(function(){
                var helper = new bind("#tb_form");
                var data =helper.getformdata();
                $("#formdata").html(JSON.stringify(data));
            });
            $("#bind_select").click(function(){
                var helper = new bind("#SelectBind",<%=Json_Roles%>);
                helper.bindselect("Key","Value","DD","请选择","");
            });
            $("#tb_valid").click(function(){
               
                if (form.valid()) {
                    alert("验证通过");
                }
                else {
                    alert("验证失败");
                }
            });
        });
    </script>
</asp:Content>
