<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataPager.ascx.cs" Inherits="AKSite.UserControl.DataPager" %>
<div class="dataPager">
    <asp:DataPager ID="dataPager" runat="server">
        <Fields>
            <asp:NumericPagerField NextPageText="Следующая" PreviousPageText="Предыдущая" NumericButtonCssClass="pager"
                CurrentPageLabelCssClass="current" 
                meta:resourcekey="NumericPagerFieldResource1" />
        </Fields>
    </asp:DataPager>
</div>
