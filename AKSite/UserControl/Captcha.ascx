<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Captcha.ascx.cs" Inherits="AKSite.UserControl.Captcha" %>
<%@ Register Src="~/UserControl/TextBox.ascx" TagName="TextBox" TagPrefix="txt" %>
<asp:CustomValidator ID="custValidator" runat="server" Text="*" 
    ErrorMessage="Дорогой пользователь, ты неправильно ввел капчу"
    Display="Dynamic" 
    OnServerValidate="CustValidatorServerValidate" 
    ForeColor="Red" meta:resourcekey="custValidatorResource1"></asp:CustomValidator>
<div>
    <txt:TextBox Id="txtBox" runat="server" MaxLength="100"
        ValidatorText="Дорогой пользователь, капча не может быть пустой"
        Description="Мы должны убедиться, что вы не робот" 
        Title="Введите код с картинки:" />
    <asp:Image ID="img" runat="server" src="def.igen" 
        meta:resourcekey="imgResource1" />
</div>
