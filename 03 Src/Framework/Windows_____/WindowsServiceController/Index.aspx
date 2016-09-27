<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WindowsServiceController.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Windows 服务控制器 - 登录</title>
    <style type="text/css">
        .auto-style1 {
            width: 300px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <table class="auto-style1">
                <tr>
                    <td>用户名：</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" BorderColor="#0066CC" BorderWidth="1px" Height="20px" Width="150px" Wrap="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密&nbsp; 码：</td>
                    <td>
                        <asp:TextBox ID="txtPasswork" runat="server" BorderColor="#0066CC" BorderWidth="1px" Height="20px" Width="150px" Wrap="False" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="登录" BackColor="#3366CC" BorderColor="#FFFF99" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" Height="34px" Width="93px" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <b style="color: red;">
                            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
                        </b>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
