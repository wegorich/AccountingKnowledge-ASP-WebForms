<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="AKSite.UserControl.Search" %>
<%@ Register Src="~/UserControl/Button.ascx" TagName="Button" TagPrefix="bt" %>
<div class="search">
    <bt:Button ID="btn" runat="server" OnClick="ClickButton" ValidationGroup="search"  />
    <asp:TextBox ID="input" runat="server" MaxLength="500" ValidationGroup="search" />
</div>
