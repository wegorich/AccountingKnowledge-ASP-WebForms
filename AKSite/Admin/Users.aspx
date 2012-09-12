<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="AKSite.Admin.Users" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="titleMini" ContentPlaceHolderID="adminTitle" runat="server">
    Управление пользователями и ролями
</asp:Content>
<asp:Content ID="ContentPlace" ContentPlaceHolderID="adminCont" runat="server">
    <asp:ObjectDataSource ID="ClientsSource" runat="server" CacheDuration="300" CacheExpirationPolicy="Sliding"
        SelectMethod="GetClients" TypeName="BusinessLogic.ClientService" DataObjectTypeName="Model.Client"
        DeleteMethod="DeleteClient" UpdateMethod="UpdateClient">
        <SelectParameters>
            <asp:Parameter Direction="input" Name="sortExpression" Type="String" />
            <asp:Parameter Direction="input" Name="sortDirection" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="usersView" runat="server" DataSourceID="ClientsSource" DataKeyNames="Id"
        OnItemUpdating="UsersViewItemUpdating" OnSorting="UsersViewSorting" EnablePersistedSelection="True">
        <EditItemTemplate>
            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                <td>
                        <div class="padding-left">
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                                meta:resourcekey="lblIdResource1" />
                            <asp:Label ID="Name" runat="server" Text='<%# Bind("FirstName") %>' 
                                meta:resourcekey="NameResource1" />
                            <asp:Label ID="SecondName" runat="server" Text='<%# Bind("SecondName") %>' 
                                meta:resourcekey="SecondNameResource1" />
                            <asp:Label ID="BirthDay" runat="server" Text='<%# Bind("BirthDay") %>' 
                                Visible="False" meta:resourcekey="BirthDayResource1" />
                        </div>
                </td>
                <td>
                    <div class="padding-left">
                        <we:TextBox ID="userLogin" runat="server" Width="95%" Text='<%# Bind("Login") %>' MaxLength="50" />
                        <asp:RegularExpressionValidator ID="loginRegExpValidator" runat="server" ControlToValidate="userLogin"
                            ValidationExpression="^[a-zA-Z0-9]{3,25}$" Text="Некорректное имя пользователя"
                            Display="Dynamic" ForeColor="Red" 
                            meta:resourcekey="loginRegExpValidatorResource1" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <we:TextBox ID="Pass" runat="server" Width="95%" Text='<%# Bind("Pass") %>' MaxLength="50" />
                        <asp:RegularExpressionValidator ID="passRegExValidator" runat="server" ControlToValidate="Pass"
                            Text="Слишком короткий пароль" Display="Dynamic" ForeColor="Red" 
                            ValidationExpression="[a-zA-z0-9._-]{6,}" 
                            meta:resourcekey="passRegExValidatorResource1" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="PhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' 
                            meta:resourcekey="PhoneNumberResource1" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="Email" runat="server" Text='<%# Bind("Email") %>' 
                            meta:resourcekey="EmailResource1" />
                    </div>
                </td>
                <td>
                    <div class="itemPadding">
                        <asp:DropDownList ID="Roles" runat="server" DataSource='<%# new BusinessLogic.Security.ServiceRoleProvider().GetAllRoles() %>'
                            
                            SelectedIndex='<%# new BusinessLogic.Security.ServiceRoleProvider().RoleIndex(Eval("Privilegy")) %>' 
                            meta:resourcekey="RolesResource1">
                        </asp:DropDownList>
                    </div>
                </td>
                <td class="iconButton">
                    <asp:ImageButton ID="UpdateButton" ImageUrl="~/App_Themes/Main/img/edit.png" 
                        runat="server" CommandName="Update" ToolTip="Вставить" 
                        meta:resourcekey="UpdateButtonResource1" />
                </td>
                <td class="iconButton">
                    <asp:ImageButton ID="UpdateCancelButton" ImageUrl="~/App_Themes/Main/img/back.png"
                        runat="server" CausesValidation="False" CommandName="Cancel" 
                        ToolTip="Назад" meta:resourcekey="UpdateCancelButtonResource1" />
                </td>
            </tr>
        </EditItemTemplate>
        <LayoutTemplate>
            <table class="itemList" cellpadding="0" cellspacing="0">
                <tbody>
                    <th title="Имя">
                        <asp:LinkButton ID="SortName" runat="server" CommandName="sort" CommandArgument="FirstName"
                            Text="Имя" meta:resourcekey="SortNameResource1" />
                    </th>
                    <th title="Логин">
                        <asp:LinkButton ID="SortLogin" runat="server" CommandName="sort" CommandArgument="Login"
                            Text="Логин" meta:resourcekey="SortLoginResource1" />
                    </th>
                    <th title="Пароль">
                        <asp:Label ID="lblPass" runat="server" meta:resourcekey="lblPassResource1">Пароль</asp:Label>
                    </th>
                    <th title="Email">
                        <asp:LinkButton ID="SortPhone" runat="server" CommandName="sort" CommandArgument="PhoneNumber"
                            Text="Телефон" meta:resourcekey="SortPhoneResource1" />
                    </th>
                    <th title="Email">
                        <asp:LinkButton ID="SortEmail" runat="server" CommandName="sort" CommandArgument="Email"
                            Text="Email" meta:resourcekey="SortEmailResource1" />
                    </th>
                    <th title="Права">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="sort" CommandArgument="Privilegy"
                            Text="Права" meta:resourcekey="LinkButton1Resource1" />
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                            meta:resourcekey="lblIdResource2" />
                        <asp:Label ID="Name" runat="server" Text='<%# Bind("FirstName") %>' 
                            meta:resourcekey="NameResource2" />
                        <asp:Label ID="SecondName" runat="server" Text='<%# Bind("SecondName") %>' 
                            meta:resourcekey="SecondNameResource2" />
                        <asp:Label ID="BirthDay" runat="server" Text='<%# Bind("BirthDay") %>' 
                            Visible="False" meta:resourcekey="BirthDayResource2" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="Login" runat="server" Text='<%# Bind("Login") %>' 
                            meta:resourcekey="LoginResource1" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="Pass" runat="server" Text='<%# ProtectPassword(Eval("Pass")) %>' 
                            meta:resourcekey="PassResource1" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="PhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' 
                            meta:resourcekey="PhoneNumberResource2" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="Email" runat="server" Text='<%# Bind("Email") %>' 
                            meta:resourcekey="EmailResource2" />
                    </div>
                </td>
                <td>
                    <div class="padding-left">
                        <asp:Label ID="Privilegy" runat="server" Text='<%# Bind("Privilegy") %>' 
                            meta:resourcekey="PrivilegyResource1" />
                    </div>
                </td>
                <td class="iconButton">
                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                        CommandName="Edit" runat="server" meta:resourcekey="EditResource1" />
                </td>
                <td class="iconButton">
                    <asp:ImageButton ID="Delete" ImageUrl="~/App_Themes/Main/img/delete.png" OnClientClick="javascript:return deleteAction(this.name);"
                        ToolTip="Удалить" CommandName="Delete" runat="server" 
                        meta:resourcekey="DeleteResource1" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div id="title">
                <b>Нет данных</b></div>
        </EmptyDataTemplate>
    </asp:ListView>
    <we:DataPager ID="userListPager" runat="server" PagedControlId="usersView" PageSize="50" />
</asp:Content>
