<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="RunningJobs.aspx.vb" Inherits="Employers_JobInbox" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Active Jobs</td>
        </tr>
        <tr>
            <td class="Text">
                Jobs listed in this page are currently in an active status and have not yet 
                reached the closing date initially assigned.</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvJobs" runat="server" CssClass="GridView" Width="95%" 
                    EmptyDataText="You currently have no active jobs." GridLines="None">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField SelectText="View Details" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

