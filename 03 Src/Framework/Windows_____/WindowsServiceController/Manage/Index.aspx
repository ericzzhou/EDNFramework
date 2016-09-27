<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WindowsServiceController.Manage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Windows 服务控制器</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                友好服务名:<asp:TextBox placeholder="请输入友好服务名" ID="txtDisplayName" runat="server"></asp:TextBox>
                <asp:Button ID="btn_search" runat="server" Text="搜索" />
                <asp:GridView ID="gvServices" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ServicesDataSource" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="gvServices_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="DisplayName" HeaderText="友好服务名" SortExpression="DisplayName" />
                        <asp:BoundField DataField="ServiceName" HeaderText="服务名" SortExpression="ServiceName" />
                        <asp:BoundField DataField="ServiceStatus" HeaderText="当前状态" SortExpression="ServiceStatus" />
                        <asp:TemplateField HeaderText="操作" SortExpression="CanStop">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("CanStop") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btnStop" runat="server" CommandName="OperationStop" CommandArgument='<%# Eval("ServiceName") %>' Text='停止' Visible='<%# Bind("CanStop") %>' BackColor="#FF3300" ForeColor="White" />
                                <asp:Button ID="btnStart" runat="server" CommandName="OperationStart" CommandArgument='<%# Eval("ServiceName") %>' Text="启动" Visible='<%# Bind("CanStart") %>' />
                                <asp:Image ID="imgLoading" runat="server" Visible='<%# Bind("ShowLoading") %>' Height="50px" ImageUrl="~/Images/loading.gif" Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ServicesDataSource" runat="server" SelectMethod="GetServices" TypeName="WindowsServiceController.Manage.Index">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDisplayName" Name="displayName" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Timer ID="timerReferee" runat="server" Interval="6000" OnTick="timerReferee_Tick"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        
    </form>
</body>
</html>
