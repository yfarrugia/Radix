<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="JobRequestInbox.aspx.vb" Inherits="Employees_JobRequestInbox" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Job Request Inbox</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvJobRequests" runat="server" CssClass="GridView" 
                    EmptyDataText="You do not have any job requests." GridLines="None" Width="95%">
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

