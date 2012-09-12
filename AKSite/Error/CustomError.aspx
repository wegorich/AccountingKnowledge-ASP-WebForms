<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="CustomError.aspx.cs" Inherits="AKSite.Error.CustomError" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="pageTitle" ContentPlaceHolderID="title" runat="server">
    Опаньки ошибочка
</asp:Content>
<asp:Content ID="pageContent" ContentPlaceHolderID="cont" runat="server">
    <div id="title">
        <b>
            <asp:Label ID="titleErorr" runat="server" 
            meta:resourcekey="titleErorrResource1" />
        </b>
    </div>
    <div class="errorPageContent">
        <asp:Image ID="img" AlternateText="ErrorRobot" ImageAlign="Right" ImageUrl="~/App_Themes/Main/img/errorImage.png"
            runat="server" meta:resourcekey="imgResource1" />
            <div>
            <a href="../Default.aspx">
                <img src="../App_Themes/Main/img/siteLogo.png" alt="Accounting Knowledge">
            </a>
        </div>
        <div class="errorDescription">
            <asp:Label ID="descriptionError" runat="server" 
                meta:resourcekey="descriptionErrorResource1"></asp:Label>
        </div>
        
    </div>
</asp:Content>
