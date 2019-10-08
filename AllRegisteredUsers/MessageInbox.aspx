<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="MessageInbox.aspx.vb" Inherits="Employers_MessageInbox" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Message Inbox</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvAllMessages" runat="server" CssClass="GridView" GridLines="None" Width="95%" AlternatingRowStyle-CssClass="GridViewAlternateRow" HeaderStyle-CssClass="GridViewHeaderRow">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField HeaderText="View Message" SelectText="View" 
                            ShowSelectButton="True" ShowHeader="False"  />
                    </Columns>

<HeaderStyle CssClass="GridViewHeaderRow"></HeaderStyle>

<AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

