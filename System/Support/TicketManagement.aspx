<%@ Page Language="VB" MasterPageFile="~/System/Support/SupportMasterPage.master" AutoEventWireup="false" CodeFile="TicketManagement.aspx.vb" Inherits="System_Support_NewTickets" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="pnlLoading" runat="server" CssClass="LoadingPanel" >
                <table border="0" cellspacing="0" cellpadding="5" align="center">
                    <tr valign="middle">
                        <td align="center" width="5px" height="75">
                            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/Loading.gif"/>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblLoading" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="TextTitle">
                        Ticket Management</td>
                </tr>
                <tr>
                    <td class="Text" align="left">
                        <asp:LinkButton ID="lnkRefresh" runat="server" CssClass="Link">Refresh All</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="BlueTextBold">
                        Un-Assigned Tickets</td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upNewTickets">
                            <ProgressTemplate>
                                <asp:Panel ID="pnlLoading1" runat="server" CssClass="LoadingPanel" >
                                    <table border="0" cellspacing="0" cellpadding="5" align="center">
                                        <tr valign="middle">
                                            <td align="center" width="5px" height="75">
                                                <asp:Image ID="imgLoading1" runat="server" ImageUrl="~/Images/Loading.gif"/>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblLoading1" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="upNewTickets" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td align="left">
                                            <asp:Timer ID="tmrRefreshNewTickets" runat="server" Interval="180000">
                                            </asp:Timer>
                                            <br />
                                            <asp:LinkButton ID="lnkRefreshUnassigned" runat="server" CssClass="Link">Refresh 
                                            Un-Assigned Tickets</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gdvTickets" runat="server" CssClass="GridView" 
                                                EmptyDataText="There are currently no new un-assigned tickets." 
                                                GridLines="None" Width="95%">
                                                <RowStyle CssClass="GridViewRow" />
                                                <Columns>
                                                    <asp:CommandField SelectText="Monitor Ticket" ShowSelectButton="True" />
                                                </Columns>
                                                <HeaderStyle CssClass="GridViewHeaderRow" />
                                                <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="BlueTextBold">
                        My Tickets</td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="upMyTickets">
                            <ProgressTemplate>
                                <asp:Panel ID="pnlLoading2" runat="server" CssClass="LoadingPanel" >
                                    <table border="0" cellspacing="0" cellpadding="5" align="center">
                                        <tr valign="middle">
                                            <td align="center" width="5px" height="75">
                                                <asp:Image ID="imgLoading2" runat="server" ImageUrl="~/Images/Loading.gif"/>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblLoading2" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="upMyTickets" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkRefreshMy" runat="server" CssClass="Link">Refresh My 
                                            Tickets</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gdvMytickets" runat="server" CssClass="GridView" 
                                                EmptyDataText="You currently have no open tickets assigned to yourself." 
                                                GridLines="None" Width="95%">
                                                <RowStyle CssClass="GridViewRow" />
                                                <Columns>
                                                    <asp:CommandField SelectText="View Details" ShowSelectButton="True" />
                                                </Columns>
                                                <HeaderStyle CssClass="GridViewHeaderRow" />
                                                <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

