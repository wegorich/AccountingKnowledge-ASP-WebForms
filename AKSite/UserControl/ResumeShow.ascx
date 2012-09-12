<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumeShow.ascx.cs"
    Inherits="AKSite.UserControl.ResumeShow" %>
<%@ Import Namespace="BusinessLogic" %>
<asp:Repeater ID="resumeView" runat="server">
    <HeaderTemplate>
        <table class="itemList" cellpadding="0" cellspacing="0">
            <tbody>
    </HeaderTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
    <ItemTemplate>
        <tr>
            <td class="tdTitle" colspan="2">
                <asp:Label ID="resumeTitle" runat="server" Text='<%# Eval("Title") %>' 
                    meta:resourcekey="resumeTitleResource1" />
            </td>
        </tr>
        <asp:Repeater ID="clientDetail" runat="server" 
            DataSource='<%# new List<Model.Client>{(Model.Client)Eval("Client")} %>'>
            <ItemTemplate>
                <tr class="resumeOneItem">
                    <td width="50%" class="tdContent">
                        <asp:Label ID="lblItemName" runat="server" CssClass="resumeBold" Text="Имя" 
                            meta:resourcekey="lblItemNameResource1"></asp:Label>
                    </td>
                    <td class="tdContent">
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") %>' 
                            meta:resourcekey="lblNameResource1" />
                    </td>
                </tr>
                <tr class="resumeOneItem alt">
                    <td class="tdContent">
                        <asp:Label ID="lblItemSecondName" runat="server" CssClass="resumeBold" Text="Фамилия" 
                            meta:resourcekey="lblItemSecondNameResource1"></asp:Label>
                    </td>
                    <td class="tdContent">
                        <asp:Label ID="lblSecondName" runat="server" Text='<%# Bind("SecondName") %>' 
                            meta:resourcekey="lblSecondNameResource1" />
                    </td>
                </tr>
                <tr class="resumeOneItem">
                    <td class="tdContent">
                        <asp:Label ID="lblItemAge" runat="server" CssClass="resumeBold" Text="Возраст" 
                            meta:resourcekey="lblItemAgeResource1"></asp:Label>
                    </td>
                    <td class="tdContent">
                        <asp:Label ID="birthDay" runat="server" 
                            Text='<%# ClientService.GetAge((DateTime)Eval("BirthDay")) %>' 
                            meta:resourcekey="birthDayResource1" />
                    </td>
                </tr>
                <tr class="resumeOneItem alt">
                    <td class="tdContent">
                        <asp:Label ID="lblItemEmail" runat="server" CssClass="resumeBold" Text="Email" 
                            meta:resourcekey="lblItemEmailResource1"></asp:Label>
                    </td>
                    <td class="tdContent">
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' 
                            meta:resourcekey="lblEmailResource1" />
                    </td>
                </tr>
                <tr class="resumeOneItem">
                    <td class="tdContent">
                        <asp:Label ID="lblItemMobile" runat="server" CssClass="resumeBold" Text="Мобильный телефон" 
                            meta:resourcekey="lblItemMobileResource1"></asp:Label>
                    </td>
                    <td class="tdContent">
                        <asp:Label ID="phoneNumber" Text='<%# Bind("PhoneNumber") %>' runat="server" 
                            meta:resourcekey="phoneNumberResource1" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="2">
                <asp:Repeater ID="themesView" runat="server" DataSource='<%# Bind("Fields") %>'>
                    <HeaderTemplate>
                        <table class="itemList" cellpadding="0" cellspacing="0">
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="tdTitle">
                                <asp:Label ID="field" runat="server" Text='<%# Bind("FieldName") %>' 
                                    meta:resourcekey="fieldResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="themeListView" runat="server" DataSource='<%# Bind("Theme") %>'>
                                    <HeaderTemplate>
                                        <table class="itemList" cellpadding="0" cellspacing="0">
                                            <tbody>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <tr <%# (Container.ItemIndex % 2 == 0) ?
                                                                            "class=\"resumeOneItem\"" : 
                                                                            " class=\"resumeOneItem alt\"" %>>
                                            <td width="50%" class="tdContent">
                                                <asp:Label ID="theme" runat="server" CssClass="resumeBold" Text='<%# Bind("ThemeName") %>' 
                                                    meta:resourcekey="themeResource1"></asp:Label>
                                            </td>
                                            <td class="tdContent">
                                                <asp:Label ID="skill" runat="server" Text='<%# Bind("SkillName") %>' 
                                                    meta:resourcekey="skillResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" colspan="2">
                <asp:Label ID="lblItemDescripiton" runat="server" Text="Описание" 
                    meta:resourcekey="lblItemDescripitonResource1"></asp:Label> 
            </td>
        </tr>
        <tr class="resumeOneItem">
            <td class="tdContent" colspan="2">
                <asp:Label ID="resumeDescription" runat="server" 
                    Text='<%# Bind("Description") %>' 
                    meta:resourcekey="resumeDescriptionResource1" />
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
