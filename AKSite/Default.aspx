<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AKSite.Default" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<asp:Content ID="pageTitle" ContentPlaceHolderID="title" runat="server">
    Страничка приветствия
</asp:Content>
<asp:Content ID="pageContet" ContentPlaceHolderID="cont" runat="server">
    <div id="title">
        <asp:Image ID="siteImage" runat="server" ImageUrl="~/App_Themes/Main/img/siteLogo.png"
            AlternateText="Account knowledge" meta:resourcekey="siteImageResource1" />
    </div>
    <div style="margin: 15px; font-size: 120%; color: #808080;">
        <asp:Label ID="lblTitleText" runat="server" meta:resourcekey="lblTitleTextResource1">    У нас на сайте зарегистрированно 
    более</asp:Label>&nbsp;<b><%= BusinessLogic.ClientService.Count() %></b></div>
    <div style="margin: 15px">
        <asp:Label ID="lblSiteDescription" runat="server" meta:resourcekey="lblSiteDescriptionResource1">
Здесь вы сможете, создать и разместить свои резюме. <br />
Наши менеджеры по персоналу постоянно отслеживают новые резюме, и отбирают персонал.<br />
Ваше резюме - это первый шаг на пути, карьерного роста и турдоустройства в нашу компанию.
        </asp:Label>
    </div>
    <div style="margin: 15px">
        <asp:Label ID="lblEndPart" runat="server" meta:resourcekey="lblEndPartResource1">
        Уже сейчас на сайте размещенно более <b><%= BusinessLogic.ResumeService.Count() %></b> резюме. И их колличество постоянно растет...
        Присоединяйтесь, для этого вам необходимо зарегистрироваться.
        </asp:Label>
    </div>
</asp:Content>
