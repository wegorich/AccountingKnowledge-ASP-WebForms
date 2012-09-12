<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeBehind="Report.aspx.cs" Inherits="AKSite.Admin.Report" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="pageTitle" ContentPlaceHolderID="adminTitle" runat="server">
    Отчеты
</asp:Content>
<asp:Content ID="pageContent" ContentPlaceHolderID="adminCont" runat="server">
<div id="title">
    <asp:Label ID="lblTitle" runat="server" meta:resourcekey="lblTitleResource1" ><b>Выберите отчет</b></asp:Label></div>
    <asp:Menu ID="reportMenu" CssClass="itemList" runat="server" 
        RenderingMode="Table" StaticMenuItemStyle-CssClass="reportOneItem" 
        StaticHoverStyle-CssClass="alt" meta:resourcekey="reportMenuResource1">
        <Items>
            <asp:MenuItem NavigateUrl="client.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет клиентов" 
                meta:resourcekey="MenuItemResource1"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="resume.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет резюме" 
                meta:resourcekey="MenuItemResource2"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="resumetheme.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет тем резюме" 
                meta:resourcekey="MenuItemResource3"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="theme.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет тем" 
                meta:resourcekey="MenuItemResource4"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="field.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет областей знаний" 
                meta:resourcekey="MenuItemResource5"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="skillgroup.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет груп навыков" 
                meta:resourcekey="MenuItemResource6"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="skill.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет навыков" 
                meta:resourcekey="MenuItemResource7"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="database.xmlrep" 
                ImageUrl="~/App_Themes/Main/img/xml.png" Text="Отчет всей базы" 
                meta:resourcekey="MenuItemResource8"></asp:MenuItem>
        </Items>

<StaticHoverStyle CssClass="alt"></StaticHoverStyle>

<StaticMenuItemStyle CssClass="reportOneItem"></StaticMenuItemStyle>
    </asp:Menu>
</asp:Content>
