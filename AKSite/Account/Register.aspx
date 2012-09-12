<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="AKSite.Account.Register" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Регистрация нового пользователя
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cont" runat="server">
    <div id="title">
        <asp:Label ID="titleLabel" runat="server" 
            meta:resourcekey="titleLabelResource1"><b>Регистрация на сайте: </b>
        <br />
        Пожалуйста, заполните поля ниже.</asp:Label>
    </div>
    <br />
    <div>
        <asp:CustomValidator ID="loginCustValidator" runat="server" ErrorMessage="<p>Пользователь с таким логином или Email уже существует</p>"
            Display="Dynamic" ForeColor="Red" 
            OnServerValidate="CustValidatorServerValidate" 
            meta:resourcekey="loginCustValidatorResource1" />
        <we:Login ID="login" LoginTitle="Логин:" LoginDescription="Может состоять только из букв (A-Z a-z) и цифр (0-9). Длина имени не может быть меньше 3 и больше 25 символов."
            PassTitle="Пароль:" PassDescription="В целях безопасности длина пароля не может быть меньше 6-ти символов."
            runat="server" />
        <br />
        <div>
            <we:TextBox ID="passAgainBlock" runat="server" Title="Пароль еще раз:" MaxLength="50"
                TextMode="Password" ValidatorText="Введите пароль еще раз, на всякий случай" />
            <asp:CompareValidator ID="passAgainCoValidator" runat="server" ControlToValidate="passAgainBlock"
                ControlToCompare="login" Display="Dynamic" ForeColor="Red" 
                Text="Пароль не совпадает" meta:resourcekey="passAgainCoValidatorResource1" />
        </div>
        <br />
        <div>
            <we:TextBox ID="emailBlock" runat="server" Title="Адрес электронной почты:" MaxLength="100"
                Description="Нужен для подтверждения регистрации, а так же на случай обратной связи."
                ValidatorText="Email введен неверно" />
            <asp:RegularExpressionValidator ID="emailRegExpValidator" runat="server" ControlToValidate="emailBlock"
                Text="Email введен неверно" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                meta:resourcekey="emailRegExpValidatorResource1" />
        </div>
        <br />
        <div>
            <we:TextBox ID="nameBlock" runat="server" Title="Настоящее имя:" MaxLength="50" Description="Может состоять только из букв"
                ValidatorText="Введите пожалуйсто имя" />
            <asp:RegularExpressionValidator ID="nameRegExpValidator" runat="server" ControlToValidate="nameBlock"
                ValidationExpression="^[a-zA-Zа-яА-Я]{2,64}$" Text="Пожалуйство введите настоящее имя"
                Display="Dynamic" ForeColor="Red" 
                meta:resourcekey="nameRegExpValidatorResource1" />
        </div>
        <br />
        <div>
            <we:TextBox ID="secondNameBlock" runat="server" Title="Фамилия:" MaxLength="50" Description="Может состоять только из букв"
                ValidatorText="Введите пожалуйсто Вашу фамилию" />
            <asp:RegularExpressionValidator ID="secNameRegExpValidator" runat="server" ControlToValidate="secondNameBlock"
                ValidationExpression="^[a-zA-Zа-яА-Я]{2,64}$" Text="Пожалуйство введите настоящую фамилию"
                Display="Dynamic" ForeColor="Red" 
                meta:resourcekey="secNameRegExpValidatorResource1" />
        </div>
        <br />
        <div>
            <we:TextBox ID="phoneNumber" runat="server" Title="Контактный телефон:" MaxLength="50"
                Description="Номер мобильного телефона например 202-03-27" ValidatorText="Введите пожалуйсто имя" />
            <asp:RegularExpressionValidator ID="phoneExpressionValidator" runat="server" ControlToValidate="phoneNumber"
                Text="Пожалуйсто введите корректный телефон" Display="Dynamic" ForeColor="Red"
                ValidationExpression="\d{3}-\d{2}-\d{2}" 
                meta:resourcekey="phoneExpressionValidatorResource1" />
        </div>
        <br />
        <div>
            <asp:Label ID="lblBirthDay" runat="server" Text="Дата рождения:" Style="font-weight: bold;
                font-size: small" meta:resourcekey="lblBirthDayResource1" />
            <we:DateDropDown ID="birthDay" runat="server" />
        </div>
        <br />
        <div>
            <we:Captcha ID="captcha" runat="server"></we:Captcha>
        </div>
        <br />
        <div class="stepButton">
            <we:Button ID="send" runat="server" Text="Зарегистрироваться" OnClick="SendClick" />
        </div>
    </div>
</asp:Content>
