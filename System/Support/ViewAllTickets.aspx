<%@ Page Language="VB" MasterPageFile="~/System/Support/SupportMasterPage.master" AutoEventWireup="false" CodeFile="ViewAllTickets.aspx.vb" Inherits="System_Support_ViewAllTickets" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td class="TextTitle">
            All Open Tickets</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="uplTickets" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="tmrUpdate" runat="server" Interval="2000">
                    </asp:Timer>
                    <table style="width:100%;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gdvTickets" runat="server" CssClass="GridView" 
                                    EmptyDataText="There are currently no tickets open." GridLines="None" 
                                    Width="95%">
                                    <RowStyle CssClass="GridViewRow" />
                                    <HeaderStyle CssClass="GridViewHeaderRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>

