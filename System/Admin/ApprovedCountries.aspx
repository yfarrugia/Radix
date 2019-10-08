<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="ApprovedCountries.aspx.vb" Inherits="System_Admin_ApprovedCountries" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="TextTitle" colspan="3">
                        Approved Countries</td>
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
                    <td class="BlueTextBold" colspan="3">
                        Approve Country</td>
                </tr>
                <tr>
                    <td class="Text" colspan="3">
                        Below is a list of all of the unapproved countries, please select one that you 
                        would like to approve.</td>
                </tr>
                <tr>
                    <td width="10">
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlUnapprovedCountries" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td width="100%">
                        &nbsp;<asp:Button ID="btnApprove" runat="server" CssClass="ButtonLightBlue" 
                            Text="Approve" />
                        &nbsp;</td>
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

