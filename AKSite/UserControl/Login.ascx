<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="AKSite.UserControl.Login" %>
<%@ Register Src="~/UserControl/TextBox.ascx" TagName="TextBox" TagPrefix="txt" %>
<div>
    <txt:TextBox ID="loginBlock" runat="server" Title="Имя пользователя:" MaxLength="50" ValidatorText="Уажите имя пользователя"
        SkinID="LoginInput" />
    <asp:RegularExpressionValidator ID="loginRegExpValidator" runat="server" ControlToValidate="loginBlock"
        ValidationExpression="^[a-zA-Z0-9]{3,25}$" Text="Некорректное имя пользователя"
        Display="Dynamic" ForeColor="Red" 
        meta:resourcekey="loginRegExpValidatorResource1" />
</div>
<br />
<div>
    <txt:TextBox ID="passBlock" runat="server" Title="Пароль:" TextMode="Password" MaxLength="50" ValidatorText="Укажите пароль"
        SkinID="LoginInput" />
    <asp:RegularExpressionValidator ID="passRegExValidator" runat="server" ControlToValidate="passBlock"
        Text="Слишком короткий пароль" Display="Dynamic" ForeColor="Red" 
        ValidationExpression="[a-zA-z0-9._-]{6,}" 
        meta:resourcekey="passRegExValidatorResource1" />
</div>
