<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AKSite.Admin.Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="title" ContentPlaceHolderID="adminTitle" runat="server">
    Области знаний
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="adminCont" runat="server">
    <asp:ObjectDataSource ID="FieldSource" runat="server" CacheDuration="300" CacheExpirationPolicy="Sliding"
        SelectMethod="GetFeilds" TypeName="BusinessLogic.FieldService" DataObjectTypeName="Model.Field"
        DeleteMethod="DeleteField" InsertMethod="AddField" UpdateMethod="UpdateField">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ThemeSource" runat="server" CacheDuration="300" CacheExpirationPolicy="Sliding"
        DataObjectTypeName="Model.Theme" DeleteMethod="DeleteTheme" InsertMethod="AddTheme"
        SelectMethod="GetThemes" TypeName="BusinessLogic.ThemeService" UpdateMethod="UpdateTheme">
        <SelectParameters>
            <asp:ControlParameter ControlID="FieldView" DefaultValue="-1" Name="fieldId" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table class="itemList" cellpadding="0" cellspacing="0">
        <tbody>
            <th>
                <asp:Label ID="lblField" runat="server" meta:resourcekey="lblFieldResource1">Области знаний</asp:Label>
            </th>
            <th>
                <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1">Знания</asp:Label>
            </th>
            <tr>
                <td width="50%" valign="top">
                    <asp:ListView ID="FieldView" runat="server" DataSourceID="FieldSource" DataKeyNames="Id"
                        InsertItemPosition="FirstItem" EnablePersistedSelection="True" OnItemInserting="FieldViewItemInserting">
                        <EditItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                </td>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                                            meta:resourcekey="lblIdResource1" />
                                        <we:TextBox ID="TitleTextBox" Text='<%# Bind("Title") %>'  runat="server" Width="95%" MaxLength="100" />
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
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </tbody>
                            </table>
                            <we:DataPager ID="fieldPager" runat="server" QueryString="fieldPage" PagedControlId="FieldView"
                                PageSize="20" />
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                </td>
                                <td>
                                    <div class="padding-left">
                                        <b>
                                            <asp:Label ID="textLbl" runat="server" Text='<%# Bind("Title") %>' 
                                            meta:resourcekey="textLblResource2"></asp:Label></b>
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                                        CommandName="Edit" runat="server" meta:resourcekey="EditResource2" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Delete" OnClientClick="javascript:return deleteAction(this.name);"
                                        ImageUrl="~/App_Themes/Main/img/delete.png" ToolTip="Удалить" CommandName="Delete"
                                        runat="server" meta:resourcekey="DeleteResource2" />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                        <ItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td class="iconButton">
                                    <asp:ImageButton ID="select" ImageUrl="~/App_Themes/Main/img/select.png" ToolTip="Выбрать"
                                        CommandName="Select" runat="server" meta:resourcekey="selectResource1" />
                                </td>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="textLbl" runat="server" Text='<%# Bind("Title") %>' 
                                            meta:resourcekey="textLblResource1"></asp:Label>
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                                        CommandName="Edit" runat="server" meta:resourcekey="EditResource1" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Delete" OnClientClick="javascript:return deleteAction(this.name);"
                                        ImageUrl="~/App_Themes/Main/img/delete.png" ToolTip="Удалить" CommandName="Delete"
                                        runat="server" meta:resourcekey="DeleteResource1" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="adminAdd">
                                <we:Search ID="add" runat="server" ButtonText="Добавить" Text='<%# Bind("Title") %>'  MaxLength="100" CausesValidation="False"
                                    CommandName="Insert" />
                            </div>
                        </InsertItemTemplate>
                    </asp:ListView>
                </td>
                <td width="50%" valign="top">
                    <asp:ListView ID="ThemeView" runat="server" DataSourceID="ThemeSource" DataKeyNames="Id"
                        InsertItemPosition="FirstItem" OnItemUpdating="ThemeViewItemUpdating" OnItemInserting="ThemeViewItemInserting"
                        OnPreRender="ThemeViewPreRender">
                        <EditItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td colspan="3">
                                    <div class="itemPadding">
                                        <asp:DropDownList ID="editGroup" runat="server" DataSource='<%# BusinessLogic.SkillGroupService.GetSkillGroupTitles() %>'
                                                                                SelectedIndex='<%# BusinessLogic.SkillGroupService.GetIndex(Eval("GroupName")) %>' 
                                            meta:resourcekey="editGroupResource1">
                                        </asp:DropDownList>
                                        <div>
                                            <div class="itemPadding">
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                                                    meta:resourcekey="lblIdResource2" />
                                                <asp:Label ID="lblFieldId" runat="server" Text='<%# Bind("FieldId") %>' 
                                                    Visible="False" meta:resourcekey="lblFieldIdResource1" />
                                                <we:TextBox ID="TitleTextBox" Text='<%# Bind("Title") %>' MaxLength="100" runat="server" Width="95%"
                                                    TextMode="MultiLine" />
                                            </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="UpdateCancelButton" ImageUrl="~/App_Themes/Main/img/back.png"
                                        runat="server" CausesValidation="False" CommandName="Cancel" 
                                        ToolTip="Назад" meta:resourcekey="UpdateCancelButtonResource2" />
                                    <asp:ImageButton ID="UpdateButton" ImageUrl="~/App_Themes/Main/img/edit.png" 
                                        runat="server" CommandName="Update" ToolTip="Вставить" 
                                        meta:resourcekey="UpdateButtonResource2" />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <LayoutTemplate>
                            <table class="itemList" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </tbody>
                            </table>
                            <we:DataPager ID="themePager" runat="server" QueryString="themePage" PagedControlId="ThemeView"
                                PageSize="20" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="textLbl" runat="server" Text='<%# Bind("Title") %>' 
                                            meta:resourcekey="textLblResource3"></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="groupNameLbl" runat="server" Text='<%# Bind("GroupName") %>' 
                                            meta:resourcekey="groupNameLblResource1"></asp:Label>
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                                        CommandName="Edit" runat="server" meta:resourcekey="EditResource3" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Delete" OnClientClick="javascript:return deleteAction(this.name);"
                                        ImageUrl="~/App_Themes/Main/img/delete.png" ToolTip="Удалить" CommandName="Delete"
                                        runat="server" meta:resourcekey="DeleteResource3" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="adminAdd">
                                <we:Search ID="add" runat="server" Text='<%# Bind("Title") %>' ButtonText="Добавить" MaxLength="100" CausesValidation="False"
                                    CommandName="Insert" />
                                <div class="itemPadding backSearch">
                                    <asp:DropDownList ID="insertGroup" runat="server" 
                                        DataSource='<%# BusinessLogic.SkillGroupService.GetSkillGroupTitles() %>' 
                                        meta:resourcekey="insertGroupResource1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </InsertItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
