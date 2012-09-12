<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateDropDown.ascx.cs"
    Inherits="AKSite.UserControl.DateDropDown" %>
<div class="birthDay">
    <div>
        <asp:DropDownList ID="day" runat="server" meta:resourcekey="dayResource1">
        </asp:DropDownList>
        <asp:DropDownList ID="month" runat="server" meta:resourcekey="monthResource1">
            <asp:ListItem Text="Января" Value="1" meta:resourcekey="ListItemResource1" />
            <asp:ListItem Text="Февраля" Value="2" meta:resourcekey="ListItemResource2" />
            <asp:ListItem Text="Марта" Value="3" meta:resourcekey="ListItemResource3" />
            <asp:ListItem Text="Апреля" Value="4" meta:resourcekey="ListItemResource4" />
            <asp:ListItem Text="Мая" Value="5" meta:resourcekey="ListItemResource5" />
            <asp:ListItem Text="Июня" Value="6" meta:resourcekey="ListItemResource6" />
            <asp:ListItem Text="Июля" Value="7" meta:resourcekey="ListItemResource7" />
            <asp:ListItem Text="Августа" Value="8" meta:resourcekey="ListItemResource8" />
            <asp:ListItem Text="Сентября" Value="9" meta:resourcekey="ListItemResource9" />
            <asp:ListItem Text="Октября" Value="10" meta:resourcekey="ListItemResource10" />
            <asp:ListItem Text="Ноября" Value="11" meta:resourcekey="ListItemResource11" />
            <asp:ListItem Text="Декабря" Value="12" meta:resourcekey="ListItemResource12" />
        </asp:DropDownList>
        <asp:DropDownList ID="year" runat="server" meta:resourcekey="yearResource1">
        </asp:DropDownList>
    </div>
    <div>
        <asp:CompareValidator ID="dayCompValidator" runat="server" ErrorMessage="день не выбран "
            ControlToValidate="day" Operator="NotEqual" ValueToCompare="0" 
            Display="Dynamic" ForeColor="Red" 
            meta:resourcekey="dayCompValidatorResource1" />
        <asp:CompareValidator ID="monthCompValidator" runat="server" ErrorMessage="месяц не выбран "
            ControlToValidate="month" Operator="NotEqual" ValueToCompare="0" 
            Display="Dynamic" ForeColor="Red" 
            meta:resourcekey="monthCompValidatorResource1" />
       <asp:CompareValidator ID="yearCompValidator" runat="server" ErrorMessage="год не выбран"
            ControlToValidate="year" Operator="NotEqual" ValueToCompare="0" 
            Display="Dynamic" ForeColor="Red" 
            meta:resourcekey="yearCompValidatorResource1" />
    </div>
</div>
