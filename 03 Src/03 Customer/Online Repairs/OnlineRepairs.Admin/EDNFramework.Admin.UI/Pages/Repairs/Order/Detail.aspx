<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Repairs.Order.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="报修系统 > 订单明细" />
    <%--<div class="container">
        <div class="widget">--%>
    <%--<div class="widget-header">
        <i class="icon-error"></i>
        <h3>异常信息</h3>
    </div>--%>
    <div class="widget-content">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#info" data-toggle="tab">订单信息</a></li>
            <li><a href="#seo" data-toggle="tab">订单进度</a></li>
            <li><a href="#Contact" data-toggle="tab">联系信息</a></li>
        </ul>
        <br />
        <div class="tab-content">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>
                    <table class="table table-striped table-bordered table-hover">
                        <tr>

                            <td style="width: 65px;">订单编号：</td>
                            <td><%=order.ID %></td>
                        </tr>
                        <tr>

                            <td>内部编号：</td>
                            <td><%=order.OrderNumber %></td>
                        </tr>
                        <tr>

                            <td>客户：</td>
                            <td><%=order.UserName%></td>
                        </tr>
                        <tr>

                            <td>电脑类型：</td>
                            <td>
                                <%if (order.ComputerType == 0)
                                  {%>
                                      台式机
                                  <%}
                                  if (order.ComputerType == 1)
                                  {%>
                                      笔记本
                                  <%} %>
                            </td>
                        </tr>
                        <tr>

                            <td>电脑品牌：</td>
                            <td><%=order.BrandName %></td>
                        </tr>
                        <tr>

                            <td>电脑型号：</td>
                            <td><%=order.Model %></td>
                        </tr>
                        <tr>

                            <td>故障描述：</td>
                            <td><%=order.RepairsDescription %></td>
                        </tr>
                        <tr>

                            <td>订单状态：</td>
                            <td><%switch (order.Statu)
                                  {
                                      case 0:
                            %> 订单创建 <%
                                          break;
                                      case 1:
                            %> 系统确认 <%
                                          break;
                                      case 2:
                            %> 已经分派 <%
                                          break;
                                      case 3:
                            %> 工作完成 <%
                                          break;
                                      case 4:
                            %> 订单完成 <%
                                          break;
                                      case 5:
                            %> 关闭 <%
                                          break;
                                      case -1:
                            %> 删除<%
                                          break;
                                      default: 
                            %>不详<%
                                          break;
                                  }  %>（<%=order.ModifyTime %>）<%if (order.Statu == 2)
                                                                 {%>
                                                                                - <%=order.AssignedToUser %>
                                <% } %></td>
                        </tr>
                        <tr>

                            <td>备注信息：</td>
                            <td><%=order.Remark %></td>
                        </tr>

                    </table>
                </fieldset>
            </div>
            <div class="tab-pane form-horizontal" id="seo">
                <fieldset>

                    <table class="table table-striped table-bordered table-hover">
                        <%
                            if (histories.Count <= 0)
                            {%>
                        <tr>
                            <td>该订单暂无进度</td>
                        </tr>
                        <%}
                            else
                            {
                                foreach (var item in histories)
                                {%>
                        <tr>
                            <td  style="width: 130px;"><%=item.CreateTime %></td>
                            <td><%=item.Note %></td>
                        </tr>
                        <% }

                            }%>
                    </table>
                </fieldset>
            </div>
            <div class="tab-pane form-horizontal" id="Contact">
                <fieldset>
                    <table class="table table-striped table-bordered table-hover">
                        <tr>
                            <td  style="width: 65px;">联系人：</td>
                            <td><%=contact.ContactsName %></td>
                        </tr>
                        <tr>

                            <td>联系电话：</td>
                            <td><%=contact.ContactsMobile %></td>
                        </tr>
                        <tr>

                            <td>联系地址：</td>
                            <td><%=contact.ContactsAddress %></td>
                        </tr>

                    </table>

                </fieldset>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

            <div class="footer-actions taab-pane">

                <input type="button" class="btn" id="btn_Back" value="返回" />
            </div>
        </div>
    </div>
    <%--  </div>
   </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var orderInfo = <%=OrderInfoJson%>
        $(function () {
            //PageModel.Init();
            //PageModel.AppendEvent();
        });
    </script>
</asp:Content>
