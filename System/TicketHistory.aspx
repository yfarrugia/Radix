<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="TicketHistory.aspx.vb" Inherits="System_TicketHistory" title="Untitled Page" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Ticket History</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvTickets" runat="server" CssClass="GridView" Width="95%" 
                    GridLines="None" EmptyDataText="No tickets have been completed.">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField HeaderText="View Ticket Details" SelectText="View" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

