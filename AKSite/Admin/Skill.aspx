<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeBehind="Skill.aspx.cs" Inherits="AKSite.Admin.Skill" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="title" ContentPlaceHolderID="adminTitle" runat="server">
    Опыт, умения и навыки
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="adminCont" runat="server">
    <asp:ObjectDataSource 
        ID="Group" runat="server" 
        CacheDuration="300" 
        CacheExpirationPolicy="Sliding"
        DataObjectTypeName="Model.SkillGroup" 
        DeleteMethod="DeleteSkillGroup" 
        InsertMethod="AddSkillGroup"
        SelectMethod="GetSkillGroups" 
        TypeName="BusinessLogic.SkillGroupService" 
        UpdateMethod="UpdateSkillGroup">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource 
        ID="Skills" 
        runat="server" 
        CacheDuration="300" 
        CacheExpirationPolicy="Sliding"
        DeleteMethod="DeleteSkill" 
        InsertMethod="AddSkill" 
        SelectMethod="GetSkills" 
        TypeName="BusinessLogic.SkillService"
        UpdateMethod="UpdateSkill" 
        DataObjectTypeName="Model.Skill">
        <SelectParameters>
            <asp:ControlParameter ControlID="SkillGroupView" DefaultValue="-1" Name="groupName"
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table class="itemList" cellpadding="0" cellspacing="0">
        <tbody>
            <th>
                <asp:Label ID="lblGroup" runat="server" meta:resourcekey="lblGroupResource1"> Группы навыков</asp:Label>
            </th>
            <th>
                <asp:Label ID="lblSkill" runat="server" meta:resourcekey="lblSkillResource1">Навыки</asp:Label>
                </th>
            <tr>
                <td width="50%" valign="top">
                    <asp:ListView ID="SkillGroupView" runat="server" DataSourceID="Group" DataKeyNames="Title"
                        InsertItemPosition="FirstItem" EnablePersistedSelection="True" OnItemInserting="SkillGroupViewItemInserting">
                        <EditItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                </td>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                                            meta:resourcekey="lblIdResource1" />
                                        <we:TextBox ID="TitleTextBox" runat="server" MaxLength="50" Text='<%# Bind("Title") %>' Width="95%" />
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
                            <we:DataPager ID="skillGroupPager" runat="server" QueryString="groupPage" PagedControlId="SkillGroupView"
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
                                <we:Search ID="add" runat="server" Text='<%# Bind("Title") %>'  MaxLength="50" ButtonText="Добавить" CausesValidation="False"
                                    CommandName="Insert" />
                            </div>
                        </InsertItemTemplate>
                    </asp:ListView>
                </td>
                <td width="50%" valign="top">
                    <asp:ListView ID="SkilView" runat="server" DataSourceID="Skills" DataKeyNames="Id"
                        InsertItemPosition="FirstItem" OnItemInserting="SkilViewItemInserting">
                        <EditItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="False" 
                                            meta:resourcekey="lblIdResource2" />
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("GroupName") %>' 
                                            Visible="False" meta:resourcekey="Label1Resource1" />
                                        <we:TextBox ID="TitleTextBox" MaxLength="50" runat="server" Text='<%# Bind("Title") %>' Width="95%" />
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="UpdateButton" ImageUrl="~/App_Themes/Main/img/edit.png" 
                                        runat="server" CommandName="Update" ToolTip="Вставить" 
                                        meta:resourcekey="UpdateButtonResource2" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="UpdateCancelButton" ImageUrl="~/App_Themes/Main/img/back.png"
                                        runat="server" CausesValidation="False" CommandName="Cancel" 
                                        ToolTip="Назад" meta:resourcekey="UpdateCancelButtonResource2" />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <LayoutTemplate>
                            <table class="itemList" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </tbody>
                            </table>
                            <we:DataPager ID="skillPager" runat="server" QueryString="skillPage" PagedControlId="SkilView"
                                PageSize="20" />
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                    <div class="padding-left">
                                        <b>
                                            <asp:Label ID="textLbl" runat="server" Text='<%# Bind("Title") %>' 
                                            meta:resourcekey="textLblResource4"></asp:Label></b>
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                                        CommandName="Edit" runat="server" meta:resourcekey="EditResource4" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Delete" OnClientClick="javascript:return deleteAction(this.name);"
                                        ImageUrl="~/App_Themes/Main/img/delete.png" ToolTip="Удалить" CommandName="Delete"
                                        runat="server" meta:resourcekey="DeleteResource4" />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                        <ItemTemplate>
                            <tr <%# (Container.DataItemIndex % 2 == 0) ?"class=\"adminOneItem\"" : " class=\"adminOneItem alt\"" %>>
                                <td>
                                    <div class="padding-left">
                                        <asp:Label ID="textLbl" runat="server" Text='<%# Bind("Title") %>' 
                                            meta:resourcekey="textLblResource3"></asp:Label>
                                    </div>
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Edit" ImageUrl="~/App_Themes/Main/img/edit.png" ToolTip="Редактировать"
                                        CommandName="Edit" runat="server" meta:resourcekey="EditResource3" />
                                </td>
                                <td class="iconButton">
                                    <asp:ImageButton ID="Delete" ImageUrl="~/App_Themes/Main/img/delete.png" OnClientClick="javascript:return deleteAction(this.name);"
                                        ToolTip="Удалить" CommandName="Delete" runat="server" 
                                        meta:resourcekey="DeleteResource3" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="adminAdd">
                                <we:Search ID="add" runat="server" Text='<%# Bind("Title") %>'  ButtonText="Добавить" MaxLength="50" CausesValidation="False"
                                    CommandName="Insert" />
                            </div>
                        </InsertItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
