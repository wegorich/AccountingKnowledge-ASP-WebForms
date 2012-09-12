<%@ Page Title="" Language="C#" MasterPageFile="~/Search/Search.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AKSite.Search.Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ OutputCache CacheProfile="CacheMain" %>
<asp:Content ID="pageTitle" ContentPlaceHolderID="searchTitle" runat="server">
    Поиск по базе
</asp:Content>
<asp:Content ID="pageContent" ContentPlaceHolderID="searchCont" runat="server">
    <asp:ObjectDataSource ID="searchData" runat="server" SelectMethod="Search" TypeName="BusinessLogic.ResumeService"
        OnSelecting="ResumeDataSelecting">
        <SelectParameters>
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="searchStrategy" Type="Object" />
            <asp:Parameter Name="startAge" Type="Int32" />
            <asp:Parameter Name="endAge" Type="Int32" />
            <asp:Parameter Name="sortExpression" Type="String" />
            <asp:Parameter Name="sortDirection" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div id="someContent">
        <asp:PlaceHolder ID="searchPlaceHolder" runat="server">
            <asp:ListView ID="result" runat="server" DataSourceID="searchData">
                <LayoutTemplate>
                    <table class="itemList" cellpadding="0" cellspacing="0">
                        <tbody>
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
            <we:DataPager ID="pager" runat="server" PageSize="20" QueryString="page" PagedControlId="result" OnPreRender="SearchResultPreRender" />
        </asp:PlaceHolder>
    </div>
</asp:Content>
