<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AKSite.Profile.Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="profileTitle" runat="server">
   Все резюме
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="profileCont" runat="server">
    <asp:ObjectDataSource ID="resumeData" runat="server" DataObjectTypeName="Model.Resume"
        DeleteMethod="DeleteResume" OnSelecting="ResumeDataSelecting" SelectMethod="GetResumes"
        TypeName="BusinessLogic.ResumeService">
        <SelectParameters>
            <asp:Parameter DefaultValue="-1" Name="login" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="resumes" runat="server" DataSourceID="resumeData" DataKeyNames="Id">
        <EmptyDataTemplate>
            <div id="title">
                <asp:Label ID="lblTitle" runat="server" meta:resourcekey="lblTitleResource1"><b>Сейчас у Вас нет резюме</b></asp:Label>
            </div>
            <asp:Label ID="lblNoItem" runat="server" meta:resourcekey="lblNoItemResource1">
            <ul class="help">
                <li><span><b>Воспользуйтесь построителем резюме.</b></span></li>
                <li><span>Подробно опишите свой опыт, образование, достижения и навыки.</span></li>
                <li><span>Увидев информативное резюме, специалист по подбору персонала примет верное
                    решение относительно Вашей кандидатуры!</span></li>
                <li><span><b>Не определились с должностью?</b></span></li>
                <li><span>Составьте несколько резюме, чтобы подчеркнуть в каждом из них тот или иной
                    профессиональный опыт.</span></li>
                <li><span><b>Это повысит Ваши шансы!</b></span></li>
            </ul>
            </asp:Label>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <table class="itemList" cellpadding="0" cellspacing="0">
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <we:ResumeView ID="view" ResumePage="Resume.aspx" DataSource='<%# Container.DataItem %>'
                        runat="server" />
                </td>
                <td class="iconButton">
                    <asp:ImageButton ID="Delete" OnClientClick="javascript:return deleteAction(this.name);"
                        ImageUrl="~/App_Themes/Main/img/delete.png" ToolTip="Удалить" CommandName="Delete"
                        runat="server" meta:resourcekey="DeleteResource1" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <we:DataPager ID="resumePager" runat="server" PagedControlId="resumes" PageSize="20" />
</asp:Content>
