<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="ManageEmployees.aspx.vb" Inherits="Employers_ManageEmployees" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle" colspan="3">
                Manage Employees</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gdvInterestedEmployees" runat="server" CssClass="GridView" 
                    Width="95%" EmptyDataText="You do not have any employees to manage." 
                    GridLines="None">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:ButtonField CommandName="Accept" Text="Accept" />
                        <asp:ButtonField CommandName="Deny" Text="Deny" />
                        <asp:ButtonField CommandName="View" Text="View CV" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

