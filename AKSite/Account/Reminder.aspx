<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Reminder.aspx.cs" Inherits="AKSite.Account.Reminder" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Напоминалка
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cont" runat="server">
    <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="defView" runat="server">
            <div id="title">
                <asp:Label ID="titleLabel" runat="server" 
                    meta:resourcekey="titleLabelResource1">
                <b>Восстановление пароля:</b><br />
                Заполните форму, указав свой логин, после чего ждите письмо на тот email, который
                вы использовали при регистрации.</asp:Label>
            </div>
            <br />
            <div>
                <div>
                    <we:TextBox ID="loginBlock" runat="server" Title="Имя пользователя:" MaxLength="50"
                        Description="Укажите здесь Ваш никнэйм, мы должны убедиться что Вы это Вы." SkinID="LoginInput"
                        ValidatorText="Введите имя пользователя, что бы мы могли выслать пароль :)" />
                    <asp:CustomValidator ID="custValidator" runat="server" Text="Ой, кажется кто то забыл пароль?"
                        ForeColor="Red" OnServerValidate="CustValidatorServerValidate" 
                        Display="Dynamic" meta:resourcekey="custValidatorResource1" />
                </div>
                <br />
                <div>
                    <we:Captcha ID="captcha" runat="server" />
                </div>
                <br />
                <we:Button ID="send" runat="server" Text="Получить секретную ссылку" OnClick="SendClick" />
            </div>
        </asp:View>
        <asp:View ID="finishView" runat="server">
            <div id="title">
                <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1"><b>Не забывай пароль больше</b></asp:Label>
            </div>
            <br />
            <br />
            <label id="accessRemind" runat="server">
            </label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1" >
                Запомнили пароль? Если да, то пора <a href="Default.aspx">авторизоваться </a>
            </asp:Label>>
        </asp:View>
    </asp:MultiView>
</asp:Content>
