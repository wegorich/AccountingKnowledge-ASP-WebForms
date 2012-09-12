<%@ Page Title="" Language="C#" MasterPageFile="~/Profile/Profile.master" AutoEventWireup="true"
    CodeBehind="Resume.aspx.cs" Inherits="AKSite.Profile.Resume" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="pageTitle" ContentPlaceHolderID="profileTitle" runat="server">
    Мое резюмe
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="profileCont" runat="server">
    <asp:ObjectDataSource ID="resumeData" runat="server" OnSelected="ResumeDataSelected"
        SelectMethod="GetResume" TypeName="BusinessLogic.ResumeService">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="-1" Name="id" QueryStringField="resume" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <we:ResumeShow ID="someResume" runat="server" ResumeDataSourceId="resumeData" />
</asp:Content>
