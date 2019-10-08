<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="JobHistory.aspx.vb" Inherits="Employers_JobHistory" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Job History</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvJobs" runat="server" CssClass="GridView" GridLines="None" 
                    Width="95%" 
                    EmptyDataText="You do not have any jobs created in the system.">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField SelectText="View Job Details" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

