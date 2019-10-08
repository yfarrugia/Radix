<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="MyPendingJobs.aspx.vb" Inherits="Employers_MyPendingJobs" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Pending Jobs</td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <asp:GridView ID="gdvPendingJobs" runat="server" CssClass="GridView" 
                    EmptyDataText="You do not have any pending jobs." GridLines="None" 
                    Width="95%">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField HeaderText="View Job Details" SelectText="View" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

