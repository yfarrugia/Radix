<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false"
    CodeFile="ViewAllUsers.aspx.vb" Inherits="System_Admin_ViewAllUsers" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="TextTitle">
                All System Users</td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:GridView ID="gvAllUsers" runat="server" AllowPaging="True" 
                    CssClass="GridView" PageSize="20" 
                    EmptyDataText="No users are currently registered with the system." 
                    GridLines="None" Width="95%">
                    <PagerSettings Position="Top" />
                    <RowStyle CssClass="GridViewRow" />
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
