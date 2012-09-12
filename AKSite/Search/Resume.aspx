<%@ Page Title="" Language="C#" MasterPageFile="~/Search/Search.master" AutoEventWireup="true"
    CodeBehind="Resume.aspx.cs" Inherits="AKSite.Search.Resume" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ OutputCache CacheProfile="CacheMain" %>
<asp:Content ID="pageTitle" ContentPlaceHolderID="searchTitle" runat="server">
    Пользовательское резюме
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="searchCont" runat="server">
    <div id="someContent">
        <asp:PlaceHolder ID="resumePlaceHolder" runat="server" OnPreRender="ResumeResultPreRender">
            <we:ResumeShow ID="someResume" runat="server" />
            <div style="border-style: solid none none none; border-top-width: thin; border-color: #DAE1E8">
            </div>
            <asp:ListView ID="resumes" runat="server" DataKeyNames="Id">
                <LayoutTemplate>
                    <table class="itemList" cellpadding="0" cellspacing="0">
                        <tbody>
                            <th>
                                <asp:Label ID="lblTitle" runat="server" Text="Другие резюме пользователя"></asp:Label>
                            </th>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <we:ResumeView ID="view" ResumePage="Resume.aspx" DataSource='<%# Container.DataItem %>'
                                runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </asp:PlaceHolder>
    </div>
</asp:Content>
