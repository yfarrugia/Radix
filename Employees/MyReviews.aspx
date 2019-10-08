<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false"
    CodeFile="MyReviews.aspx.vb" Inherits="Employees_MyReviews" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="TextTitle">
                My Job Reviews
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvMyReviews" runat="server" CssClass="GridView" 
                    EmptyDataText="You currently have no reviews" GridLines="None" Width="95%">
                    <Columns>
                        <asp:CommandField SelectText="Report" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
