<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true"
    CodeBehind="ResumeConstructor.aspx.cs" Inherits="AKSite.Profile.ResumeConstructor"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="profileTitle" runat="server">
    Конструктор резюме
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="profileCont" runat="server">
    <asp:ObjectDataSource ID="personalData" runat="server" CacheDuration="300" CacheExpirationPolicy="Sliding"
        DataObjectTypeName="Model.Client" SelectMethod="GetClient" TypeName="BusinessLogic.ClientService"
        UpdateMethod="UpdateClient" OnSelecting="PersonalDataSelecting">
        <SelectParameters>
            <asp:Parameter DefaultValue="null" Name="login" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource CacheDuration="300" CacheExpirationPolicy="Sliding" ID="fieldData"
        runat="server" SelectMethod="GetFeilds" TypeName="BusinessLogic.FieldService">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource CacheDuration="300" CacheExpirationPolicy="Sliding" ID="themesData"
        runat="server" SelectMethod="GetThemes" TypeName="BusinessLogic.ThemeService">
        <SelectParameters>
            <asp:Parameter DefaultValue="-1" Name="fieldId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Menu ID="stepView" runat="server" RenderingMode="Table" Orientation="Horizontal"
        CssClass="stepMenu" StaticSelectedStyle-CssClass="selected" Enabled="False" meta:resourcekey="stepViewResource1">
        <Items>
            <asp:MenuItem Text="Личные данные" Value="private" Selected="true" meta:resourcekey="MenuItemResource1">
            </asp:MenuItem>
            <asp:MenuItem Text="Области знания" Value="fields" meta:resourcekey="MenuItemResource2">
            </asp:MenuItem>
            <asp:MenuItem Text="Прочие данные" Value="other" meta:resourcekey="MenuItemResource3">
            </asp:MenuItem>
            <asp:MenuItem Text="Сохранение" Value="save" meta:resourcekey="MenuItemResource4">
            </asp:MenuItem>
        </Items>
        <StaticSelectedStyle CssClass="selected"></StaticSelectedStyle>
    </asp:Menu>
    <asp:MultiView ID="multiView" runat="server" ActiveViewIndex="0">
        <asp:View ID="personalView" runat="server">
            <asp:FormView ID="resumeForm" runat="server" DataSourceID="personalData" meta:resourcekey="resumeFormResource1">
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="id" runat="server" meta:resourcekey="idResource1" Text='<%# Bind("Id") %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="login" runat="server" meta:resourcekey="loginResource1" Text='<%# Bind("Login") %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="Pass" runat="server" meta:resourcekey="PassResource1" Text='<%# Bind("Pass") %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="Privilegy" runat="server" meta:resourcekey="PrivilegyResource1" Text='<%# Bind("Privilegy") %>'
                                Visible="False"></asp:Label>
                            <table cellpadding="0" cellspacing="0" class="itemList">
                                <tbody>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblName" runat="server" CssClass="resumeBold" meta:resourcekey="lblNameResource1"
                                                Text="Имя"></asp:Label>
                                        </td>
                                        <td>
                                            <we:TextBox ID="nameBlock" runat="server" MaxLength="50" Text='<%# Bind("FirstName") %>' />
                                            <asp:RegularExpressionValidator ID="nameRegExpValidator" runat="server" ControlToValidate="nameBlock"
                                                Display="Dynamic" ForeColor="Red" meta:resourcekey="nameRegExpValidatorResource1"
                                                Text="Пожалуйство введите настоящее имя" ValidationExpression="^[a-zA-Zа-яА-Я]{2,64}$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem alt">
                                        <td class="tdContent">
                                            <asp:Label ID="lblSecondName" runat="server" CssClass="resumeBold" meta:resourcekey="lblSecondNameResource1"
                                                Text="Фамилия"></asp:Label>
                                        </td>
                                        <td>
                                            <we:TextBox ID="secondNameBlock" runat="server" Text='<%# Bind("SecondName") %>' />
                                            <asp:RegularExpressionValidator ID="secNameRegExpValidator" runat="server" ControlToValidate="secondNameBlock"
                                                Display="Dynamic" ForeColor="Red" meta:resourcekey="secNameRegExpValidatorResource1"
                                                Text="Пожалуйство введите настоящую фамилию" ValidationExpression="^[a-zA-Zа-яА-Я]{2,64}$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblMail" runat="server" CssClass="resumeBold" meta:resourcekey="lblMailResource1"
                                                Text="Почта"></asp:Label>
                                        </td>
                                        <td>
                                            <we:TextBox ID="emailBlock" runat="server" Text='<%# Bind("Email") %>'/>
                                            <asp:RegularExpressionValidator ID="emailRegExpValidator" runat="server" ControlToValidate="emailBlock"
                                                Display="Dynamic" ForeColor="Red" meta:resourcekey="emailRegExpValidatorResource1"
                                                Text="Email введен неверно" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem alt">
                                        <td class="tdContent">
                                            <asp:Label ID="lblMobilePhone" runat="server" CssClass="resumeBold" meta:resourcekey="lblMobilePhoneResource1"
                                                Text="Мобильный телефон"></asp:Label>
                                        </td>
                                        <td>
                                            <we:TextBox ID="phoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'/>
                                            <asp:RegularExpressionValidator ID="phoneExpressionValidator" runat="server" ControlToValidate="phoneNumber"
                                                Display="Dynamic" ForeColor="Red" meta:resourcekey="phoneExpressionValidatorResource1"
                                                Text="Пожалуйсто введите корректный телефон" ValidationExpression="\d{3}-\d{2}-\d{2}"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblBirthDay" runat="server" CssClass="resumeBold" meta:resourcekey="lblBirthDayResource1"
                                                Text="Дата рождения"></asp:Label>
                                        </td>
                                        <td>
                                            <we:DateDropDown ID="birthDay" runat="server" GetDate='<%# Bind("BirthDay") %>' />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td class="iconButton">
                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/App_Themes/Main/img/edit.png"
                                meta:resourcekey="UpdateButtonResource1" ToolTip="Вставить" />
                            <asp:ImageButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/App_Themes/Main/img/back.png" meta:resourcekey="UpdateCancelButtonResource1"
                                ToolTip="Назад" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
                <HeaderTemplate>
                    <table class="itemList" cellpadding="0" cellspacing="0">
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <table class="itemList" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblItemName" runat="server" CssClass="resumeBold" Text="Имя" meta:resourcekey="lblItemNameResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("FirstName") %>' meta:resourcekey="lblNameResource2" />
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem alt">
                                        <td class="tdContent">
                                            <asp:Label ID="lblItemSecondName" runat="server" CssClass="resumeBold" Text="Фамилия" meta:resourcekey="lblItemSecondNameResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSecondName" runat="server" Text='<%# Bind("SecondName") %>' meta:resourcekey="lblSecondNameResource2" />
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblItemEmail" runat="server" CssClass="resumeBold" Text="Почта" meta:resourcekey="lblItemEmailResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' meta:resourcekey="lblEmailResource1" />
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem alt">
                                        <td class="tdContent">
                                            <asp:Label ID="lblItemPhone" runat="server" CssClass="resumeBold" Text="Мобильный телефон"
                                                meta:resourcekey="lblItemPhoneResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="phoneNumber" Text='<%# Bind("PhoneNumber") %>' runat="server" meta:resourcekey="phoneNumberResource1" />
                                        </td>
                                    </tr>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent">
                                            <asp:Label ID="lblItemBirthDay" runat="server" CssClass="resumeBold" Text="Дата рождения"
                                                meta:resourcekey="lblItemBirthDayResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="birthDay" runat="server" Text='<%# Bind("BirthDay") %>' meta:resourcekey="birthDayResource1" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td class="iconButton">
                            <asp:ImageButton ID="EditButton" ImageUrl="~/App_Themes/Main/img/edit.png" runat="server"
                                CommandName="Edit" ToolTip="Изменить" meta:resourcekey="EditButtonResource1" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:FormView>
        </asp:View>
        <asp:View ID="resumeView" runat="server">
            <asp:ScriptManager ID="scriptManager" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="upadatePanel" runat="server">
                <ContentTemplate>
                    <table class="itemList" cellpadding="0" cellspacing="0">
                        <tbody>
                            <tr class="resumeOneItem">
                                <td width="50%" class="tdContent">
                                    <asp:Label ID="lblSelectFileld" runat="server" Text="Выберите область знаний" meta:resourcekey="lblSelectFileldResource1"></asp:Label>
                                </td>
                                <td class="tdContent">
                                    <asp:Panel ID="panelCheckBox" runat="server" CssClass="scrollingCheckBoxList scrollingControlContainer"
                                        meta:resourcekey="panelCheckBoxResource1">
                                        <asp:CheckBoxList ID="fieldCheckBox" runat="server" DataSourceID="fieldData" DataTextField="Title"
                                            DataValueField="Id" Height="200px" RepeatLayout="OrderedList" AutoPostBack="True"
                                            OnSelectedIndexChanged="FieldCheckBoxIndexChanged" meta:resourcekey="fieldCheckBoxResource1">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Repeater ID="fieldRepeater" runat="server" OnItemDataBound="FieldRepeaterItemDataBound">
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" class="itemList">
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="tdTitle">
                                    <asp:Label ID="field" runat="server" meta:resourcekey="fieldResource1" Text='<%# Bind("Title") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListView ID="themeListView" runat="server">
                                        <ItemTemplate>
                                            <tr <%# (Container.DataItemIndex % 2 == 0) ?
                                                                            "class=\"adminOneItem\"" : 
                                                                            " class=\"adminOneItem alt\"" %>>
                                                <td class="tdContent" width="50%">
                                                    <asp:Label ID="themeId" runat="server" meta:resourcekey="themeIdResource1" Text='<%# Bind("Id") %>'
                                                        Visible="False"></asp:Label>
                                                    <asp:Label ID="theme" runat="server" meta:resourcekey="themeResource1" Text='<%# Bind("Title") %>'></asp:Label>
                                                </td>
                                                <td class="tdContent">
                                                    <asp:DropDownList ID="themeSkils" runat="server" DataSource='<%# BusinessLogic.SkillService.GetSkillsWithNone(
                                                                                            Eval("GroupName").ToString(), NoneSkill) %>'
                                                        DataTextField="Title" DataValueField="Id" Height="100%" meta:resourcekey="themeSkilsResource1"
                                                        Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table cellpadding="0" cellspacing="0" class="itemList">
                                                <tbody>
                                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                    </asp:ListView>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:View>
        <asp:View ID="otherView" runat="server">
            <table class="itemList" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td>
                            <table class="itemList" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent" width="25%">
                                            <asp:Label ID="lblTitle" runat="server" Text="Заголовок" meta:resourcekey="lblTitleResource1"></asp:Label>
                                        </td>
                                        <td class="tdContent">
                                            <we:TextBox ID="title" Description="Обязательно укажите заголовок, описывающий 
                                            содержание вашего резюме" runat="server" MaxLength="50" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="itemList" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr class="resumeOneItem">
                                        <td class="tdContent" width="25%">
                                            <asp:Label ID="lblDescription" runat="server" Text="Описание" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                        </td>
                                        <td class="tdContent">
                                            <we:TextBox ID="description" Description="Опишите кратко себя, увлечения, слабые и сильные стороны"
                                                runat="server" TextMode="MultiLine" onkeydown="javascript: checkLength(this,500);"  Width="440" Height="120" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:View>
        <asp:View ID="saveView" runat="server">
            <we:ResumeShow ID="resume" runat="server" />
        </asp:View>
    </asp:MultiView>
    <div class="stepButton">
        <we:Button ID="start" runat="server" Text="Далее" Width="100" OnClick="NextClick" />
        <we:Button ID="save" runat="server" Text="Сохранить" Width="100" OnClick="SaveResume"
            Visible="False" />
        <we:Button ID="dontSave" runat="server" Text="Не сохранять" Width="100" OnClick="Back"
            Visible="False" />
    </div>
</asp:Content>
