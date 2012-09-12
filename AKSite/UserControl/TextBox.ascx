<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextBox.ascx.cs"
    Inherits="AKSite.UserControl.TextBox" %>
<div id="inputTextBlockDiv">
    <label ID="blockTitle" runat="server" style="font-weight: bold; font-size: small" />
    <asp:TextBox ID ="blockInput" runat="server" 
        meta:resourcekey="blockInputResource1" />
    <div ID="blockDescription" runat="server"  style="font-size: smaller; color: #9A9A9A" />
    <asp:RequiredFieldValidator ID="reqValidator" runat="server" Text="*" 
              ControlToValidate="blockInput" Display="Dynamic" ForeColor="Red" 
            meta:resourcekey="reqValidatorResource1" />
</div>
