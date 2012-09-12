<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumeView.ascx.cs"
    Inherits="AKSite.UserControl.ResumeView" %>
<%@ Import Namespace="BusinessLogic" %>
<%@ Import Namespace="Model" %>
<asp:Repeater ID="resume" runat="server">
    <ItemTemplate>
        <table class="itemList preview" cellpadding="0" cellspacing="0">
            <tbody>
                <tr class="resumeOneItem">
                    <td colspan="2">
                        <a class="caption" href="<%# ResumePage %>?resume=<%# Eval("Id") %>">
                            <%# Eval("Title") %></a>
                    </td>
                    <td class="time">
                        <%# Eval("Date") %>
                    </td>
                </tr>
                <tr class="resumeOneItem">
                    <td class="info">
                        <div class="name">
                            <%# ((Client)Eval("Client")).FirstName%>
                            <%# ((Client)Eval("Client")).SecondName %></div>
                        <div>
                            <%# ClientService.GetAge(((Client)Eval("Client")).BirthDay)%>
                        </div>
                    </td>
                    <td>
                        <a href='#'>
                            <%# ((Client)Eval("Client")).Email %>
                        </a>
                    </td>
                    <td class="theme">
                        <asp:Repeater ID="fields" runat="server" DataSource='<%# Eval("Fields") %>'>
                            <ItemTemplate>
                                <div>
                                    <%# Eval("FieldName") %>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr class="resumeOneItem">
                    <td colspan="3">
                        <div class="descr">
                            <%# Eval("Description") %>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </ItemTemplate>
</asp:Repeater>
