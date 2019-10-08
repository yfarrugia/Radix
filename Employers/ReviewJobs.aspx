<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="ReviewJobs.aspx.vb" Inherits="Employers_ReviewJobs" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Finished Jobs
            </td>
        </tr>
        <tr>
            <td class="Text" align="center">
                <asp:GridView ID="gdvFinishedJobs" runat="server" CssClass="GridView" 
                    GridLines="None" Width="95%" EmptyDataText="Currently no jobs to review.">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
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
</asp:Content>

