<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="FlaggedUsers.aspx.vb" Inherits="System_Admin_FlaggedUsers" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table width="100%">
        <tr>
            <td class="TextTitle">
                Moderate
                Flagged Users</td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:GridView ID="gvFlaggedUsers" runat="server" CssClass="GridView" 
                    GridLines="None" Width="95%" 
                    EmptyDataText="There are currently no flagged users waiting moderation.">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <br />
              <%--  <asp:Button ID="Button1" runat="server" CssClass="ButtonLightBlue" 
                    Text="Button" />
&nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonLightBlue" Text="Button" />
&nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonLightBlue" Text="Button" />--%>
            </td>
        </tr>
    </table>
</asp:Content>

