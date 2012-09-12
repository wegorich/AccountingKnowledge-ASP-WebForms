<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AKSite.Account.Default" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="pageTitle" ContentPlaceHolderID="title" runat="server">
    Авторизация
</asp:Content>
<asp:Content ID="pageCont" ContentPlaceHolderID="cont" runat="server">
    <div id="title">
        <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1"><b>Вход на сайт: </b>
        <br />
        Пожалуйста, заполните поля ниже. Это нужно сделать обязательно, иначе ничего не
        получится.</asp:Label>
    </div>
    <br />
    <asp:CustomValidator ID="loginCustValidator" runat="server" Display="Dynamic" ForeColor="Red"
        OnServerValidate="CustValidatorServerValidate" ErrorMessage="<p>Неверный логин или пароль</p>"
        meta:resourcekey="loginCustValidatorResource1" />
    <div>
        <we:Login ID="login" runat="server" />
        <br />
        <we:Button ID="send" runat="server" OnClick="SendClick" Width="100" Text="Войти" />
    </div>
    <br />
    <asp:Label ID="lblRemind" runat="server" meta:resourcekey="lblRemindResource1"></asp:Label>
    <br />
    <asp:Label ID="lblRegister" runat="server" meta:resourcekey="lblRegisterResource1">Если вы по каким-то причинам не зарегистрированы, то можете <a href="Register.aspx">сделать это прямо сейчас.</a></asp:Label>
</asp:Content>
