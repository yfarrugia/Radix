<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="PendingCenters.aspx.vb" Inherits="System_Admin_PendingCenters" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="TextTitle" colspan="3">
                        Centers Pending Approval</td>
                </tr>
                <tr>
                    <td class="Text" colspan="3">
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRefresh" runat="server" CssClass="Link">Refresh</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="lblSuccess" runat="server" CssClass="GreenText" 
                            Text="Country successfully apporved." Visible="False"></asp:Label>
                        <asp:Label ID="lblError" runat="server" CssClass="RedText" 
                            Text="A problem has occured while trying to approve your country, please try again." 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:GridView ID="gdvApproved" runat="server" 
                CssClass="GridView" GridLines="None" Width="95%" 
                            EmptyDataText="No countries are currently approved in the system.">
                            <RowStyle CssClass="GridViewRow" />
                            <Columns>
                                <asp:ButtonField Text="Remove" />
                            </Columns>
                            <HeaderStyle CssClass="GridViewHeaderRow" />
                            <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="10">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td width="100%">
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

